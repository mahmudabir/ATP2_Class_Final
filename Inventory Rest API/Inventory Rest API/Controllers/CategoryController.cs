using Inventory_Rest_API.Attributes;
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
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        //HATEOAS - Hypermedia as the engine of application state
        //Basic Authentication
        //Open/Token-based Authentication
        //Third party Authentication

        private CategoryRepository categoryRepository = new CategoryRepository();

        //[Route(""), BasicAuthentication]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(categoryRepository.GetAll());
        }

        [Route("{id}", Name = "GetCategoryByID")]
        public IHttpActionResult Get(int id)
        {
            var category = categoryRepository.Get(id);

            if (category == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(category);
        }

        [Route("")]
        public IHttpActionResult Post(Category category)
        {
            categoryRepository.Insert(category);
            string uri = Url.Link("GetCategoryByID", new { id = category.CategoryId });
            return Created(uri, category);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Category category)
        {
            category.CategoryId = id;
            categoryRepository.Update(category);
            return Ok(category);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            categoryRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id}/products")]
        public IHttpActionResult GetProductsByCategoryID(int id)
        {
            ProductRepository productRepository = new ProductRepository();
            return Ok(productRepository.GetProductsByCategory(id));
        }
    }
}
