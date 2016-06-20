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

		private class User
		{ 
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