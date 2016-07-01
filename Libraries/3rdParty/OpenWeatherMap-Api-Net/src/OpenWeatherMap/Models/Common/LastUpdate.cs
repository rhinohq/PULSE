// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LastUpdate.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the last update class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    ///     Class LastUpdate.
    /// </summary>
    public sealed class LastUpdate
    {
        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        [XmlAttribute("value")]
        public DateTime Value { get; set; }
    }
}
