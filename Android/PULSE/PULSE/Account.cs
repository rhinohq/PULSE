using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

using Android.Content;
using Android.Graphics;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using AuthenticationLib;

using Plugin.CurrentActivity;

namespace PULSE
{
	public static class Account
	{
		public static User CurrentUser { get; set; }
		const string AuthURL = "https://mypulse.me/api/auth/";
		const string TokenURL = "https://mypulse.me/api/token/";

		public static bool Login(string Username, string Password)
		{
			WebClient Client = new WebClient();
			string PasswordHash = Authentication.HashCredentials(Username, Password);

			AuthUser AuthUser = new AuthUser
			{
				Username = Username,
				PasswordHash = PasswordHash
			};

			JsonSerializerSettings JSONSettings = new JsonSerializerSettings();
			JSONSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			string Data = JsonConvert.SerializeObject(AuthUser, JSONSettings);

			Client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
			string Response = Client.UploadString(AuthURL, Data);

			User User = (User)JsonConvert.DeserializeObject(Response, JSONSettings);

			if (User.Username == null)
				return false;

			StoreAccount.StoreUser(User);
			CurrentUser = User;

			return true;
		}

		public static void SignUp()
		{ 
			Android.Net.Uri URI = Android.Net.Uri.Parse("https://mypulse.me/SignUp/");
			Intent Intent = new Intent(Intent.ActionView);
			Intent.SetData(URI);

			Intent Open = Intent.CreateChooser(Intent, "Open with");

			CrossCurrentActivity.Current.Activity.StartActivity(Open);
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
			string Request = AuthURL + CurrentUser.Username + "/" + CurrentUser.PasswordHash;
			string Response = Client.DownloadString(Request);

			if (Response == "true")
				return true;
			else
				return false;
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
		}

		public class User
		{ 
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string Username { get; set; }
			public string Email { get; set; }
			public char Gender { get; set; }
			public string PhoneNum { get; set; }
			public string PasswordHash { get; set; }
			public static byte[] ProfilePicture { get; set; }
			public virtual ICollection<Device> Devices { get; set; }
			public string AccountType { get; set; }
		}

		public class Device
		{
			public string PublicKey { get; set; }
			public string Name { get; set; }
		}
	}
}

