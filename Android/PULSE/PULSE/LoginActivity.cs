using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PULSE
{
	[Activity(Label = "LoginActivity")]
	public class LoginActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Login);

			Button but_login = FindViewById<Button>(Resource.Id.btnLogIn);
			TextView txt_signup = FindViewById<TextView>(Resource.Id.txtSignUp);

			txt_signup.Click += delegate {
				Account.SignUp(this);
			};

			but_login.Click += delegate {
				
			};
		}
	}
}

