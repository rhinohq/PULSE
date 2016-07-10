using PULSE_Web.Models;

using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PULSE_Web.Controllers
{
    public class UserController : ApiController
    {
        private static UserDBEntities UserDB = new UserDBEntities();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public bool Get(string Username)
        {
            User user = UserDB.Users.Where(x => x.Username == Username).FirstOrDefault();

            if (user == null)
                return false;
            else
                return true;
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
        public void Delete(int id)
        {
        }
    }
}