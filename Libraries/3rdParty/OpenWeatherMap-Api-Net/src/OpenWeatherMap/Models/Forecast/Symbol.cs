// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Symbol.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the symbol class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class Symbol (weather detail).
    /// </summary>
    public sealed class Symbol
    {
        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        /// <value>
        ///     The number.
        /// </value>
        [XmlAttribute("number")]
        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the variable.
        /// </summary>
        /// <value>
        ///     The variable.
        /// </value>
        [XmlAttribute("var")]
        public string Var { get; set; }
    }
}
