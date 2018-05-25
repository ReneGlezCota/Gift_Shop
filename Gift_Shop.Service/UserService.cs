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
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork iunitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork iunitOfWork)
        {
            this.userRepository = userRepository;
            this.iunitOfWork = iunitOfWork;
        }
        
        public IEnumerable<User> GetUsers()
        {
            var users = userRepository.GetAll();
            return users;
        }

        public void CreateUser(User user)
        {
            userRepository.Add(user);
        }

        public void SaveUser()
        {
            iunitOfWork.Commit();
        }
    }
}
