// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICurrentWeatherClient.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Declares the ICurrentWeatherClient interface</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Threading.Tasks;

    /// <summary>
    ///     Interface ICurrentWeatherClient.
    /// </summary>
    public interface ICurrentWeatherClient
    {
        /// <summary>
        ///     Gets Current weather by city name.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        /// <param name="metric">  The metric system.</param>
        /// <param name="language">The language.</param>
        /// <returns>
        ///     Task {CurrentWeatherResponse}.
        /// </returns>
        Task<CurrentWeatherResponse> GetByName(string cityName, MetricSystem metric = MetricSystem.Internal, OpenWeatherMapLanguage language = OpenWeatherMapLanguage.EN);

        /// <summary>
        ///     Gets Current weather by coordinates.
        /// </summary>
        /// <param name="coordinates">The coordinates.</param>
        /// <param name="metric">     The metric system.</param>
        /// <param name="language">   The language.</param>
        /// <returns>
        ///     Task {CurrentWeatherResponse}.
        /// </returns>
        Task<CurrentWeatherResponse> GetByCoordinates(Coordinates coordinates, MetricSystem metric = MetricSystem.Internal, OpenWeatherMapLanguage language = OpenWeatherMapLanguage.EN);

        /// <summary>
        ///     Gets Current weather by city identifier.
        /// </summary>
        /// <param name="cityId">  The city identifier.</param>
        /// <param name="metric">  The metric.</param>
        /// <param name="language">The language.</param>
        /// <returns>
        ///     Task {CurrentWeatherResponse}.
        /// </returns>
        Task<CurrentWeatherResponse> GetByCityId(int cityId, MetricSystem metric = MetricSystem.Internal, OpenWeatherMapLanguage language = OpenWeatherMapLanguage.EN);
    }
}
