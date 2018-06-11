using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OneStopGaming.Repositories;
using System.Linq.Expressions;

namespace OneStopGaming.Services
{
    //Class for a Product Service
    //This class has business logic for getting product information from the repository
    public class ProductService : IProductService
    {
        //Instance variable for the unit of work, so that we look at the same database context each time
        private IUnitOfWork _unitOfWork;

        //Constructor
        //unitOfWork - The unit of work object that maintains the single connection to the database
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Get featured product
        //This method will select the product from the database that has the featured flag set to true
        //Returns the Product object
        public Product GetFeaturedProduct()
        {
            //Expression to get products with Featured set to true
            Expression<Func<Product, bool>> expression = p => p.Featured;
            //There will only be one featured product, so first will work
            Product product = _unitOfWork.ProductRepository.FirstOrDefault(expression);
            //If there is no product, return the first product in the database
            if (product == null)
            {
                expression = p => true;
                product = _unitOfWork.ProductRepository.FirstOrDefault(expression);
            }
            return product;
        }

        //Get a Sale Price for a Product given an ID and a Zip Code
        //There will only be one promotion per product at a time
        public decimal GetProductSalePrice(int id, int zipCode)
        {
            //Expression to get Promotions with the given zip code and id
            //Must make sure that today's date falls within the promotion date
            Expression<Func<Promotion, bool>> expression = p => p.ProductID == id && p.Zip == zipCode && p.StartDate <= DateTime.Today && p.EndDate >= DateTime.Today;
            Promotion promotion = _unitOfWork.PromotionRepository.FirstOrDefault(expression);
            //If there is no promotion, return 0
            if (promotion == null)
            {
                return 0;
            }
            return (decimal)promotion.SalePrice;
        }

    }
}