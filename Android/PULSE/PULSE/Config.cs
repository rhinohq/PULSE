using System;
using System.IO;
using System.Xml;

using AuthenticationLib;

namespace PULSE
{
	public static class Config
	{
		static XmlDocument ConfigFile { get; set; }

		public static void CreateConfig()
		{
			ConfigFile = new XmlDocument();

			XmlDeclaration Declaration = ConfigFile.CreateXmlDeclaration("1.0", "UTF-8", null);
			ConfigFile.InsertBefore(Declaration, ConfigFile.DocumentElement);

			XmlElement Root = ConfigFile.CreateElement(string.Empty, "PULSEConfig", string.Empty);
			ConfigFile.AppendChild(Root);

			XmlElement PubTok = ConfigFile.CreateElement(string.Empty, "DevicePublicToken", string.Empty);
			XmlText PubTokText = ConfigFile.CreateTextNode(Account.CreatePublicToken(Android.OS.Build.Model));
			PubTok.AppendChild(PubTokText);
			Root.AppendChild(PubTok);

			XmlElement PriTok = ConfigFile.CreateElement(string.Empty, "DevicePrivateToken", string.Empty);
			Root.AppendChild(PriTok);

			XmlElement Username = ConfigFile.CreateElement(string.Empty, "Username", string.Empty);
			Root.AppendChild(Username);

			XmlElement FirstName = ConfigFile.CreateElement(string.Empty, "FirstName", string.Empty);
			Root.AppendChild(FirstName);

			XmlElement LastName = ConfigFile.CreateElement(string.Empty, "LastName", string.Empty);
			Root.AppendChild(LastName);

			XmlElement Email = ConfigFile.CreateElement(string.Empty, "Email", string.Empty);
			Root.AppendChild(Email);

			XmlElement Gender = ConfigFile.CreateElement(string.Empty, "Gender", string.Empty);
			Root.AppendChild(Gender);

			XmlElement PhoneNum = ConfigFile.CreateElement(string.Empty, "PhoneNumber", string.Empty);
			Root.AppendChild(PhoneNum);

			XmlElement DOB = ConfigFile.CreateElement(string.Empty, "DateOfBirth", string.Empty);
			Root.AppendChild(DOB);

			XmlElement AccountType = ConfigFile.CreateElement(string.Empty, "AccountType", string.Empty);
			Root.AppendChild(AccountType);

			ConfigFile.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PULSEConfig.xml"));
		}

		public static void GetConfig()
		{
			ConfigFile.Load(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PULSEConfig.xml"));
		}

		public static string GetNodeValue(string NodePath)
		{
			return ConfigFile.SelectSingleNode(NodePath).Value;
		}

		public static void SetNodeValue(string NodePath, string Value)
		{ 
			ConfigFile.SelectSingleNode(NodePath).Value = Value;

			ConfigFile.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PULSEConfig.xml"));
		}

		public static string DevicePublicToken
		{ 
			get
			{
				return GetNodeValue("/PULSEConfig/DevicePublicToken");
			}
		}

		public static string DevicePrivateToken
		{ 
			get
			{
				return Authentication.Cryptography.Decrypt(GetNodeValue("/PULSEConfig/DevicePrivateToken"), DevicePublicToken);
			}
			set
			{
				SetNodeValue("/PULSEConfig/DevicePrivateToken", Authentication.Cryptography.Encrypt(value, DevicePublicToken));
			}
		}

		public static string Username
		{
			get
			{
				return GetNodeValue("/PULSEConfig/Username");
			}
			set
			{
				SetNodeValue("/PULSEConfig/Username", value);
			}
		}

		public static string FirstName
		{
			get
			{
				return GetNodeValue("/PULSEConfig/FirstName");
			}
			set
			{
				SetNodeValue("/PULSEConfig/FirstName", value);
			}
		}

		public static string LastName
		{
			get
			{
				return GetNodeValue("/PULSEConfig/LastName");
			}
			set
			{
				SetNodeValue("/PULSEConfig/LastName", value);
			}
		}

		public static string Email
		{
			get
			{
				return GetNodeValue("/PULSEConfig/Email");
			}
			set
			{
				SetNodeValue("/PULSEConfig/Email", value);
			}
		}

		public static string Gender
		{
			get
			{
				return GetNodeValue("/PULSEConfig/Gender");
			}
			set
			{
				SetNodeValue("/PULSEConfig/Gender", value);
			}
		}

		public static string PhoneNum
		{
			get
			{
				return GetNodeValue("/PULSEConfig/PhoneNumber");
			}
			set
			{
				SetNodeValue("/PULSEConfig/PhoneNumber", value);
			}
		}

		public static string DOB
		{
			get
			{
				return GetNodeValue("/PULSEConfig/DateOfBirth");
			}
			set
			{
				SetNodeValue("/PULSEConfig/DateOfBirth", value);
			}
		}

		public static string AccountType
		{
			get
			{
				return GetNodeValue("/PULSEConfig/AccountType");
			}
			set
			{
				SetNodeValue("/PULSEConfig/AccountType", value);
			}
		}
	}
}
