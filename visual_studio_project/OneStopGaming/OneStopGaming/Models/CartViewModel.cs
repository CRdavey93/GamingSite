using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneStopGaming.Models
{
    public class CartViewModel
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserID { get; set; }
        public int Zip { get; set; }
        public List<ProductViewModel> ProductViewModels { get; set; }
        public List<int> Quantity { get; set; }
        public int Length { get; set; }
    }
}