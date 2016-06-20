using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using PULSE_Web.Models;

using AuthenticationLib;

namespace PULSE_Web.Controllers
{
    public class AuthController : ApiController
    {
        private static UserDBEntities UserDB = new UserDBEntities();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public User Post(AuthRequest Request)
        {
            User user = UserDB.Users.Where(x => x.Username == Request.Username).FirstOrDefault();

            if (user.PasswordHash == Authentication.HashCredentials(user.Email, Request.PasswordHash))
                return user;
            else
                return new User();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        public class AuthRequest
        {
            public string Username { get; set; }
            public string PasswordHash { get; set; }
        }
    }
}