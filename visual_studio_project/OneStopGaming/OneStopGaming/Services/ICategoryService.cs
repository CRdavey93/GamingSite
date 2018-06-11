using System.Collections.Generic;

namespace OneStopGaming.Services
{
    //Interface for a Category Service
    public interface ICategoryService
    {
        List<Category> GetCategories();
    }
}