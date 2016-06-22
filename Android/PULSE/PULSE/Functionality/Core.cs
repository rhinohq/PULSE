using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Android.Content;
using Android.Bluetooth;
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

