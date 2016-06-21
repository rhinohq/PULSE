using Android.App;
using Android.Widget;
using Android.OS;

namespace PULSE
{
	[Activity(Label = "PULSE", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			Account.CurrentUser = StoreAccount.GetUser();

			if (!Account.CheckUser())
				this.StartActivity(typeof(LoginActivity));
		}
	}
}


