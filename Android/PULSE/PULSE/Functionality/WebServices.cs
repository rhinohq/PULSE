using System;
using System.Net;

using OpenWeatherMap;

namespace PULSE
{
	public static class WebServices
	{
		public static class Weather
		{
			const string APIKey = "3a2662034eff4e3dbdd08173d256f063";
			const double KelvinConvert = 273.15;
			static OpenWeatherMapClient WeatherClient = new OpenWeatherMapClient(APIKey);
			static Coordinates Coord;

			public static Card GetWeatherOfCurrentLocation()
			{
				Coord.Latitude = GeoMaps.CurrentPosition.Latitude;
				Coord.Longitude = GeoMaps.CurrentPosition.Longitude;

				var CurrentWeather = WeatherClient.CurrentWeather.GetByCoordinates(Coord).Result;

				return new Card{
					TextToSpeak = "The weather for " + CurrentWeather.City.Name + " is " + CurrentWeather.Weather.Value + " with highs of " + (CurrentWeather.Temperature.Max - KelvinConvert) + "and lows of " + (CurrentWeather.Temperature.Min - KelvinConvert) + ".",
					CardTitle = "Weather"
				};
			}

			public static Card GetWeatherOfLocation(string CityName)
			{ 
				var CurrentWeather = WeatherClient.CurrentWeather.GetByName(CityName).Result;

				return new Card{
					TextToSpeak = "The weather for " + CurrentWeather.City.Name + " is " + CurrentWeather.Weather.Value + " with highs of " + (CurrentWeather.Temperature.Max - KelvinConvert) + "and lows of " + (CurrentWeather.Temperature.Min - KelvinConvert) + ".",
					CardTitle = "Weather"
				};
			}

			public static Card GetForecastForCurrentLocation()
			{ 
				Coord.Latitude = GeoMaps.CurrentPosition.Latitude;
				Coord.Longitude = GeoMaps.CurrentPosition.Longitude;

				var Forecast = WeatherClient.Forecast.GetByCoordinates(Coord).Result;

				return new Card{
					CardTitle = "Weather"
				};
			}

			public static Card GetForecastForLocation(string CityName)
			{ 
				var Forecast = WeatherClient.Forecast.GetByName(CityName).Result;

				return new Card{
					CardTitle = "Weather"
				};
			}
		}
	}
}

