using AuthenticationLib;

using PULSE_Web.Models;

using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PULSE_Web.Controllers
{
    public class AuthController : ApiController
    {
        private static UserDBEntities UserDB = new UserDBEntities();

        // GET api/<controller>/{user}/{hash}
        [HttpGet]
        public bool Get(string username, string passwordhash)
        {
            User user = UserDB.Users.Where(x => x.Username == username).FirstOrDefault();

            if (user.PasswordHash == Authentication.HashCredentials(user.Email, passwordhash))
                return true;
            else
                return false;
        }

        // POST api/<controller>
        [HttpPost]
        public User Post(AuthRequest Request)
        {
            User user = UserDB.Users.Where(x => x.Username == Request.Username).FirstOrDefault();

            if (user.PasswordHash == Authentication.HashCredentials(user.Email, Request.PasswordHash))
            {
                user.PasswordHash = Request.PasswordHash;

                return user;
            }
            else
                return new User();
        }

        public class AuthRequest
        {
            public string Username { get; set; }
            public string PasswordHash { get; set; }
        }
    }
}