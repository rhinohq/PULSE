using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using Android.Content;
using Android.Bluetooth;
using Android.Net;
using Android.Provider;
using Android.Widget;

using Plugin.CurrentActivity;
using Plugin.Messaging;

namespace PULSE
{
	public static class Core
	{
		public static class Device
		{
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

			public static class WiFi
			{
				static Android.Net.Wifi.WifiManager WifiMan = (Android.Net.Wifi.WifiManager)CrossCurrentActivity.Current.Activity.GetSystemService("wifi");

				public static void ToggleWiFi(bool OnOff)
				{
					if (OnOff)
						WifiMan.SetWifiEnabled(true);
					else
						WifiMan.SetWifiEnabled(false);
				}

				public static void ConnectToNework(string SSID, string Key)
				{ 
					var WifiConfig = new Android.Net.Wifi.WifiConfiguration();

					WifiConfig.Ssid = string.Format("\"{0}\"", SSID);
					WifiConfig.PreSharedKey = string.Format("\"{0}\"", Key);

					ToggleWiFi(true);

					int NetID;
					var Network = WifiMan.ConfiguredNetworks.FirstOrDefault(cn => cn.Ssid == SSID);
					90
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

			public class Exceptions
			{
				public class ContactNotFoundException : Exception
				{
					public ContactNotFoundException()
						: base("PULSE could not find that contact")
					{ 
						
					}
				}
			}
		}
	}
}

