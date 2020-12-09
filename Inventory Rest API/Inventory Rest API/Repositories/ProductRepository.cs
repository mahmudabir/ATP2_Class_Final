using Inventory_Rest_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Inventory_Rest_API.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public List<Product> GetTopProducts(int top)
        {
            return this.GetAll().OrderByDescending(x => x.Price).Take(top).ToList();
        }

        public List<Product> GetProductsByCategory(int id)
        {
            return this.GetAll().Where(x => x.CategoryId == id).ToList();
        }
    }
}