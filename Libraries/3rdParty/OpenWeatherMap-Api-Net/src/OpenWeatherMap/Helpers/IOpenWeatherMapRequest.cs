// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOpenWeatherMapRequest.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Declares the IOpenWeatherMapRequest interface</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    /// <summary>
    ///     Interface IOpenWeatherMapRequest.
    /// </summary>
    internal interface IOpenWeatherMapRequest
    {
        /// <summary>
        ///     Gets or sets the URI.
        /// </summary>
        /// <value>
        ///     The URI.
        /// </value>
        Uri Uri { get; set; }

        /// <summary>
        ///     Gets or sets the application identifier.
        /// </summary>
        /// <value>
        ///     The application identifier.
        /// </value>
        string AppId { get; set; }

        /// <summary>
        ///     Gets or sets the query string parameters.
        /// </summary>
        /// <value>
        ///     The parameters.
        /// </value>
        IDictionary<string, string> Parameters { get; set; }

        /// <summary>
        ///     Gets or sets the HTTP client.
        /// </summary>
        /// <value>
        ///     The HTTP client.
        /// </value>
        HttpClient HttpClient { get; set; }

        /// <summary>
        ///     Gets or sets the request.
        /// </summary>
        /// <value>
        ///     The request.
        /// </value>
        HttpRequestMessage Request { get; set; }
    }
}
