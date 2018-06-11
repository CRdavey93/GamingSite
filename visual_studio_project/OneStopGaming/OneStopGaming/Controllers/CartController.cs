using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneStopGaming.Services;
using OneStopGaming.Repositories;
using OneStopGaming.Models;

namespace OneStopGaming.Controllers
{
    public class CartController : Controller
    {
        //private cart service variable
        private ICartService _cartService;

        //private user service variable
        private IUserService _userService;

        //private product service variable
        private IProductService _productService;

        //Constructor
        public CartController()
        {
            //create the unit of work
            UnitOfWork unitOfWork = new UnitOfWork();
            //Create the cart service
            _cartService = new CartService(unitOfWork);
            //Create the user service
            _userService = new UserService(unitOfWork);
            //Create the product service
            _productService = new ProductService(unitOfWork);
        }

        //Constructor with previously create Cart service
        public CartController(ICartService cartService, IUserService userService, IProductService productService)
        {
            //Set the controller's _cartservice variable
            _cartService = cartService;
            //set the controller's _userservice variable
            _userService = userService;
            _productService = productService;

        }
        // GET: Cart
        public ActionResult Index()
        {
            CartViewModel cartViewModel = GetCartViewModel();
            return View(cartViewModel);
        }

       //Function to create a CartViewModel
        private CartViewModel GetCartViewModel()
        {
            //Get the user ID
            HttpCookie cookie = Request.Cookies.Get("userId");
            int userId = 0;
            if (cookie != null)
            {
                //Get the userId from the cookie - converts the string cookie value to an int
                string s = cookie.Value;
                userId = int.Parse(s);
                userId = Convert.ToInt32(s);
            }
            else        //The cookie does not return a userId
            {
                //Create a new user and add the userId to a cookie
                User user = _userService.CreateUser();
                HttpCookie uCookie = new HttpCookie("userId");
                uCookie.Value = user.ID.ToString();
                Response.Cookies.Add(uCookie);
                userId = user.ID;
            }
            Cart cart = _cartService.GetCart("New",userId);
            if (cart != null)
            {
                CartViewModel cartViewModel = new CartViewModel();
                cartViewModel.ID = cart.ID;
                cartViewModel.Status = cart.Status;
                cartViewModel.Zip = (int)cart.Zip;


                List<Product> productsList = _cartService.GetProductsForACart(cart.ID);
                cartViewModel.ProductViewModels = new List<ProductViewModel>();
                for (int i = 0; i < productsList.Count(); i++)
                {
                    cartViewModel.ProductViewModels.Add(GetProductViewModel(productsList[i]));
                }
                cartViewModel.Quantity = _cartService.GetQuantitiesForACart(cart.ID);

                cartViewModel.Length = productsList.Count();

                return cartViewModel;
            }
            else
            {
                return null;
            }
        }

        //Generate a product's view model
        public ProductViewModel GetProductViewModel(Product product)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Name = product.Name;
            productViewModel.Price = product.Price.ToString("#.##");
            productViewModel.Description = product.Description;
            productViewModel.ImageUrl = product.ImageUrl;
            productViewModel.ReleaseDate = product.ReleaseDate.ToShortDateString();
            productViewModel.ID = product.ID;

            //Get information about the sale price
            var zipCookie = Request.Cookies["zip"];
            decimal salePrice = 0;
            try
            {
                if (zipCookie != null)
                {
                    int zip = int.Parse(zipCookie.Value);
                    salePrice =  _productService.GetProductSalePrice(product.ID, zip);
                }
            }
            catch (FormatException e)
            {

            }
            productViewModel.SalePrice = salePrice.ToString("#.##");

            return productViewModel;
        }

        [HttpPost]
        //Function to add an item to the cart
        public JsonResult AddToCart(string productIdS)
        {
            int productId = int.Parse(productIdS);
            //get the userId cookie
            HttpCookie cookie = Request.Cookies.Get("userId");
            //If the userId cookie is not null
            if(cookie != null)
            {
                //Get the userId from the cookie - converts the string cookie value to an int
                int userId = 0;
                string s = cookie.Value;
                userId = int.Parse(s);
                userId = Convert.ToInt32(s);

                //Call the GetCart method with "new" status and the userId from the cookie
                Cart cart = _cartService.GetCart("new", userId);
                //If the cart exists
                if(cart != null)
                {
                    //get the cart ID and update the cart
                    int cartsId = cart.ID;
                    _cartService.UpdateCart(cartsId, productId, 1);
                }
            }
            else        //The cookie does not return a userId
            {
                //Create a new user and add the userId to a cookie
                User user = _userService.CreateUser();
                HttpCookie uCookie = new HttpCookie("userId");
                uCookie.Value = user.ID.ToString();
                Response.Cookies.Add(uCookie);

                int userId = user.ID; 
                Cart cart = _cartService.CreateCart(userId);
                _cartService.UpdateCart(cart.ID, productId, 1);
            }

            return Json(new { m = "Success" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //Function to add an item to the cart
        public JsonResult UpdateCart(string quantityS, string productIdS)
        {
            int productId = int.Parse(productIdS);
            int quantity = int.Parse(quantityS);
            //get the userId cookie
            HttpCookie cookie = Request.Cookies.Get("userId");

            int userId = 0;
            string s = cookie.Value;
            userId = int.Parse(s);
            userId = Convert.ToInt32(s);

            Cart cart = _cartService.GetCart("new", userId);
            _cartService.UpdateCart(cart.ID, productId, quantity);

            return Json(new { m = "Success" }, JsonRequestBehavior.AllowGet);
        }

    }
}