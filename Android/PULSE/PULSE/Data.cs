using System.IO;

using SQLite;

namespace PULSE 
{
	public static class StoreAccount
	{
		static string DBPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "PULSE.db");

		public static void StoreUser(Account.User User)
		{ 
			SQLiteConnection DB = new SQLiteConnection(DBPath);

			DB.CreateTable<User>();
			DB.CreateTable<Device>();

			DB.Insert(new User
			{
				ID = 1,
				FirstName = User.FirstName,
				LastName = User.LastName,
				Username = User.Username,
				Email = User.Email,
				PhoneNum = User.PhoneNum,
				PasswordHash = User.PasswordHash
			});

			foreach (Account.Device Device in User.Devices)
			{
				DB.Insert(new Device 
				{ 
					PublicKey = Device.PublicKey
				});
			}
		}

		public static void DeleteDB()
		{ 
			SQLiteConnection DB = new SQLiteConnection(DBPath);

			DB.DeleteAll<User>();
			DB.DeleteAll<Device>();

			DB.Close();
		}

		public static Account.User GetUser()
		{ 
			SQLiteConnection DB = new SQLiteConnection(DBPath);
			Account.User User = new Account.User();

			User DBUser = DB.Get<User>(1);

			User.FirstName = DBUser.FirstName;
			User.LastName = DBUser.LastName;
			User.Username = DBUser.Username;
			User.Email = DBUser.Email;
			User.PhoneNum = DBUser.PasswordHash;

			foreach (Device Device in DB.Query<Device>("SELECT * FROM Device"))
				User.Devices.Add(new Account.Device { PublicKey = Device.PublicKey });

			return User;
		}

		private class User
		{ 
			[PrimaryKey]
			public int ID { get; set; }

			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string Username { get; set; }
			public string Email { get; set; }
			public string PhoneNum { get; set; }
			public string PasswordHash { get; set; }
		}

		private class Device
		{ 
			public string PublicKey { get; set; }
		}
	}
}