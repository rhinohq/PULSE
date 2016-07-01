// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchResponse.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the search response class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class SearchResponse.
    /// </summary>
    /// <seealso cref="T:OpenWeatherMap.SearchResult"/>
    [XmlRoot("cities", Namespace = "")]
    public sealed class SearchResponse : SearchResult
    {
    }
}
