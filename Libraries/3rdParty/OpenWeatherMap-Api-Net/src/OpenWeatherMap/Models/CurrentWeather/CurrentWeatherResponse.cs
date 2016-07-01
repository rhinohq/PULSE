// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentWeatherResponse.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the current weather response class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class CurrentWeatherResponse.
    /// </summary>
    /// <seealso cref="T:OpenWeatherMap.WeatherItem"/>
    [XmlRoot("current", Namespace = "")]
    public sealed class CurrentWeatherResponse : WeatherItem
    {
    }
}
