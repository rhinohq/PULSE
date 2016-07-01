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
				StartActivity(typeof(LoginActivity));

			Startup();
		}

		void Startup()
		{ 
			Core.GSM.GetContacts();

			GeoMaps.CurrentPosition = GeoMaps.FindPostion();
			GeoMaps.CurrentLocation = GeoMaps.GetLocation();

			Speech.Speak("Hello, " + Account.CurrentUser.FirstName);
		}

		void CardHandler(Card CurrentCard)
		{
			CurrentCard.Speak();
		}
	}
}


