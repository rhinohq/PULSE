using AuthenticationLib;

using PULSE_Web.Models;

using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PULSE_Web.Controllers
{
    public class AuthController : ApiController
    {
        private static PULSEUserDB UserDB = new PULSEUserDB();

        // GET api/<controller>/{user}/{hash}
        [HttpGet]
        public bool Get(string publictoken, string privatetoken)
        {
            Device device = UserDB.Devices.Where(x => x.PublicToken == publictoken).FirstOrDefault();

            if (device.PrivateToken == Authentication.Cryptography.Decrypt(privatetoken, publictoken.Substring(publictoken.Length / 2)))
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
                Device device = user.Devices.Where(x => x.PublicToken == Request.PublicToken).FirstOrDefault();

                user.PasswordHash = device.PrivateToken;

                return user;
            }
            else
                return new User();
        }

        public class AuthRequest
        {
            public string Username { get; set; }
            public string PasswordHash { get; set; }
            public string PublicToken { get; set; }
        }
    }
}