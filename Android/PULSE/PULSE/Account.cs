using System;

using AuthenticationLib;

namespace PULSE
{
	public class Account
	{
		public void Login(string Username, string Password)
		{
			string PasswordHash = Authentication.HashCredentials(Username, Password);
		}
	}
}

