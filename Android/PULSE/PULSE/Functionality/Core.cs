using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using Android.Content;
using Android.Content.PM;
using Android.Bluetooth;
using Android.Graphics;
using Android.Media;
using Android.Net.Wifi;
using Android.Provider;
using Android.Widget;

using Java.IO;

using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;

using Plugin.CurrentActivity;
using Plugin.Battery;
using Plugin.Messaging;

namespace PULSE
{
	public static class Core
	{
		public static class Device
		{
			public static class Battery
			{
				public static Card GetBatteryLevel()
				{
					string Text = "Battery is at " + CrossBattery.Current.RemainingChargePercent + " percent.";

					return new Card
					{
						CardType = CardType.Text,
						TextToSpeak = Text,
						CardTitle = "Battery",
						CardText = Text
					};
				}

				public static Card GetBatteryStatus()
				{
					string Text = "The battery is " + CrossBattery.Current.Status + ".";

					return new Card{
						CardType = CardType.Text,
						TextToSpeak = Text,
						CardTitle = "Battery",
						CardText = Text
					};
				}
			}

			public static class Bluetooth
			{ 
				public static void TurnBluetoothOn()
				{
					Intent EnableIntent = new Intent(BluetoothAdapter.ActionRequestEnable);
					CrossCurrentActivity.Current.Activity.StartActivityForResult(EnableIntent, 2);
				}

				public static void MakeBluetoothDiscoverable()
				{
					Intent DiscoverableIntent = new Intent(BluetoothAdapter.ActionRequestDiscoverable);
					CrossCurrentActivity.Current.Activity.StartActivityForResult(DiscoverableIntent, 2);
				}
			}

			public static class Media 
			{
				static MediaPlayer Player = new MediaPlayer();

				public static void StartPlayback()
				{
					Player.Start();
				}

				public static void PausePlayback()
				{
					Player.Pause();
				}

				public static void StopPlayback()
				{
					Player.Stop();
				}
			}

			public static class WiFi
			{
				static WifiManager WifiMan = (WifiManager)CrossCurrentActivity.Current.Activity.GetSystemService("wifi");

				public static void ToggleWiFi(bool OnOff)
				{
					if (OnOff)
						WifiMan.SetWifiEnabled(true);
					else
						WifiMan.SetWifiEnabled(false);
				}

				public static void ConnectToNework(string SSID, string Key)
				{ 
					var WifiConfig = new WifiConfiguration();

					WifiConfig.Ssid = string.Format("\"{0}\"", SSID);
					WifiConfig.PreSharedKey = string.Format("\"{0}\"", Key);

					ToggleWiFi(true);

					int NetID;
					var Network = WifiMan.ConfiguredNetworks.FirstOrDefault(cn => cn.Ssid == SSID);

					if (Network != null)
						NetID = Network.NetworkId;
					else 
					{
						NetID = WifiMan.AddNetwork(WifiConfig);

						WifiMan.SaveConfiguration();
					}

					WifiMan.UpdateNetwork(WifiConfig);

					var CurrCon = WifiMan.ConnectionInfo;

					if (CurrCon != null && CurrCon.NetworkId != NetID)
					{
						WifiMan.Disconnect();
						WifiMan.EnableNetwork(NetID, true);
						WifiMan.Reconnect();
					}
				}
			}

			public static class GPS
			{
				public static void TurnOnGPS()
				{
					GeoMaps.FindPostion();
				}
			}

			public static class Camera
			{
				public static void OpenCamera()
				{
					if (!IsThereAnAppToTakePictures())
						throw new Exceptions.CameraNotFoundException();

					TakeAPicture();
				}

				public static void ToggleFlashlight()
				{
					// TODO: Toggle Flashlight
				}

				static bool IsThereAnAppToTakePictures()  
				{
					Intent intent = new Intent(MediaStore.ActionImageCapture);
					IList<ResolveInfo> availableActivities = CrossCurrentActivity.Current.Activity.PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
					
					return availableActivities != null && availableActivities.Count > 0;
				}

				static void CreateDirectoryForPictures()
				{
					Pic.Dir = new File(Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures), "PULSE");

					if (!Pic.Dir.Exists())
						Pic.Dir.Mkdirs();
				}

				static void TakeAPicture()
				{
					Intent Intent = new Intent(MediaStore.ActionImageCapture);

					Pic.File = new File(Pic.Dir, string.Format("PULSEPic_{0}.jpg", Guid.NewGuid()));

					Intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(Pic.File));

					CrossCurrentActivity.Current.Activity.StartActivityForResult(Intent, 0);
				}

				public static class Pic
				{
					public static File File;
					public static File Dir;
					public static Bitmap BMP;
				}
			}
		}

		public static class GSM
		{ 
			static List<string> ContactList = new List<string>();
			static Regex NumRegex = new Regex("[0-9]", RegexOptions.Compiled);

			public static void GetContacts()
			{ 
				var URI = ContactsContract.Contacts.ContentUri;

				string[] Projection = { ContactsContract.Contacts.InterfaceConsts.Id, ContactsContract.Contacts.InterfaceConsts.DisplayName };

				var Cursor = CrossCurrentActivity.Current.Activity.ManagedQuery(URI, Projection, null, null, null);

				if (Cursor.MoveToFirst())
				{
					do
					{
						ContactList.Add(Cursor.GetString(Cursor.GetColumnIndex(Projection[1])));
					} while (Cursor.MoveToNext());
				}
			}

			public static void SendSMS(string Recipient, string Message)
			{
				var SMSMessenger = CrossMessaging.Current.SmsMessenger;

				if (NumRegex.IsMatch(Recipient))
				{
					if (SMSMessenger.CanSendSms)
						SMSMessenger.SendSms(Recipient, Message);
					else
						Toast.MakeText(CrossCurrentActivity.Current.Activity, "PULSE could not send the SMS", ToastLength.Long).Show();
				}
				else
				{ 
					throw new Exceptions.ContactNotFoundException();
				}
			}

			public static void MakePhoneCall(string Recipient)
			{ 
				var PhoneDialer = CrossMessaging.Current.PhoneDialer;

				if (NumRegex.IsMatch(Recipient))
				{
					if (PhoneDialer.CanMakePhoneCall)
						PhoneDialer.MakePhoneCall(Recipient);
					else
						Toast.MakeText(CrossCurrentActivity.Current.Activity, "PULSE could not make the call", ToastLength.Long).Show();
				}
				else
				{
					throw new Exceptions.ContactNotFoundException();
				}
			}
		}

		public static class Exceptions
		{
			public class ContactNotFoundException : Exception
			{
				public ContactNotFoundException()
					: base("PULSE could not find that contact")
				{

				}
			}

			public class CameraNotFoundException : Exception
			{
				public CameraNotFoundException()
					: base("PULSE could not find a camera")
				{

				}
			}
		}
	}
}

