// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenWeatherMapRequest.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the open weather map request class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    /// <summary>
    ///     Class OpenWeatherMapRequest.
    /// </summary>
    /// <seealso cref="T:OpenWeatherMap.IOpenWeatherMapRequest"/>
    internal sealed class OpenWeatherMapRequest : IOpenWeatherMapRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OpenWeatherMapRequest"/> class.
        /// </summary>
        /// <param name="uri">       The URI.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="appId">     The application identifier.</param>
        public OpenWeatherMapRequest(Uri uri, HttpClient httpClient, string appId)
        {
            Ensure.ArgumentNotNull(uri, "uri");
            Ensure.ArgumentNotNull(httpClient, "httpClient");

            this.Uri = uri;
            this.HttpClient = httpClient;
            this.Parameters = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(appId))
            {
                this.AppId = appId;
                this.Parameters.Add("APPID", appId);
            }
        }

        /// <summary>
        ///     Gets or sets the URI.
        /// </summary>
        /// <value>
        ///     The URI.
        /// </value>
        /// <seealso cref="P:OpenWeatherMap.IOpenWeatherMapRequest.Uri"/>
        public Uri Uri { get; set; }

        /// <summary>
        ///     Gets or sets the application identifier.
        /// </summary>
        /// <value>
        ///     The application identifier.
        /// </value>
        /// <seealso cref="P:OpenWeatherMap.IOpenWeatherMapRequest.AppId"/>
        public string AppId { get; set; }

        /// <summary>
        ///     Gets or sets the querystring parameters.
        /// </summary>
        /// <value>
        ///     The parameters.
        /// </value>
        /// <seealso cref="P:OpenWeatherMap.IOpenWeatherMapRequest.Parameters"/>
        public IDictionary<string, string> Parameters { get; set; }

        /// <summary>
        ///     Gets or sets the HTTP client.
        /// </summary>
        /// <value>
        ///     The HTTP client.
        /// </value>
        /// <seealso cref="P:OpenWeatherMap.IOpenWeatherMapRequest.HttpClient"/>
        public HttpClient HttpClient { get; set; }

        /// <summary>
        ///     Gets or sets the request.
        /// </summary>
        /// <value>
        ///     The request.
        /// </value>
        /// <seealso cref="P:OpenWeatherMap.IOpenWeatherMapRequest.Request"/>
        public HttpRequestMessage Request { get; set; }
    }
}
