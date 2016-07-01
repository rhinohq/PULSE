// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForecastResponse.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the forecast response class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class ForecastResponse.
    /// </summary>
    /// <seealso cref="T:OpenWeatherMap.ForecastData"/>
    [XmlRoot("weatherdata", Namespace = "")]
    public sealed class ForecastResponse : ForecastData
    {
    }
}
