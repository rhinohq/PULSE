// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Location.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the location class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class Location.
    /// </summary>
    public sealed class Location
    {
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        [XmlElement("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the country.
        /// </summary>
        /// <value>
        ///     The country.
        /// </value>
        [XmlElement("country")]
        public string Country { get; set; }

        /// <summary>
        ///     Gets or sets the time zone.
        /// </summary>
        /// <value>
        ///     The time zone.
        /// </value>
        [XmlElement("timezone")]
        public string TimeZone { get; set; }

        /// <summary>
        ///     Gets or sets the city location.
        /// </summary>
        /// <value>
        ///     The city location.
        /// </value>
        [XmlElement("location")]
        public CityLocation CityLocation { get; set; }
    }
}
