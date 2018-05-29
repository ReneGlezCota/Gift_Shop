using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Gift_Shop.Entities;
using Gift_Shop.Service;
using Gift_Shop.Web.ViewModels;

namespace Gift_Shop.Web.Controllers
{
   [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/Product
        public IEnumerable<ProductViewModel> Get()
        {
            IEnumerable<ProductViewModel> result;
            IEnumerable<Product> getProducts;

            getProducts = productService.GetProducts().ToList();
            result = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(getProducts);

            return result;            
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
