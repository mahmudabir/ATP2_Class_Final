using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_First_With_Repository_Pattern.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}