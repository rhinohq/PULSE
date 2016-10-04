using System;
using System.IO;

using SQLite;

namespace PULSE 
{
	public static class StoreAccount
	{
		static string DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "PULSE.db");

		public static void StoreUser(Account.User User)
		{ 
			SQLiteConnection DB = new SQLiteConnection(DBPath);

			DB.CreateTable<Device>();

			Config.DevicePrivateToken = User.PrivateToken;
			Config.Username = User.Username;
			Config.FirstName = User.FirstName;
			Config.LastName = User.LastName;
			Config.Email = User.Email;
			Config.Gender = User.Gender.ToString();
			Config.PhoneNum = User.PhoneNum;
			Config.DOB = User.DOB;
			Config.AccountType = User.AccountType;

			foreach (Account.Device Device in User.Devices)
			{
				DB.Insert(new Device 
				{ 
					PublicToken = Device.PublicToken,
					Name = Device.Name,
					PrivateToken = Device.PrivateToken
				});
			}
		}

		public static void DeleteDB()
		{ 
			SQLiteConnection DB = new SQLiteConnection(DBPath);

			DB.DeleteAll<Device>();

			DB.Close();
		}

		public static Account.User GetUser()
		{ 
			SQLiteConnection DB = new SQLiteConnection(DBPath);
			Account.User User = new Account.User();

			try
			{
				User.Username = Config.Username;
				User.FirstName = Config.FirstName;
				User.LastName = Config.LastName;
				User.Email = Config.Email;
				User.Gender = Convert.ToChar(Config.Gender);
				User.PhoneNum = Config.PhoneNum;
				User.DOB = Config.DOB;
				User.PrivateToken = Config.DevicePrivateToken;
				User.AccountType = Config.AccountType;

				foreach (Device Device in DB.Query<Device>("SELECT * FROM Device"))
					User.Devices.Add(new Account.Device { PublicToken = Device.PublicToken, Name = Device.Name, PrivateToken = Device.PrivateToken });

				return User;
			}
			catch
			{
				return new Account.User();
			}
		}

		class Device
		{ 
			[PrimaryKey]
			public string PublicToken { get; set; }

			public string Name { get; set; }
			public string PrivateToken { get; set; }
		}
	}

	public static class StoreModules
	{ 
		
	}
}