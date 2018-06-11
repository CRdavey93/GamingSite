using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStopGaming.Models
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            CategoryViewModelList = new List<CategoryViewModel>();
        }
        public ProductViewModel ProductViewModel { get; set; }
        public List<CategoryViewModel> CategoryViewModelList { get; set; }
    }
}
