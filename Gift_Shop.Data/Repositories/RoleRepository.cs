﻿using System.Linq;
using Gift_Shop.Data.Infrastructure;
using Gift_Shop.Entities;

namespace Gift_Shop.Data.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IDbFactory dbFactory) 
            : base(dbFactory) { }

        public Role GetRoleByName(string roleName)
        {
            var role = this.DbContext.Roles.Where(a => a.Name == roleName).FirstOrDefault();
            return role;
        }
    }
}
