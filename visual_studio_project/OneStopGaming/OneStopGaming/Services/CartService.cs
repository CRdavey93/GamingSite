using OneStopGaming.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace OneStopGaming.Services
{
    //Class for a Cart Service
    //This class contains the business logic for fetching information from the Cart Table
    public class CartService : ICartService
    {
        //Instance variable for the unit of work, so that we look at the same database context each time
        private IUnitOfWork _unitOfWork;

        //Constructor
        //unitOfWork - The unit of work object that maintains the single connection to the database
        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Get Cart
        //This takes a status and a user id and returns the cart or null if one is not found
        public Cart GetCart(string status, int userId)
        {
            // There should only be a single cart related to a user so first will work
            Cart cart = _unitOfWork.CartRepository.FirstOrDefault(u => u.UserID == userId && u.Status == status);

            //If there is no cart then return null
            if (cart == null)
            {
                return null;
            }
            else            //There is a cart so return it
            {
                return cart;
            }
        }

        //Method to create a cart
        public Cart CreateCart(int userId, int zip = 0)
        {
            //Create the cart and set its zip
            Cart cart = new Cart();
            cart.Zip = zip;
            if (userId == -1)       //If the userId is -1
            {
                //Create a user and get the ID
                UserService userService = new UserService(_unitOfWork);
                userId = userService.CreateUser().ID;
            }
            //Set the cart userId to the userId and add the cart to the repository
            cart.UserID = userId;
            cart.Status = "New";
            cart.DateCreated = DateTime.Now;
            _unitOfWork.CartRepository.Add(cart);
            _unitOfWork.Save();
            return cart;
        }

        //Method for updating the cart
        public CartsProduct UpdateCart(int cartId, int productId, int quantity = 1)
        {
            //Get the correct cartProduct corresponding to cartId and product Id
            CartsProduct cartsProduct = _unitOfWork.CartsProductRepository.Where(c => c.CartID == cartId && c.ProductID == productId).FirstOrDefault();
            //If the carts product is null
            if (cartsProduct == null)
            {
                //If the quantity of the cartsProduct is greater than 1
                if (quantity >= 1)
                {
                    //Create a new cartsProduct and add it to the repository
                    cartsProduct = new CartsProduct();
                    cartsProduct.CartID = cartId;
                    cartsProduct.ProductID = productId;
                    cartsProduct.Quantity = quantity;
                    _unitOfWork.CartsProductRepository.Add(cartsProduct);
                }
            }
            else
            {
                //If quantity is 0
                if (quantity == 0)
                {
                    //Remove the cartsProduct from the repository
                    _unitOfWork.CartsProductRepository.Delete(cartsProduct);
                }
                //If the quantity does not match the cartsProduct quantity
                else if (quantity != cartsProduct.Quantity)
                {
                    //delete the cartsProduct
                    _unitOfWork.CartsProductRepository.Delete(cartsProduct);
                    //Create a new cartsProduct with the correct quantity and add it to the repository
                    cartsProduct = new CartsProduct();
                    cartsProduct.CartID = cartId;
                    cartsProduct.ProductID = productId;
                    cartsProduct.Quantity = quantity;
                    _unitOfWork.CartsProductRepository.Add(cartsProduct);
                }
            }
            _unitOfWork.Save();
            return cartsProduct;
        }

        //This function returns a list of all the products in a cart
        public List<Product> GetProductsForACart(int cartId)
        {
            List<CartsProduct> cpList = _unitOfWork.CartsProductRepository.Where(c => c.CartID == cartId).ToList();
            List<int> productIds = new List<int>();
            for (int i = 0; i < cpList.Count(); i++)
            {
                productIds.Add(cpList[i].ProductID);
            }
            List<Product> list = _unitOfWork.ProductRepository.Where(p => productIds.Contains(p.ID)).ToList();
            return list;
        }

        //This function returns a list of all the Quantities for an item in the cart
        public List<int> GetQuantitiesForACart(int cartId)
        {
            List<CartsProduct> cpList = _unitOfWork.CartsProductRepository.Where(c => c.CartID == cartId).ToList();
            List<int> list = new List<int>();
            for (int i = 0; i < cpList.Count(); i++)
            {
                list.Add(cpList[i].Quantity);
            }
            return list;
        }
    }
}