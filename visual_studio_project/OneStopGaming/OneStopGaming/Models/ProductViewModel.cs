using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneStopGaming.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Price { get; set; }
        public string ReleaseDate { get; set; }
        public int ID { get; set; }
        public string SalePrice { get; set; }
    }
}