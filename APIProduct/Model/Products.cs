using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProduct.Model
{
    public class Products
    {
        public int id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public decimal price { get; set; }

        public string category { get; set; }
        public string image { get; set; }
        public  Rating rating { get; set; }            
            
    }

    public class Rating
    {
        public decimal rate { get; set; }

        public int count { get; set; }
    }
}
