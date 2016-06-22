using System.Linq;

using Plugin.CurrentActivity;
using Plugin.Geolocator;
using Plugin.ExternalMaps;
using Plugin.ExternalMaps.Abstractions;

using Android.Locations;

namespace PULSE
{
	public static class GeoMaps
	{
		public static Plugin.Geolocator.Abstractions.Position CurrentPosition { get; set; }
		public static Location CurrentLocation { get; set; }

		public static Plugin.Geolocator.Abstractions.Position FindPostion()
		{
			var Locator = CrossGeolocator.Current;

			Locator.DesiredAccuracy = 5;

			var Position = Locator.GetPositionAsync(5000);

			return Position.Result;
		}

		public static Location GetLocation()
		{
			Geocoder Geocoder = new Geocoder(CrossCurrentActivity.Current.Activity);
			Location Location;

			var Addresses = Geocoder.GetFromLocation(CurrentPosition.Latitude, CurrentPosition.Longitude, 1);
			var Address = Addresses.FirstOrDefault();

			Location = new Location 
			{ 
				AdminArea = Address.AdminArea,
				CountryCode = Address.CountryCode,
				CountryName = Address.CountryName,
				FeatureName = Address.FeatureName,
				StreetName = Address.Thoroughfare,
				PostCode = Address.PostalCode,
				Locality = Address.Locality,
				FullAddress = Address.FeatureName + "," + Address.Thoroughfare + "," + Address.AdminArea + "," + Address.CountryName + "," + Address.PostalCode
			};

			return Location;
		}

		public static void Navigate(string Name, string Street, string City, string State, string PostCode, string Country, string CountryCode, bool Walking)
		{
			if (Walking)
			{
				var success = CrossExternalMaps.Current.NavigateTo(Name, City, Street, State, PostCode, Country, CountryCode, NavigationType.Walking);
			}
			else
			{
				var success = CrossExternalMaps.Current.NavigateTo(Name, City, Street, State, PostCode, Country, CountryCode, NavigationType.Driving);
			}
		}

		public class Location
		{
			public string AdminArea { get; set; }
			public string CountryCode { get; set; }
			public string CountryName { get; set; }
			public string FeatureName { get; set; }
			public string StreetName { get; set; }
			public string PostCode { get; set; }
			public string Locality { get; set; }
			public string FullAddress { get; set; }
		}
	}
}

