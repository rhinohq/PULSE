// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOpenWeatherMapClient.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Declares the IOpenWeatherMapClient interface</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    /// <summary>
    ///     Interface IOpenWeatherMapClient.
    /// </summary>
    internal interface IOpenWeatherMapClient
    {
        /// <summary>
        ///     Gets or sets the application identifier.
        /// </summary>
        /// <value>
        ///     The application identifier.
        /// </value>
        string AppId { get; set; }

        /// <summary>
        ///     Gets the current weather client.
        /// </summary>
        /// <value>
        ///     The current weather.
        /// </value>
        ICurrentWeatherClient CurrentWeather { get; }

        /// <summary>
        ///     Gets the forecast client.
        /// </summary>
        /// <value>
        ///     The forecast.
        /// </value>
        IForecastClient Forecast { get; }

        /// <summary>
        ///     Gets the search client.
        /// </summary>
        /// <value>
        ///     The search.
        /// </value>
        ISearchClient Search { get; }
    }
}
