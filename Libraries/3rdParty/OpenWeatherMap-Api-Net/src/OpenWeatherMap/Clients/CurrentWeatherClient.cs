// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentWeatherClient.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the current weather client class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Threading.Tasks;

    /// <summary>
    ///     Class CurrentWeatherClient.
    /// </summary>
    /// <seealso cref="T:OpenWeatherMap.ApiClientBase"/>
    /// <seealso cref="T:OpenWeatherMap.ICurrentWeatherClient"/>
    internal sealed class CurrentWeatherClient : ApiClientBase, ICurrentWeatherClient
    {
        /// <summary>
        ///     Initializes a new instance of the OpenWeatherMap.CurrentWeatherClient class.
        /// </summary>
        /// <param name="request">The request.</param>
        internal CurrentWeatherClient(IOpenWeatherMapRequest request)
            : base(request, "weather")
        {
        }

        /// <summary>
        ///     Gets Current weather by city name.
        /// </summary>
        /// <param name="cityName">The city Name.</param>
        /// <param name="metric">  The metric.</param>
        /// <param name="language">The language.</param>
        /// <returns>
        ///     The <see cref="Task"/>.
        /// </returns>
        /// <seealso cref="M:OpenWeatherMap.ICurrentWeatherClient.GetByName(string,MetricSystem,OpenWeatherMapLanguage)"/>
        public Task<CurrentWeatherResponse> GetByName(string cityName, MetricSystem metric = MetricSystem.Internal, OpenWeatherMapLanguage language = OpenWeatherMapLanguage.EN)
        {
            return this.GetByName<CurrentWeatherResponse>(cityName, metric, language, null, null);
        }

        /// <summary>
        ///     Gets Current weather by coordinates.
        /// </summary>
        /// <param name="coordinates">The coordinates.</param>
        /// <param name="metric">     The metric system.</param>
        /// <param name="language">   The language.</param>
        /// <returns>
        ///     Task {CurrentWeatherResponse}.
        /// </returns>
        /// <seealso cref="M:OpenWeatherMap.ICurrentWeatherClient.GetByCoordinates(Coordinates,MetricSystem,OpenWeatherMapLanguage)"/>
        public Task<CurrentWeatherResponse> GetByCoordinates(Coordinates coordinates, MetricSystem metric = MetricSystem.Internal, OpenWeatherMapLanguage language = OpenWeatherMapLanguage.EN)
        {
            return this.GetByCoordinates<CurrentWeatherResponse>(coordinates, metric, language, null, null);
        }

        /// <summary>
        ///     Gets Current weather by city identifier.
        /// </summary>
        /// <param name="cityId">  The city identifier.</param>
        /// <param name="metric">  The metric.</param>
        /// <param name="language">The language.</param>
        /// <returns>
        ///     The by city identifier.
        /// </returns>
        /// <seealso cref="M:OpenWeatherMap.ICurrentWeatherClient.GetByCityId(int,MetricSystem,OpenWeatherMapLanguage)"/>
        public Task<CurrentWeatherResponse> GetByCityId(int cityId, MetricSystem metric = MetricSystem.Internal, OpenWeatherMapLanguage language = OpenWeatherMapLanguage.EN)
        {
            return this.GetByCityId<CurrentWeatherResponse>(cityId, metric, language, null);
        }
    }
}
