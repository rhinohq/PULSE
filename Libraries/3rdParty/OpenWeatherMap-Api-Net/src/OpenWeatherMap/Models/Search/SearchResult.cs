// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchResult.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the search result class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class SearchResult.
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        ///     Gets or sets the calculation time.
        /// </summary>
        /// <value>
        ///     The calculation time.
        /// </value>
        [XmlElement("calctime")]
        public double CalcTime { get; set; }

        /// <summary>
        ///     Gets or sets the result count.
        /// </summary>
        /// <value>
        ///     The count.
        /// </value>
        [XmlElement("count")]
        public int Count { get; set; }

        /// <summary>
        ///     Gets or sets the mode.
        /// </summary>
        /// <value>
        ///     The mode.
        /// </value>
        [XmlElement("mode")]
        public string Mode { get; set; }

        /// <summary>
        ///     Gets or sets the list.
        /// </summary>
        /// <value>
        ///     The list.
        /// </value>
        [XmlArray("list")]
        [XmlArrayItem("item", Type = typeof(WeatherItem))]
        public WeatherItem[] List { get; set; }
    }
}
