using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStoreFall2019
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public bool PromoFront { get; set; }
        public bool PromoDept { get; set; }
    }
}