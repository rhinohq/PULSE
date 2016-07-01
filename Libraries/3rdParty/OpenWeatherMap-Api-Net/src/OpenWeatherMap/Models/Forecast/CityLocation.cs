// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CityLocation.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the city location class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class CityLocation.
    /// </summary>
    public sealed class CityLocation
    {
        /// <summary>
        ///     Gets or sets the altitude.
        /// </summary>
        /// <value>
        ///     The altitude.
        /// </value>
        [XmlAttribute("altitude")]
        public double Altitude { get; set; }

        /// <summary>
        ///     Gets or sets the latitude.
        /// </summary>
        /// <value>
        ///     The latitude.
        /// </value>
        [XmlAttribute("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        ///     Gets or sets the longitude.
        /// </summary>
        /// <value>
        ///     The longitude.
        /// </value>
        [XmlAttribute("longitude")]
        public double Longitude { get; set; }

        /// <summary>
        ///     Gets or sets the geo base.
        /// </summary>
        /// <value>
        ///     The geo base.
        /// </value>
        [XmlAttribute("geobase")]
        public string GeoBase { get; set; }

        /// <summary>
        ///     Gets or sets the geo base identifier.
        /// </summary>
        /// <value>
        ///     The geo base identifier.
        /// </value>
        [XmlAttribute("geobaseid")]
        public int GeoBaseId { get; set; }
    }
}
