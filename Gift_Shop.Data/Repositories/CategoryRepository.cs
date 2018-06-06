using System.Linq;
using Gift_Shop.Data.Infrastructure;
using Gift_Shop.Entities;

namespace Gift_Shop.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) 
            : base(dbFactory) { }           
    }
}
