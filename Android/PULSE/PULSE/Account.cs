using System.Net;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using AuthenticationLib;

namespace PULSE
{
	public static class Account
	{
		const string AuthURL = "https://mypulse.me/api/auth/";

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

			return true;
		}

		public class AuthUser
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
		}
	}
}

