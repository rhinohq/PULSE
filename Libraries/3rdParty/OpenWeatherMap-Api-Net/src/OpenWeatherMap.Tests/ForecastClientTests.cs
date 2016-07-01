using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenWeatherMap.Tests
{
    [TestClass]
    public class ForecastClientTests : OpenWeatherMapTestsBase
    {
        [TestMethod]
        public async Task Can_Get_Forecast_By_City_Name()
        {
            var result = await OpenWeatherMapTestClient.Forecast.GetByName(CityName);
            TestAllProperties(result);
            Assert.AreEqual(CityName, result.Location.Name);
        }

        [TestMethod]
        public async Task Can_Get_Forecast_By_City_Name_MetricSystem()
        {
            var result = await OpenWeatherMapTestClient.Forecast.GetByName(CityName, false, MetricSystem.Metric);
            TestAllProperties(result);
            Assert.AreEqual(CityName, result.Location.Name);
            Assert.AreEqual(Metric, result.Forecast[0].Temperature.Unit);
        }

        [TestMethod]
        public async Task Can_Get_Forecast_By_City_Name_MetricSystem_Language()
        {
            var resultIt = await OpenWeatherMapTestClient.Forecast.GetByName(CityName, false, MetricSystem.Metric, OpenWeatherMapLanguage.IT);
            var resultFr = await OpenWeatherMapTestClient.Forecast.GetByName(CityName, false, MetricSystem.Metric, OpenWeatherMapLanguage.FR);
            TestAllProperties(resultIt);
            TestAllProperties(resultFr);
            Assert.AreEqual(CityName, resultIt.Location.Name);
            Assert.AreEqual(CityName, resultFr.Location.Name);
            Assert.AreEqual(Metric, resultIt.Forecast.First().Temperature.Unit);
            Assert.AreEqual(Metric, resultFr.Forecast.First().Temperature.Unit);
            Assert.AreNotEqual(resultFr.Forecast.First().Symbol.Name, resultIt.Forecast.First().Symbol.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(OpenWeatherMapException))]
        public async Task Can_Get_Forecast_By_City_Name_Exception()
        {
            var result = await OpenWeatherMapTestClient.Forecast.GetByName("abcdefgh");
        }

        [TestMethod]
        public async Task Can_Get_Forecast_By_City_Coordinates()
        {
            var result = await OpenWeatherMapTestClient.Forecast.GetByCoordinates(new Coordinates { Latitude = Latitude, Longitude = Longitude });
            TestAllProperties(result);
            //Latitude and longitude are not the same...
            //Assert.AreEqual(Latitude, result.Location.CityLocation.Latitude);
            //Assert.AreEqual(Longitude, result.Location.CityLocation.Longitude);
        }

        [TestMethod]
        public async Task Can_Get_Forecast_By_City_Coordinates_MetricSystem()
        {
            var result = await OpenWeatherMapTestClient.Forecast.GetByCoordinates(
                new Coordinates { Latitude = Latitude, Longitude = Longitude },
                false,
                MetricSystem.Metric);
            TestAllProperties(result);
            //Latitude and longitude are not the same...
            //Assert.AreEqual(Latitude, result.Location.CityLocation.Latitude);
            //Assert.AreEqual(Longitude, result.Location.CityLocation.Longitude);
            Assert.AreEqual(Metric, result.Forecast.First().Temperature.Unit);
        }

        [TestMethod]
        public async Task Can_Get_Forecast_By_City_Coordinates_MetricSystem_Language()
        {
            var resultIt = await OpenWeatherMapTestClient.Forecast.GetByCoordinates(
                new Coordinates { Latitude = Latitude, Longitude = Longitude },
                false,
                MetricSystem.Metric,
                OpenWeatherMapLanguage.IT);

            var resultFr = await OpenWeatherMapTestClient.Forecast.GetByCoordinates(
                new Coordinates { Latitude = Latitude, Longitude = Longitude },
                false,
                MetricSystem.Metric,
                OpenWeatherMapLanguage.FR);

            TestAllProperties(resultIt);
            TestAllProperties(resultFr);
            //Latitude and longitude are not the same...
            //Assert.AreEqual(Latitude, resultIt.Location.CityLocation.Latitude);
            //Assert.AreEqual(Latitude, resultFr.Location.CityLocation.Latitude);
            //Assert.AreEqual(Longitude, resultIt.Location.CityLocation.Longitude);
            //Assert.AreEqual(Longitude, resultFr.Location.CityLocation.Longitude);
            Assert.AreEqual(Metric, resultIt.Forecast.First().Temperature.Unit);
            Assert.AreEqual(Metric, resultFr.Forecast.First().Temperature.Unit);
            Assert.AreNotEqual(resultFr.Forecast.First().Symbol.Name, resultIt.Forecast[0].Symbol.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(OpenWeatherMapException))]
        public async Task Can_Get_Forecast_By_Coordinates_Exception()
        {
            var result = await OpenWeatherMapTestClient.Forecast.GetByCoordinates(
                new Coordinates { Latitude = -9999, Longitude = -9999 });
        }

        [TestMethod]
        public async Task Can_Get_Forecast_By_City_Id()
        {
            var result = await OpenWeatherMapTestClient.Forecast.GetByCityId(CityId);
            TestAllProperties(result);
            //No Id provided by api
        }

        [TestMethod]
        public async Task Can_Get_Forecast_By_City_Id_MetricSystem()
        {
            var result = await OpenWeatherMapTestClient.Forecast.GetByCityId(CityId, false, MetricSystem.Metric);
            TestAllProperties(result);
            Assert.AreEqual(Metric, result.Forecast.First().Temperature.Unit);
        }

        [TestMethod]
        public async Task Can_Get_CurrentWeather_By_City_Id_MetricSystem_Language()
        {
            var resultIt = await OpenWeatherMapTestClient.Forecast.GetByCityId(CityId, false, MetricSystem.Metric, OpenWeatherMapLanguage.IT);
            var resultFr = await OpenWeatherMapTestClient.Forecast.GetByCityId(CityId, false, MetricSystem.Metric, OpenWeatherMapLanguage.FR);
            TestAllProperties(resultIt);
            TestAllProperties(resultFr);
            Assert.AreEqual(Metric, resultIt.Forecast.First().Temperature.Unit);
            Assert.AreEqual(Metric, resultFr.Forecast.First().Temperature.Unit);
            Assert.AreNotEqual(resultFr.Forecast[0].Symbol.Name, resultIt.Forecast[0].Symbol.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(OpenWeatherMapException))]
        public async Task Can_Get_Forecast_By_City_Id_Exception()
        {
            var result = await OpenWeatherMapTestClient.CurrentWeather.GetByCityId(-123);
        }

        [TestMethod]
        public async Task Can_Get_Forecast_Daily()
        {
            var result = await OpenWeatherMapTestClient.Forecast.GetByName(CityName, true);
            TestAllProperties(result);
            Assert.AreEqual(CityName, result.Location.Name);
            Assert.IsTrue(result.Forecast.Count() == 7);
        }

        [TestMethod]
        public async Task Can_Get_Forecast_With_Count()
        {
            //Available only for daily queries
            var result = await OpenWeatherMapTestClient.Forecast.GetByName(CityName, true, MetricSystem.Internal, OpenWeatherMapLanguage.EN, 2);
            TestAllProperties(result);
            Assert.AreEqual(CityName, result.Location.Name);
            Assert.IsTrue(result.Forecast.Count() == 2);
        }

        public void TestAllProperties(ForecastResponse response)
        {
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Location);
            Assert.IsNotNull(response.Location.CityLocation);
            Assert.IsNotNull(response.Location.TimeZone);
            Assert.IsNotNull(response.Location.Type);
            Assert.IsNotNull(response.Meta);
            Assert.IsNotNull(response.Sun);
            Assert.IsNotNull(response.Forecast);
            Assert.IsTrue(response.Forecast.Any());
        }
    }
}
