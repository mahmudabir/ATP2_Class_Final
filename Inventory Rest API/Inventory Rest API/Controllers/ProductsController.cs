using Inventory_Rest_API.Models;
using Inventory_Rest_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Inventory_Rest_API.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductRepository productRepository = new ProductRepository();
        public IHttpActionResult Get()
        {
            return Ok(productRepository.GetAll());
        }

        public IHttpActionResult Get(int id)
        {
            var category = productRepository.Get(id);

            if (category == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(category);
        }

        public IHttpActionResult Post(Product product)
        {
            productRepository.Insert(product);
            return Created("api/categories/" + product.CategoryId, product);
        }

        public IHttpActionResult Put([FromUri] int id, [FromBody] Product product)
        {
            product.CategoryId = id;
            productRepository.Update(product);
            return Ok(product);
        }

        public IHttpActionResult Delete(int id)
        {
            productRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
