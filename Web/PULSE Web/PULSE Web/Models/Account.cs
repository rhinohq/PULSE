using AuthenticationLib;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace PULSE_Web.Models
{
    public static class Account
    {
        private static PULSEUserDB UserDB = new PULSEUserDB();
        public static Dictionary<string, string> AccountTypes = new Dictionary<string, string>();

        public static void AddCookie(string Username, string Password, HttpResponseBase Response, bool RememberMe)
        {
            HttpCookie LoginCookie = new HttpCookie("PULSEUserAuth");
            LoginCookie.Values["Username"] = Username;
            LoginCookie.Values["Password"] = Authentication.Cryptography.Encrypt(Password, Username);

            if (RememberMe)
                LoginCookie.Expires = DateTime.Now.AddYears(1);
            else
                LoginCookie.Expires = DateTime.Now.AddHours(1);

            Response.Cookies.Add(LoginCookie);
        }

        public static void ChangePassword(string Email, string Username, string NewPassword)
        {
            User user = UserDB.Users.Where(x => x.Username == Username).FirstOrDefault();

            if (user != null)
            {
                user.PasswordHash = Authentication.HashCredentials(Email, NewPassword);
                UserDB.SaveChangesAsync();
            }
        }

        public static void CreateNewUser(User NewUser)
        {
            User user = UserDB.Users.Where(x => x.Username == NewUser.Username).FirstOrDefault();

            NewUser.PasswordHash = Authentication.HashCredentials(NewUser.Email, NewUser.PasswordHash);
            NewUser.AccountType = AccountTypes["Standard"];

            UserDB.Users.Add(NewUser);
            UserDB.SaveChangesAsync();
        }

        public static void DeleteUser(string Username, string Password)
        {
            User user = UserDB.Users.Where(x => x.Username == Username).FirstOrDefault();

            if (user != null && user.PasswordHash == Authentication.HashCredentials(user.Email, Password))
            {
                UserDB.Users.Remove(user);
                UserDB.SaveChangesAsync();
            }
        }

        public static string GetCookieUsername(HttpRequest Request, HttpCookie Cookie)
        {
            User user = UserDB.Users.Where(x => x.Username == Cookie["Username"]).FirstOrDefault();

            if (user == null)
                return null;
            else if (Cookie["Username"] != null)
                return Cookie["Username"];
            else
                return null;
        }

        public static void SetupAccountTypes()
        {
            SHA512 Hash = SHA512.Create();

            AccountTypes.Add("Admin", Convert.ToBase64String(Hash.ComputeHash(Encoding.UTF8.GetBytes("Admin"))));
            AccountTypes.Add("Standard", Convert.ToBase64String(Hash.ComputeHash(Encoding.UTF8.GetBytes("Standard"))));
            AccountTypes.Add("Pro", Convert.ToBase64String(Hash.ComputeHash(Encoding.UTF8.GetBytes("Pro"))));
            AccountTypes.Add("Dev", Convert.ToBase64String(Hash.ComputeHash(Encoding.UTF8.GetBytes("Dev"))));
        }

        public static void RemoveCookie(HttpRequest Request)
        {
            HttpCookie Cookie = Request.Cookies["PULSEUserAuth"];

            if (Cookie != null)
                Cookie.Expires.AddYears(-2);
        }

        public static bool Validation(string Data, char FieldType)
        {
            bool Validated = false;

            switch (FieldType)
            {
                case 'n':
                    Regex NameValidator = new Regex("[a-zA-Z'-]", RegexOptions.Compiled);

                    Validated = NameValidator.IsMatch(Data);

                    break;

                case 'e':
                    Regex EmailValidator = new Regex("^[a-zA-Z_0-9]+([-+.'][a-zA-Z_0-9]+)*@[a-zA-Z_0-9]+([-.][a-zA-Z_0-9]+)*.[a-zA-Z_0-9]+([-.][a-zA-Z_0-9]+)*$", RegexOptions.Compiled);

                    Validated = EmailValidator.IsMatch(Data);

                    break;

                case 'u':
                    Regex UsernameValidator = new Regex("[a-zA-Z0-9'-_.]", RegexOptions.Compiled);

                    Validated = UsernameValidator.IsMatch(Data);

                    break;

                case 'p':
                    Regex NumValidator = new Regex("[0-9]", RegexOptions.Compiled);

                    Validated = NumValidator.IsMatch(Data);

                    break;
            }

            return Validated;
        }

        public static bool VerifyCookie(HttpCookie Cookie)
        {
            string Username = Convert.ToString(Cookie.Values["Username"]);
            string Password = Convert.ToString(Cookie.Values["Password"]);
            User user = UserDB.Users.Where(x => x.Username == Username).FirstOrDefault();

            if (user == null)
            {
                Cookie.Expires.AddYears(-2);
                return false;
            }
            else if (user.PasswordHash == Authentication.HashCredentials(user.Email, Authentication.Cryptography.Decrypt(Password, Username)))
                return true;
            else
            {
                Cookie.Expires.AddYears(-2);
                return false;
            }
        }

        public static bool VerifyUser(string Username, string Password)
        {
            User user = UserDB.Users.Where(x => x.Username == Username).FirstOrDefault();

            if (user == null)
                return false;
            else if (user.PasswordHash == Authentication.HashCredentials(user.Email, Password))
                return true;
            else
                return false;
        }

        public static class Photo
        {
            public static byte[] ImageToByteArray(Image Image)
            {
                MemoryStream MemStream = new MemoryStream();

                Image.Save(MemStream, ImageFormat.Gif);

                return MemStream.ToArray();
            }

            public static Image ByteArrayToImage(byte[] ByteArray)
            {
                MemoryStream MemStream = new MemoryStream(ByteArray);

                Image Image = Image.FromStream(MemStream);

                return Image;
            }
        }
    }
}