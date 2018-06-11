using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneStopGaming.Repositories
{
    //Class for a Unit of Work
    //This Class maintains an object of all the repositories and a database context
    public class UnitOfWork : IUnitOfWork
    {
        //Private instance variable corresponding to the product repository known only by this unit of work
        private IRepository<Product> _productRepository;
        //Private instance variable corresponding to the category repository known only by this unit of work
        private IRepository<Category> _categoryRepository;
        //Private instance variable corresponding to the promotion repository known only by this unit of work
        private IRepository<Promotion> _promotionRepository;
        //Private instance variable corresponding to the user repository known only by this unit of work
        private IRepository<User> _userRepository;
        //Private instance variable corresponding to the cart repository known only by this unit of work
        private IRepository<Cart> _cartRepository;
        //Private instance variable corresponding to the cart product repository known only by this unit of work
        private IRepository<CartsProduct> _cartsProductRepository;

        //With only one Unit of Work, we only have one access point to the database
        private OneStopGamingEntities _context;

        //Method to create the database context
        public UnitOfWork()
        {
            //Create the database Context
            _context = new OneStopGamingEntities();
        }

        //Overwrite the get method for the public variable ProductRepository
        public IRepository<Product> ProductRepository
        {
            get
            {
                //If we have not yet created a product repository, create one
                if (_productRepository == null)
                {
                    _productRepository = new GenericRepository<Product>(_context);
                }
                //Return the product repository
                return _productRepository;
            }
        }

        //Overwrite the get method for the public variable CategoryRepository
        public IRepository<Category> CategoryRepository
        {
            get
            {
                //If we have not yet created a category repository, create one
                if (_categoryRepository == null)
                {
                    _categoryRepository = new GenericRepository<Category>(_context);
                }
                //Return the category repository
                return _categoryRepository;
            }
        }

        //Overwrite the get method for the public variable PromotionRepository
        public IRepository<Promotion> PromotionRepository
        {
            get
            {
                //If we have not yet created a category repository, create one
                if (_promotionRepository == null)
                {
                    _promotionRepository = new GenericRepository<Promotion>(_context);
                }
                //Return the promotion repository
                return _promotionRepository;
            }
        }

        //Overwrite the get method for the public variable UserRepository
        public IRepository<User> UserRepository
        {
            get
            {
                //If we have not yet created a category repository, create one
                if (_userRepository == null)
                {
                    _userRepository = new GenericRepository<User>(_context);
                }
                //Return the promotion repository
                return _userRepository;
            }
        }

        //Overwrite the get method for the public variable CategoryRepository
        public IRepository<Cart> CartRepository
        {
            get
            {
                //If we have not yet created a category repository, create one
                if (_cartRepository == null)
                {
                    _cartRepository = new GenericRepository<Cart>(_context);
                }
                //Return the category repository
                return _cartRepository;
            }
        }

        //Overwrite the get method for the public variable CategoryRepository
        public IRepository<CartsProduct> CartsProductRepository
        {
            get
            {
                //If we have not yet created a category repository, create one
                if (_cartsProductRepository == null)
                {
                    _cartsProductRepository = new GenericRepository<CartsProduct>(_context);
                }
                //Return the category repository
                return _cartsProductRepository;
            }
        }

        //Method to save the database context
        public bool Save()
        {
            try {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
               
            }
            return true;
        }
    }
}