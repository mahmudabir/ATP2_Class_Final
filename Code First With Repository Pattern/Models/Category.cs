using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_First_With_Repository_Pattern.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}