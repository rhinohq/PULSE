using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenWeatherMap.Tests
{
    [TestClass]
    public class CurrentWeatherClientTests : OpenWeatherMapTestsBase
    {
        [TestMethod]
        public async Task Can_Get_CurrentWeather_By_City_Name()
        {
            var result = await OpenWeatherMapTestClient.CurrentWeather.GetByName(CityName);
            TestAllProperties(result);
            Assert.AreEqual(CityName, result.City.Name);
        }

        [TestMethod]
        public async Task Can_Get_CurrentWeather_By_City_Name_MetricSystem()
        {
            var result = await OpenWeatherMapTestClient.CurrentWeather.GetByName(CityName, MetricSystem.Metric);
            TestAllProperties(result);
            Assert.AreEqual(CityName, result.City.Name);
            Assert.AreEqual(Metric, result.Temperature.Unit);
        }

        [TestMethod]
        public async Task Can_Get_CurrentWeather_By_City_Name_MetricSystem_Language()
        {
            var resultIt = await OpenWeatherMapTestClient.CurrentWeather.GetByName(CityName, MetricSystem.Metric, OpenWeatherMapLanguage.IT);
            var resultFr = await OpenWeatherMapTestClient.CurrentWeather.GetByName(CityName, MetricSystem.Metric, OpenWeatherMapLanguage.FR);
            TestAllProperties(resultIt);
            TestAllProperties(resultFr);
            Assert.AreEqual(CityName, resultIt.City.Name);
            Assert.AreEqual(CityName, resultFr.City.Name);
            Assert.AreEqual(Metric, resultIt.Temperature.Unit);
            Assert.AreEqual(Metric, resultFr.Temperature.Unit);
            Assert.AreNotEqual(resultFr.Weather.Value, resultIt.Weather.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(OpenWeatherMapException))]
        public async Task Can_Get_CurrentWeather_By_City_Name_Exception()
        {
            var result = await OpenWeatherMapTestClient.CurrentWeather.GetByName("abcdefgh");
        }

        [TestMethod]
        public async Task Can_Get_CurrentWeather_By_City_Coordinates()
        {
            var result = await OpenWeatherMapTestClient.CurrentWeather.GetByCoordinates(new Coordinates { Latitude = Latitude, Longitude = Longitude });
            TestAllProperties(result);
            Assert.AreEqual(Latitude, result.City.Coordinates.Latitude);
            Assert.AreEqual(Longitude, result.City.Coordinates.Longitude);
        }

        [TestMethod]
        public async Task Can_Get_CurrentWeather_By_City_Coordinates_MetricSystem()
        {
            var result = await OpenWeatherMapTestClient.CurrentWeather.GetByCoordinates(
                new Coordinates { Latitude = Latitude, Longitude = Longitude },
                MetricSystem.Metric);
            TestAllProperties(result);
            Assert.AreEqual(Latitude, result.City.Coordinates.Latitude);
            Assert.AreEqual(Longitude, result.City.Coordinates.Longitude);
            Assert.AreEqual(Metric, result.Temperature.Unit);
        }

        [TestMethod]
        public async Task Can_Get_CurrentWeather_By_City_Coordinates_MetricSystem_Language()
        {
            var resultIt = await OpenWeatherMapTestClient.CurrentWeather.GetByCoordinates(
                new Coordinates { Latitude = Latitude, Longitude = Longitude },
                MetricSystem.Metric,
                OpenWeatherMapLanguage.IT);

            var resultFr = await OpenWeatherMapTestClient.CurrentWeather.GetByCoordinates(
                new Coordinates { Latitude = Latitude, Longitude = Longitude },
                MetricSystem.Metric,
                OpenWeatherMapLanguage.FR);

            TestAllProperties(resultIt);
            TestAllProperties(resultFr);
            Assert.AreEqual(Latitude, resultIt.City.Coordinates.Latitude);
            Assert.AreEqual(Latitude, resultFr.City.Coordinates.Latitude);
            Assert.AreEqual(Longitude, resultIt.City.Coordinates.Longitude);
            Assert.AreEqual(Longitude, resultFr.City.Coordinates.Longitude);
            Assert.AreEqual(Metric, resultIt.Temperature.Unit);
            Assert.AreEqual(Metric, resultFr.Temperature.Unit);
            Assert.AreNotEqual(resultFr.Weather.Value, resultIt.Weather.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(OpenWeatherMapException))]
        public async Task Can_Get_CurrentWeather_By_Coordinates_Exception()
        {
            var result = await OpenWeatherMapTestClient.CurrentWeather.GetByCoordinates(
                new Coordinates { Latitude = -9999, Longitude = -9999 });
        }

        [TestMethod]
        public async Task Can_Get_CurrentWeather_By_City_Id()
        {
            var result = await OpenWeatherMapTestClient.CurrentWeather.GetByCityId(CityId);
            TestAllProperties(result);
            Assert.AreEqual(CityId, result.City.Id);
        }

        [TestMethod]
        public async Task Can_Get_CurrentWeather_By_City_Id_MetricSystem()
        {
            var result = await OpenWeatherMapTestClient.CurrentWeather.GetByCityId(CityId, MetricSystem.Metric);
            TestAllProperties(result);
            Assert.AreEqual(CityId, result.City.Id);
            Assert.AreEqual(Metric, result.Temperature.Unit);
        }

        [TestMethod]
        public async Task Can_Get_CurrentWeather_By_City_Id_MetricSystem_Language()
        {
            var resultIt = await OpenWeatherMapTestClient.CurrentWeather.GetByCityId(CityId, MetricSystem.Metric, OpenWeatherMapLanguage.IT);
            var resultFr = await OpenWeatherMapTestClient.CurrentWeather.GetByCityId(CityId, MetricSystem.Metric, OpenWeatherMapLanguage.FR);
            TestAllProperties(resultIt);
            TestAllProperties(resultFr);
            Assert.AreEqual(CityId, resultIt.City.Id);
            Assert.AreEqual(CityId, resultFr.City.Id);
            Assert.AreEqual(Metric, resultIt.Temperature.Unit);
            Assert.AreEqual(Metric, resultFr.Temperature.Unit);
            Assert.AreNotEqual(resultFr.Weather.Value, resultIt.Weather.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(OpenWeatherMapException))]
        public async Task Can_Get_CurrentWeather_By_City_Id_Exception()
        {
            var result = await OpenWeatherMapTestClient.CurrentWeather.GetByCityId(-123);
        }

        public void TestAllProperties(CurrentWeatherResponse response)
        {
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.City);
            Assert.IsNotNull(response.Clouds);
            Assert.IsNotNull(response.Humidity);
            Assert.IsNotNull(response.LastUpdate);
            Assert.IsNotNull(response.Precipitation);
            Assert.IsNotNull(response.Pressure);
            Assert.IsNotNull(response.Temperature);
            Assert.IsNotNull(response.Weather);
            Assert.IsNotNull(response.Wind);
        }
    }
}
