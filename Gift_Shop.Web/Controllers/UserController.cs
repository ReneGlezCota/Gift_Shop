using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using AutoMapper;
using Gift_Shop.Entities;
using Gift_Shop.Service;
using Gift_Shop.Web.ViewModels;
using Newtonsoft.Json.Linq;

namespace Gift_Shop.Web.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }        

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public UserViewModel Post([FromBody]JObject data)
        {
            var username = data["username"].ToObject<string>();
            var password = data["password"].ToObject<string>();

            UserViewModel result;
            User getUser;

            getUser = userService.GetUser(username, password);

            if (getUser != null)
                result = Mapper.Map<User, UserViewModel>(getUser);            
            else
                result = null;

            return result;
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
