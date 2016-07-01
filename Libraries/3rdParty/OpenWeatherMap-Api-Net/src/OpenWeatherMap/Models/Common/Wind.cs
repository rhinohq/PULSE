// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Wind.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the wind class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class Wind.
    /// </summary>
    public class Wind
    {
        /// <summary>
        ///     Gets or sets the speed.
        /// </summary>
        /// <value>
        ///     The speed.
        /// </value>
        [XmlElement("speed")]
        public Speed Speed { get; set; }

        /// <summary>
        ///     Gets or sets the direction.
        /// </summary>
        /// <value>
        ///     The direction.
        /// </value>
        [XmlElement("direction")]
        public Direction Direction { get; set; }
    }
}
