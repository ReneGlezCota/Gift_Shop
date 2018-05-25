using System.Collections.Generic;
using Gift_Shop.Entities;

namespace Gift_Shop.Service
{
    public interface IRoleService
    {
        IEnumerable<Role> GetRoles();
        Role GetRole(int id);
        Role GetRole(string name);
    }
}