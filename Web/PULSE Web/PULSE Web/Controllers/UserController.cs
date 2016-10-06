using PULSE_Web.Models;

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http;

using AuthenticationLib;

namespace PULSE_Web.Controllers
{
    public class UserController : ApiController
    {
        private static PULSEUserDB UserDB = new PULSEUserDB();

        // GET api/<controller>/5
        public bool Get(string Data)
        {
            Regex UsernameValidator = new Regex("[a-zA-Z0-9'-_.]", RegexOptions.Compiled);
            Regex EmailValidator = new Regex("^[a-zA-Z_0-9]+([-+.'][a-zA-Z_0-9]+)*@[a-zA-Z_0-9]+([-.][a-zA-Z_0-9]+)*.[a-zA-Z_0-9]+([-.][a-zA-Z_0-9]+)*$", RegexOptions.Compiled);
            Regex NumValidator = new Regex("[0-9]", RegexOptions.Compiled);
            User user;

            if (UsernameValidator.IsMatch(Data))
                user = UserDB.Users.Where(x => x.Username == Data).FirstOrDefault();
            else if (EmailValidator.IsMatch(Data))
                user = UserDB.Users.Where(x => x.Email == Data).FirstOrDefault();
            else if (NumValidator.IsMatch(Data))
                user = UserDB.Users.Where(x => x.PhoneNum == Data).FirstOrDefault();
            else
                return false;

            if (user == null)
                return true;
            else 
                return false;
        }

        // POST api/<controller>
        public User Post(User NewUser)
        {
            return Account.CreateNewUser(NewUser);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(string Username, string EncryptPasswordHash)
        {
            User user = UserDB.Users.Where(x => x.Username == Username).FirstOrDefault();

            if (user != null)
            {
                string PasswordHash = Authentication.HashCredentials(user.Email, Authentication.Cryptography.Decrypt(EncryptPasswordHash, user.PhoneNum));

                if (user.PasswordHash == PasswordHash)
                {
                    UserDB.Users.Remove(user);
                    UserDB.SaveChangesAsync();
                } 
            }
        }
    }
}