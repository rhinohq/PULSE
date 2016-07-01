// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForecastClouds.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the forecast clouds class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class ForecastClouds.
    /// </summary>
    public sealed class ForecastClouds
    {
        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        [XmlAttribute("value")]
        public string Value { get; set; }

        /// <summary>
        ///     Gets or sets all value.
        /// </summary>
        /// <value>
        ///     All .
        /// </value>
        [XmlAttribute("all")]
        public int All { get; set; }

        /// <summary>
        ///     Gets or sets the unit.
        /// </summary>
        /// <value>
        ///     The unit.
        /// </value>
        [XmlAttribute("unit")]
        public string Unit { get; set; }
    }
}
