// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForecastData.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the forecast data class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class ForecastData.
    /// </summary>
    public class ForecastData
    {
        /// <summary>
        ///     Gets or sets the location.
        /// </summary>
        /// <value>
        ///     The location.
        /// </value>
        [XmlElement("location")]
        public Location Location { get; set; }

        /// <summary>
        ///     Gets or sets the meta.
        /// </summary>
        /// <value>
        ///     The meta.
        /// </value>
        [XmlElement("meta")]
        public Meta Meta { get; set; }

        /// <summary>
        ///     Gets or sets the sun.
        /// </summary>
        /// <value>
        ///     The sun.
        /// </value>
        [XmlElement("sun")]
        public Sun Sun { get; set; }

        /// <summary>
        ///     Gets or sets the forecast.
        /// </summary>
        /// <value>
        ///     The forecast.
        /// </value>
        [XmlArray("forecast")]
        [XmlArrayItem("time", Type = typeof(ForecastTime))]
        public ForecastTime[] Forecast { get; set; }
    }
}
