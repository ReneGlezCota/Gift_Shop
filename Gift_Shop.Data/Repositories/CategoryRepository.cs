using System;
using System.Collections.Generic;
using System.Linq;
using Gift_Shop.Data.Infrastructure;
using Gift_Shop.Entities;

namespace Gift_Shop.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) 
            : base(dbFactory) { }

        public Category GetCategoryByName(string categoryName)
        {
            var category = this.DbContext.Categories.Where(a => a.Name == categoryName).FirstOrDefault();

            return category;
        }

        public override void Update(Category entity)
        {
            base.Update(entity);
        }


    }
}
