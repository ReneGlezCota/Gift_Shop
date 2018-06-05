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
using Newtonsoft.Json.Linq;

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
        public string Post(ProductFormViewModel value)
        {
            if(value != null)
            {
                var product = Mapper.Map<ProductFormViewModel, Product>(value);
                productService.CreateProduct(product);
                productService.SaveProduct();
                return "OK";
            }
            return "Error";
        }

        // PUT: api/Product/5
        public string Put(ProductFormUpdateViewModel value)
        {
            if (value != null)
            {
                var product = Mapper.Map<ProductFormUpdateViewModel, Product>(value);
                productService.UpdateProduct(product);
                productService.SaveProduct();
                return "OK";
            }
            return "Error";
        }

        // DELETE: api/Product/5
        public string Delete(int id)
        {
            productService.DeleteProduct(id);
            productService.SaveProduct();
            return "OK";
        }
    }
}
