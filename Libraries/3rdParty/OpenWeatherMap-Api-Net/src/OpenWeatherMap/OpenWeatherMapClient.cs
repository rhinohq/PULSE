// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenWeatherMapClient.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the open weather map client class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System;
    using System.Net.Http;

    /// <summary>
    ///     Class OpenWeatherMapClient.
    /// </summary>
    /// <seealso cref="T:OpenWeatherMap.IOpenWeatherMapClient"/>
    public sealed class OpenWeatherMapClient : IOpenWeatherMapClient
    {

        /// <summary>
        ///     The open weather map URL.
        /// </summary>
        private static readonly Uri OpenWeatherMapUrl = new Uri("http://api.openweathermap.org/data/2.5");

        /// <summary>
        ///     Gets or sets the application identifier.
        /// </summary>
        /// <value>
        ///     The application identifier.
        /// </value>
        /// <seealso cref="P:OpenWeatherMap.IOpenWeatherMapClient.AppId"/>
        public string AppId { get; set; }

        /// <summary>
        ///     Gets the current weather client.
        /// </summary>
        /// <value>
        ///     The current weather.
        /// </value>
        /// <seealso cref="P:OpenWeatherMap.IOpenWeatherMapClient.CurrentWeather"/>
        public ICurrentWeatherClient CurrentWeather
        {
            get
            {
                return new CurrentWeatherClient(new OpenWeatherMapRequest(OpenWeatherMapUrl, this.HttpClient, this.AppId));
            }
        }

        /// <summary>
        ///     Gets the forecast client.
        /// </summary>
        /// <value>
        ///     The forecast.
        /// </value>
        /// <seealso cref="P:OpenWeatherMap.IOpenWeatherMapClient.Forecast"/>
        public IForecastClient Forecast
        {
            get
            {
                return new ForecastClient(new OpenWeatherMapRequest(OpenWeatherMapUrl, this.HttpClient, this.AppId));
            }
        }

        /// <summary>
        ///     Gets the search client.
        /// </summary>
        /// <value>
        ///     The search.
        /// </value>
        /// <seealso cref="P:OpenWeatherMap.IOpenWeatherMapClient.Search"/>
        public ISearchClient Search
        {
            get
            {
                return new SearchClient(new OpenWeatherMapRequest(OpenWeatherMapUrl, this.HttpClient, this.AppId));
            }
        }

        /// <summary>
        ///     Gets or sets the HTTP client.
        /// </summary>
        /// <value>
        ///     The HTTP client.
        /// </value>
        private HttpClient HttpClient { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="OpenWeatherMapClient"/> class.
        /// </summary>
        /// <param name="appId">             The application identifier.</param>
        /// <param name="httpMessageHandler">The HTTP message handler.</param>
        public OpenWeatherMapClient(string appId = null, HttpMessageHandler httpMessageHandler = null)
        {
            if (httpMessageHandler == null)
            {
                httpMessageHandler = new HttpClientHandler();
            }

            this.HttpClient = new HttpClient(httpMessageHandler);
            this.AppId = appId;
        }
    }
}
