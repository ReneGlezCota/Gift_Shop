using Gift_Shop.Data.Infrastructure;
using Gift_Shop.Entities;

namespace Gift_Shop.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) 
            : base(dbFactory) { }
    }
}
