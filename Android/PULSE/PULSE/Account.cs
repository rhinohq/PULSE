using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;

using Android.Graphics;
using Android.Widget;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using AuthenticationLib;

using Plugin.CurrentActivity;

namespace PULSE
{
	public static class Account
	{
		const string AuthURL = "http://mypulse.me/api/auth/";
		const string TokenURL = "http://mypulse.me/api/token/";
		const string UserURL = "http://mypulse.me/api/user/";

		public static bool Login(string Username, string Password)
		{
			HttpClient Client = new HttpClient();
			string PasswordHash = Authentication.HashCredentials(Username, Password);
			string Request = TokenURL + Android.OS.Build.Model + "/" + Username + "/" + PasswordHash;
			User User;

			string Response = Client.PutAsync(Request, 
			Config.CreateConfig(Response);

			AuthUser AuthUser = new AuthUser
			{
				Username = Username,
				PasswordHash = PasswordHash,
				PublicToken = Config.DevicePublicToken
			};

			JsonSerializerSettings JSONSettings = new JsonSerializerSettings();
			JSONSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			string Data = JsonConvert.SerializeObject(AuthUser, JSONSettings);

			try
			{
				Client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
				string Response = Client.UploadString(AuthURL, Data);

				User = (User)JsonConvert.DeserializeObject(Response, JSONSettings);
			}
			catch
			{
				User = new User();
			}

			if (User.Username == null)
				return false;

			try
			{
				StoreAccount.StoreUser(User);

				return true;
			}
			catch
			{
				return false;
			}
		}

		public static User SignUp(User NewUser)
		{ 
			WebClient Client = new WebClient();
			User User;

			JsonSerializerSettings JSONSettings = new JsonSerializerSettings();
			JSONSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			string Data = JsonConvert.SerializeObject(NewUser, JSONSettings);

			try
			{
				Client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
				string Response = Client.UploadString(UserURL, Data);

				User = (User)JsonConvert.DeserializeObject(Response, JSONSettings);
			}
			catch
			{
				Toast.MakeText(CrossCurrentActivity.Current.Activity, "Error connecting to server", ToastLength.Short).Show();

				User = new User();
			}

			return User;
		}

		public static void LogOut()
		{
			StoreAccount.DeleteDB();

			CrossCurrentActivity.Current.Activity.StartActivity(typeof(LoginActivity));
		}

		public static bool CheckUser()
		{
			if (CurrentUser.Username == null)
				return false;

			WebClient Client = new WebClient();
			string Request = AuthURL + Config.DevicePublicToken + "/" + Config.DevicePrivateToken + "/" + Config.Username;
			string Response = "";

			try
			{
				Response = Client.DownloadString(Request);
			}
			catch
			{ 
				Toast.MakeText(CrossCurrentActivity.Current.Activity, "Error connecting to server", ToastLength.Short).Show();
			}

			if (Response == "true")
				return true;
			else
				return false;
		}

		public static string CreatePublicToken(string Name)
		{
			MD5 Hash = MD5.Create();

			string Salted = Name + "-" + DateTime.Now;
			string PublicToken = Convert.ToBase64String(Hash.ComputeHash(Encoding.UTF8.GetBytes(Salted)));

			return PublicToken;
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

				case 'd':
					Regex DateValidator = new Regex("^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)", RegexOptions.Compiled);

					Validated = (DateValidator.IsMatch(Data) || Convert.ToInt32(Data.Substring(Data.Length - 4)) <= 2016);

					break;
			}

			return Validated;
		}

		public static class Photo
		{
			public static byte[] ConvertBitmapToByteArray(Bitmap BMP)
			{
				if (BMP == null)
					return null;

				BinaryFormatter BF = new BinaryFormatter();

				using (MemoryStream MS = new MemoryStream())
				{
					BF.Serialize(MS, BMP);

					return MS.ToArray();
				}
			}

			public static Bitmap ConvertByteArrayToBitmap(byte[] BMP)
			{ 
				if (BMP == null)
					return null;

				BinaryFormatter BF = new BinaryFormatter();

				using (MemoryStream MS = new MemoryStream())
				{ 
					MS.Write(BMP, 0, BMP.Length);
					MS.Seek(0, SeekOrigin.Begin);

					return (Bitmap)BF.Deserialize(MS);
				}
			}
		}

		class AuthUser
		{
			public string Username { get; set; }
			public string PasswordHash { get; set; }
			public string PublicToken { get; set; }
		}

		public class User
		{ 
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string Username { get; set; }
			public string Email { get; set; }
			public char Gender { get; set; }
			public string PhoneNum { get; set; }
			public string DOB { get; set; }
			public string PrivateToken { get; set; }
			public static byte[] ProfilePicture { get; set; }
			public virtual ICollection<Device> Devices { get; set; }
			public string AccountType { get; set; }
		}

		public class Device
		{
			public string PublicToken { get; set; }
			public string Name { get; set; }
			public string PrivateToken { get; set; }
		}
	}
}

