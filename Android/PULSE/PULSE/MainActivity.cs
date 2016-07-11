using Android.App;
using Android.Widget;
using Android.OS;

using System.Threading;

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
			Thread Contacts = new Thread(Core.GSM.GetContacts);
			Thread Location = new Thread(FindLocation);

			Speech.Speak("Hello, " + Account.CurrentUser.FirstName);
		}

		void CardHandler(Card CurrentCard, bool SpeakToUser)
		{
			if (SpeakToUser)
				CurrentCard.Speak();
		}

		void FindLocation()
		{ 
			GeoMaps.CurrentPosition = GeoMaps.FindPostion();
			GeoMaps.CurrentLocation = GeoMaps.GetLocation();
		}
	}
}


