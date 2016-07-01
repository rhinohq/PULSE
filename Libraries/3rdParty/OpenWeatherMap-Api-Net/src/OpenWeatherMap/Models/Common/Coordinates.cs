// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Coordinates.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the coordinates class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class Coordinates.
    /// </summary>
    public struct Coordinates
    {
        /// <summary>
        ///     Gets or sets the longitude.
        /// </summary>
        /// <value>
        ///     The longitude.
        /// </value>
        [XmlAttribute("lon")]
        public double Longitude { get; set; }

        /// <summary>
        ///     Gets or sets the latitude.
        /// </summary>
        /// <value>
        ///     The latitude.
        /// </value>
        [XmlAttribute("lat")]
        public double Latitude { get; set; }
    }
}
