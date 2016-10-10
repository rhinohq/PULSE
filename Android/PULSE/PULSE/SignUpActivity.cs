using AuthenticationLib;

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
	[Activity(Label = "Sign Up")]
	public class SignUpActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.SignUp);

			TextView txt_FirstName = FindViewById<TextView>(Resource.Id.txtFirstName);
			TextView txt_LastName = FindViewById<TextView>(Resource.Id.txtLastName);
			TextView txt_Username = FindViewById<TextView>(Resource.Id.txtUsernameUp);
			TextView txt_Password = FindViewById<TextView>(Resource.Id.txtPasswordUp);
			TextView txt_RePassword = FindViewById<TextView>(Resource.Id.txtRePassword);
			TextView txt_Email = FindViewById<TextView>(Resource.Id.txtEmail);
			TextView txt_PhoneNum = FindViewById<TextView>(Resource.Id.txtPhoneNum);
			TextView txt_DOB = FindViewById<TextView>(Resource.Id.txtDOB);
			RadioButton rb_Male = FindViewById<RadioButton>(Resource.Id.rbMale);
			RadioButton rb_Female = FindViewById<RadioButton>(Resource.Id.rbFemale);
			Button but_SignUp = FindViewById<Button>(Resource.Id.btnSignUp);

			but_SignUp.Click += delegate {
				if (ValidateData(txt_FirstName.Text, txt_LastName.Text, txt_Username.Text, txt_Password.Text, txt_RePassword.Text, txt_Email.Text, txt_PhoneNum.Text, txt_DOB.Text))
				{
					char UserGender;

					if (rb_Male.Checked)
						UserGender = 'm';
					else
						UserGender = 'f';

					Account.NewUser NewUser = new Account.NewUser {
						FirstName = txt_FirstName.Text,
						LastName = txt_LastName.Text,
						Username = txt_Username.Text,
						PasswordHash = txt_Password.Text,
						Email = txt_Email.Text,
						Gender = UserGender,
						PhoneNum = txt_PhoneNum.Text,
						DOB = txt_DOB.Text
					};

					Account.SignUp(NewUser);
				}
			};
		}

		bool ValidateData(string FirstName, string LastName, string Username, string Password, string RePassword, string Email, string PhoneNum, string DOB)
		{
			bool[] Validations = new bool[7];
			int Index = 0;

			if (!Account.Validation(FirstName, 'n'))
				Toast.MakeText(this, "Invalid first name", ToastLength.Short).Show();
			else
				Validations[Index] = true;

			Index++;

			if (!Account.Validation(LastName, 'n'))
				Toast.MakeText(this, "Invalid last name", ToastLength.Short).Show();
			else
				Validations[Index] = true;
			
			Index++;

			if (!Account.Validation(Username, 'u'))
				Toast.MakeText(this, "Invalid username", ToastLength.Short).Show();
			else
				Validations[Index] = true;
			
			Index++;

			if (!(Password == RePassword))
				Toast.MakeText(this, "Passwords do not match", ToastLength.Short).Show();
			else
				Validations[Index] = true;
			
			Index++;

			if (!Account.Validation(Email, 'e'))
				Toast.MakeText(this, "Invalid email", ToastLength.Short).Show();
			else
				Validations[Index] = true;
			
			Index++;

			if (!Account.Validation(PhoneNum, 'p'))
				Toast.MakeText(this, "Invalid phone number", ToastLength.Short).Show();
			else
				Validations[Index] = true;
			
			Index++;

			if (!Account.Validation(DOB, 'd'))
				Toast.MakeText(this, "Invalid date of birth", ToastLength.Short).Show();
			else
				Validations[Index] = true;

			foreach (bool Valid in Validations)
			{
				if (!Valid)
					return false;
			}

			return true;
		}
	}
}

