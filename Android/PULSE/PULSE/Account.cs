using System.Collections.Generic;
using System.Net;

using Android.Content;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using AuthenticationLib;

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

			return true;
		}

		public static void SignUp(LoginActivity Activity)
		{ 
			Android.Net.Uri URI = Android.Net.Uri.Parse("https://mypulse.me/SignUp/");
			Intent Intent = new Intent(Intent.ActionView);
			Intent.SetData(URI);

			Intent Open = Intent.CreateChooser(Intent, "Open with");

			Activity.StartActivity(Open);
		}

		public static void LogOut(LoginActivity Activity)
		{
			StoreAccount.DeleteDB();

			Activity.StartActivity(typeof(LoginActivity));
		}

		public static bool CheckUser()
		{ 
			WebClient Client = new WebClient();
			string Request = AuthURL + CurrentUser.Username + "/" + CurrentUser.PasswordHash;
			string Response = Client.DownloadString(Request);

			if (Response == "true")
				return true;
			else
				return false;
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
			public string PhoneNum { get; set; }
			public string PasswordHash { get; set; }
			public virtual ICollection<Device> Devices { get; set; }
		}

		public class Device
		{
			public string PublicKey { get; set; }
		}
	}
}

