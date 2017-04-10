﻿using WebSale.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.OData;

namespace WebSale.WebAPI.Controllers
{
    [EnableCors("*", "*", "GET,POST")]
    public class ProductsController : ODataController
    {
        // GET: api/Products
        [EnableQuery]
        public IQueryable<Product> Get()
        {
            var productRepository = new ProductRepository();
            return productRepository.Retrieve().AsQueryable();
        }

        //[EnableQuery]
        //public IHttpActionResult Get()
        //{
        //    var productRepository = new ProductRepository();
        //    return Ok(productRepository.Retrieve().AsQueryable());
        //}

        //public IEnumerable<Product> Get(string search)
        //{
        //    var productRepository = new ProductRepository();
        //    var products = productRepository.Retrieve();
        //    return products.Where(p => p.ProductCode.Contains(search));
        //}

        // GET: api/Products/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}