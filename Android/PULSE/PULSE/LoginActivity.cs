using Android.App;
using Android.OS;
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

			TextView txt_Username = FindViewById<TextView>(Resource.Id.txtUsernameIn);
			TextView txt_Password = FindViewById<TextView>(Resource.Id.txtPasswordIn);
			Button but_login = FindViewById<Button>(Resource.Id.btnLogIn);
			TextView txt_signup = FindViewById<TextView>(Resource.Id.txtSignUp);
			ProgressBar pbr_Progress = FindViewById<ProgressBar>(Resource.Id.pbrSignIn);

			txt_signup.Click += delegate {
				StartActivity(typeof(SignUpActivity));
			};

			but_login.Click += delegate {
				pbr_Progress.Visibility = ViewStates.Visible;
				pbr_Progress.Enabled = true;

				string Username = txt_Username.Text;
				string Password = txt_Password.Text;

				if (Account.Login(Username, Password)) 
				{ 
					Toast.MakeText(this, "Login successful", ToastLength.Short).Show();

					StartActivity(typeof(MainActivity));
				}
				else
				{
					txt_Username.Text = "";
					txt_Password.Text = "";

					pbr_Progress.Enabled = false;
					pbr_Progress.Visibility = ViewStates.Invisible;

					Toast.MakeText(this, "Username or password incorrect", ToastLength.Long).Show();
				}	
			};
		}
	}
}

