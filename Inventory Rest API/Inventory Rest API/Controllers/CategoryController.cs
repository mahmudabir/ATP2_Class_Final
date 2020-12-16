using Inventory_Rest_API.Attributes;
using Inventory_Rest_API.Models;
using Inventory_Rest_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;

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

        [Route(""), BasicAuthentication]
        //[Route("")]
        public IHttpActionResult Get()
        {
            var authOrNot = Thread.CurrentPrincipal.Identity.IsAuthenticated;
            var authUsername = Thread.CurrentPrincipal.Identity.Name.ToString();
            var authUserRole = Thread.CurrentPrincipal.IsInRole(null);
            var authInstanceType = Thread.CurrentPrincipal.GetType();
            var authType = Thread.CurrentPrincipal.Identity.AuthenticationType;
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


        [Route("login")]
        public IHttpActionResult GetLogin()
        {
            return StatusCode(HttpStatusCode.OK);
        }

        [Route("logout")]
        public IHttpActionResult GetLogout()
        {

            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(""), null);
            var authOrNot = Thread.CurrentPrincipal.Identity.IsAuthenticated;
            var authUsername = Thread.CurrentPrincipal.Identity.Name.ToString();
            var authUserRole = Thread.CurrentPrincipal.IsInRole(null);
            var authInstanceType = Thread.CurrentPrincipal.GetType();
            var authType = Thread.CurrentPrincipal.Identity.AuthenticationType;
            return StatusCode(HttpStatusCode.OK);
        }
    }
}
