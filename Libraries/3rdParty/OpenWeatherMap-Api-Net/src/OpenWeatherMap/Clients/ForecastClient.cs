// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForecastClient.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the forecast client class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Threading.Tasks;

    /// <summary>
    ///     Class ForecastClient.
    /// </summary>
    /// <seealso cref="T:OpenWeatherMap.ApiClientBase"/>
    /// <seealso cref="T:OpenWeatherMap.IForecastClient"/>
    internal sealed class ForecastClient : ApiClientBase, IForecastClient
    {
        /// <summary>
        ///     Initializes a new instance of the OpenWeatherMap.ForecastClient class.
        /// </summary>
        /// <param name="request">The request.</param>
        public ForecastClient(IOpenWeatherMapRequest request)
            : base(request, "forecast")
        {
        }

        /// <summary>
        ///     Gets Forecast by city name.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        /// <param name="daily">   if set to <c>true</c> [daily].</param>
        /// <param name="metric">  The metric.</param>
        /// <param name="language">The language.</param>
        /// <param name="count">   Number of results.</param>
        /// <returns>
        ///     Task {ForecastResponse}.
        /// </returns>
        /// <seealso cref="M:OpenWeatherMap.IForecastClient.GetByName(string,bool,MetricSystem,OpenWeatherMapLanguage,int?)"/>
        public Task<ForecastResponse> GetByName(string cityName, bool daily = false, MetricSystem metric = MetricSystem.Internal, OpenWeatherMapLanguage language = OpenWeatherMapLanguage.EN, int? count = null)
        {
            if (daily)
            {
                this.Request.Uri = this.Request.Uri.AddSegment("daily");
            }

            return this.GetByName<ForecastResponse>(cityName, metric, language, count, null);
        }

        /// <summary>
        ///     Gets Forecast by coordinates.
        /// </summary>
        /// <param name="coordinates">The coordinates.</param>
        /// <param name="daily">      if set to <c>true</c> [daily].</param>
        /// <param name="metric">     The metric.</param>
        /// <param name="language">   The language.</param>
        /// <param name="count">      The count.</param>
        /// <returns>
        ///     Task {ForecastResponse}.
        /// </returns>
        /// <seealso cref="M:OpenWeatherMap.IForecastClient.GetByCoordinates(Coordinates,bool,MetricSystem,OpenWeatherMapLanguage,int?)"/>
        public Task<ForecastResponse> GetByCoordinates(Coordinates coordinates, bool daily = false, MetricSystem metric = MetricSystem.Internal, OpenWeatherMapLanguage language = OpenWeatherMapLanguage.EN, int? count = null)
        {
            if (daily)
            {
                this.Request.Uri = this.Request.Uri.AddSegment("daily");
            }

            return this.GetByCoordinates<ForecastResponse>(coordinates, metric, language, count, null);
        }

        /// <summary>
        ///     Gets Forecast by city identifier.
        /// </summary>
        /// <param name="cityId">  The city identifier.</param>
        /// <param name="daily">   if set to <c>true</c> [daily].</param>
        /// <param name="metric">  The metric.</param>
        /// <param name="language">The language.</param>
        /// <param name="count">   The count.</param>
        /// <returns>
        ///     Task {ForecastResponse}.
        /// </returns>
        /// <seealso cref="M:OpenWeatherMap.IForecastClient.GetByCityId(int,bool,MetricSystem,OpenWeatherMapLanguage,int?)"/>
        public Task<ForecastResponse> GetByCityId(int cityId, bool daily = false, MetricSystem metric = MetricSystem.Internal, OpenWeatherMapLanguage language = OpenWeatherMapLanguage.EN, int? count = null)
        {
            if (daily)
            {
                this.Request.Uri = this.Request.Uri.AddSegment("daily");
            }

            return this.GetByCityId<ForecastResponse>(cityId, metric, language, count);
        }
    }
}
