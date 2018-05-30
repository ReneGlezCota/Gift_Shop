using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Gift_Shop.Entities;
using Gift_Shop.Service;
using Gift_Shop.Web.ViewModels;

namespace Gift_Shop.Web.Controllers
{
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: api/Category
        public IEnumerable<CategoryViewModel> Get()
        {
            IEnumerable<CategoryViewModel> result;
            IEnumerable<Category> getCategories;

            getCategories = categoryService.GetCategories().ToList();
            result = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(getCategories);

            return result;
        }

        // GET: api/Category/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Category
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
        }
    }
}
