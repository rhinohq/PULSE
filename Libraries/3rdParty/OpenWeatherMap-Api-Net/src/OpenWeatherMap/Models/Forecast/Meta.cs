// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Meta.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the meta class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class Meta.
    /// </summary>
    public sealed class Meta
    {
        /// <summary>
        ///     Gets or sets the last update.
        /// </summary>
        /// <value>
        ///     The last update.
        /// </value>
        [XmlElement("lastupdate")]
        public string LastUpdate { get; set; }

        /// <summary>
        ///     Gets or sets the calculation time.
        /// </summary>
        /// <value>
        ///     The calculation time.
        /// </value>
        [XmlElement("calctime")]
        public double CalcTime { get; set; }

        /// <summary>
        ///     Gets or sets the next update.
        /// </summary>
        /// <value>
        ///     The next update.
        /// </value>
        [XmlElement("nextupdate")]
        public string NextUpdate { get; set; }
    }
}
