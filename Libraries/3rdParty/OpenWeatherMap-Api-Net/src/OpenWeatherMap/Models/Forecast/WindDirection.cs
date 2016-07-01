// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindDirection.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the wind direction class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class WindDirection.
    /// </summary>
    public sealed class WindDirection
    {
        /// <summary>
        ///     Gets or sets the degrees.
        /// </summary>
        /// <value>
        ///     The deg.
        /// </value>
        [XmlAttribute("deg")]
        public double Deg { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>
        ///     The code.
        /// </value>
        [XmlAttribute("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
