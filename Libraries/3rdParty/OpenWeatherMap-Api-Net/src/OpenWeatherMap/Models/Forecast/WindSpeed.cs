// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindSpeed.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the wind speed class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class WindSpeed.
    /// </summary>
    public sealed class WindSpeed
    {
        /// <summary>
        ///     Gets or sets the speed (MPS).
        /// </summary>
        /// <value>
        ///     The MPS.
        /// </value>
        [XmlAttribute("mps")]
        public double Mps { get; set; }

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
