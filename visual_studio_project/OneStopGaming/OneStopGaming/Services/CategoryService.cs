using OneStopGaming.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStopGaming.Services
{
    //Class for the Category Service
    //This class contains the business logic for fetching information from the Category Table
    class CategoryService : ICategoryService
    {
        //Instance variable for the unit of work, so that we look at the same database context each time
        private IUnitOfWork _unitOfWork;

        //Constructor
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Get all categories
        //This function returns a list of all the Category objects stored in the database ordered by CategoryOrder
        public List<Category> GetCategories()
        {
            List<Category> list = _unitOfWork.CategoryRepository.GetAll().ToList();
            //Sort the list by CategoryOrder
            list = list.OrderBy(c => c.CategoryOrder).ToList();
            return list;
        }

    }
}
