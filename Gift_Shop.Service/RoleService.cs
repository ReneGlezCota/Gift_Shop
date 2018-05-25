using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gift_Shop.Data.Infrastructure;
using Gift_Shop.Data.Repositories;
using Gift_Shop.Entities;

namespace Gift_Shop.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository iroleRepository;
        private readonly IUnitOfWork iunitOfWork;

        public  RoleService(IRoleRepository iroleRepository, IUnitOfWork iunitOfWork)
        {
            this.iroleRepository = iroleRepository;
            this.iunitOfWork = iunitOfWork;
        }

        public Role GetRole(string name)
        {
            var role = iroleRepository.GetRoleByName(name);
            return role;
        }

        public Role GetRole(int id)
        {
            var role = iroleRepository.GetById(id);
            return role;
        }

        public IEnumerable<Role> GetRoles()
        {
            var roles = iroleRepository.GetAll();
            return roles;
        }
    }
}
