// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IApiClientBase.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Declares the IApiClientBase interface</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    /// <summary>
    ///     Interface IApiClientBase.
    /// </summary>
    internal interface IApiClientBase
    {
        /// <summary>
        ///     Gets or sets the request.
        /// </summary>
        /// <value>
        ///     The request.
        /// </value>
        IOpenWeatherMapRequest Request { get; set; }
    }
}
