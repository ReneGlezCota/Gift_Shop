using System.Collections.Generic;
using Gift_Shop.Entities;

namespace Gift_Shop.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(string username, string password);
        void CreateUser(User user);
        void SaveUser();
    }
}