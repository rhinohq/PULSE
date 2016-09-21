using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

using PULSE_Web.Models;

namespace PULSE_Web.Controllers
{
    public class TokenController : ApiController
    {
        private static PULSEUserDB UserDB = new PULSEUserDB();

        // GET api/<controller>/5
        public string Get(string publictoken, string username, string passwordhash)
        {
            if (Account.VerifyUser(username, passwordhash))
            {
                Device device = UserDB.Devices.Where(x => x.PublicToken == publictoken).FirstOrDefault();
                User user = UserDB.Users.Where(x => x.Username == username).FirstOrDefault();
                
                if (device != null && device.PublicToken == publictoken)
                {
                    if (device.PrivateToken == null)
                    {
                        device.PrivateToken = GetPrivateToken();

                        user.Devices.Add(device);
                    }
                    else
                        user.Devices.Add(device);


                    UserDB.SaveChangesAsync();
                    return device.PrivateToken;
                }
            }

            return null;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(string name, string username, string passwordhash)
        {
            if (Account.VerifyUser(username, passwordhash))
            {
                string PublicToken = GetPublicToken(name);
                Device device = new Device();

                device.PublicToken = PublicToken;
                device.Name = name;

                UserDB.Devices.Add(device);
                UserDB.SaveChangesAsync();
            }
        }

        // DELETE api/<controller>/5
        public void Delete(string publictoken, string privatetoken)
        {
            Device device = UserDB.Devices.Where(x => x.PublicToken == publictoken).FirstOrDefault();

            if (device != null && device.PrivateToken == privatetoken)
            {
                UserDB.Devices.Remove(device);
                UserDB.SaveChangesAsync();
                // TODO: Remove device from users
            }
        }

        public string GetPublicToken(string Name)
        {
            MD5 Hash = MD5.Create();

            string Salted = Name + "-" + DateTime.Now;
            string PublicToken = Convert.ToBase64String(Hash.ComputeHash(Encoding.UTF8.GetBytes(Salted)));

            return PublicToken;
        }

        public string GetPrivateToken()
        {
            Random Rand = new Random();
            string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string PrivateToken = "";

            for (int i = 1; i < 7; i++)
            {
                PrivateToken += Chars[Rand.Next(Chars.Length)];
            }

            Device device = UserDB.Devices.Where(x => x.PrivateToken == PrivateToken).FirstOrDefault();

            if (device != null)
                return GetPrivateToken();
            else
                return PrivateToken;
        }
    }
}