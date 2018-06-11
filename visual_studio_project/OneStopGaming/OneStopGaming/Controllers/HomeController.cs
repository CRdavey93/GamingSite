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
    public class HomeController : Controller
    {
        //private product service variable
        private IProductService _productService;
        //pivate category service variable
        private ICategoryService _categoryService;

        //Constructor
        public HomeController()
        {
            //Create the Unit of Work
            UnitOfWork unitOfWork = new UnitOfWork();
            //Create the Product Service
            _productService = new ProductService(unitOfWork);
            //Create the Category Service
            _categoryService = new CategoryService(unitOfWork);
        }

        //Constructor with previously created Product Service
        //productService - the productService object
        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            //Set the controller's _productService variable
            _productService = productService;
            //Set the controller's _categoryService variable
            _categoryService = categoryService;
        }

        //Index page
        public ActionResult Index()
        {
            //Create the view model
            HomePageViewModel homePageViewModel = GetHomePageViewModel();

            //Return the View and pass to it the product View Model
            return View("Index", homePageViewModel);
        }

        //Function to save the user's zip code to the current session
        //zip - the zip code that was enetered
        [HttpPost]
        public JsonResult UpdateZip(string zip)
        {
            HttpCookie cookie = new HttpCookie("zip");
            cookie.Value = zip;
            Response.Cookies.Add(cookie);
            HomePageViewModel homePageViewModel = GetHomePageViewModel();
            return Json(new { m = "Success" }, JsonRequestBehavior.AllowGet);
        }
        
        //Function to create a HomePageViewModel
        private HomePageViewModel GetHomePageViewModel()
        {
            //Create a Product View Model
            ProductViewModel productViewModel = GetProductViewModel();
            //Create a List of Category View Models
            List<CategoryViewModel> categoryViewModelList = GetCategoryViewModelList();

            //Create a HomePageViewModel that contains both the list above and the productViewModel
            HomePageViewModel homePageViewModel = new HomePageViewModel();
            homePageViewModel.CategoryViewModelList = categoryViewModelList;
            homePageViewModel.ProductViewModel = productViewModel;

            return homePageViewModel;
        }

        //Function to create a ProductViewModel from the Product object that _productService returns
        //From running getFeaturedProduct
        private ProductViewModel GetProductViewModel()
        {
            Product featuredProduct = _productService.GetFeaturedProduct();
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Name = featuredProduct.Name;
            productViewModel.Price = featuredProduct.Price.ToString("#.##");
            productViewModel.Description = featuredProduct.Description;
            productViewModel.ImageUrl = featuredProduct.ImageUrl;
            productViewModel.ReleaseDate = featuredProduct.ReleaseDate.ToShortDateString();
            productViewModel.ID = featuredProduct.ID;

            //Get information about the sale price
            var zipCookie = Request.Cookies["zip"];
            decimal salePrice = 0;
            try {
                if (zipCookie != null)
                {
                    int zip = int.Parse(zipCookie.Value);
                    salePrice = _productService.GetProductSalePrice(featuredProduct.ID, zip);
                }
            }
            catch (FormatException e)
            {

            }
            productViewModel.SalePrice = salePrice.ToString("#.##");

            return productViewModel;
        }

        //Function to create a List of CategoryViewModels from the Categories List that _categoryService returns
        //From running GetCategories()
        private List<CategoryViewModel> GetCategoryViewModelList()
        {
            List<Category> categoryList = _categoryService.GetCategories();
            List<CategoryViewModel> categoryViewModelList = new List<CategoryViewModel>();
            //Place the necessary information in categoryViewModelList
            foreach (Category category in categoryList)
            {
                CategoryViewModel categoryViewModel = new CategoryViewModel();
                categoryViewModel.Name = category.Name;
                categoryViewModel.IconURL = category.IconUrl;
                categoryViewModel.ID = category.ID;
                //Since the CategoryService has already sorted categoryList, we don't need to keep track of Category Order
                //In the ViewModel
                categoryViewModelList.Add(categoryViewModel);
            }
            return categoryViewModelList;
        }
    }
}