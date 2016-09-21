using Android.App;
using Android.Widget;
using Android.OS;
using Android.Webkit;

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
			{
				Account.LogOut();
				Finish();
			}

			Startup();

			var web_view = FindViewById<WebView>(Resource.Id.wbvContent);
			web_view.Settings.JavaScriptEnabled = true;
			web_view.LoadUrl("https://www.google.com");
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

			switch (CurrentCard.CardType)
			{
				case CardType.Text:
					break;
				case CardType.Image:
					break;
				case CardType.Video:
					break;
				case CardType.WebView:
					string Url = "file:///" + CurrentCard.CardUrl;

					break;
			}
		}

		void FindLocation()
		{ 
			GeoMaps.CurrentPosition = GeoMaps.FindPostion();
			GeoMaps.CurrentLocation = GeoMaps.GetLocation();
		}
	}
}


