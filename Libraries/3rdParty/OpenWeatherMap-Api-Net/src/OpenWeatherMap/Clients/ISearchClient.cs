// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISearchClient.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Declares the ISearchClient interface</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Threading.Tasks;

    /// <summary>
    ///     Interface ISearchClient.
    /// </summary>
    public interface ISearchClient
    {
        /// <summary>
        ///     Search by city name.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        /// <param name="metric">  The metric.</param>
        /// <param name="language">The language.</param>
        /// <param name="count">   The count.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns>
        ///     Task {SearchResponse}.
        /// </returns>
        Task<SearchResponse> GetByName(string cityName, MetricSystem metric = MetricSystem.Internal, OpenWeatherMapLanguage language = OpenWeatherMapLanguage.EN, int? count = null, Accuracy? accuracy = null);

        /// <summary>
        ///     Search by coordinates.
        /// </summary>
        /// <param name="coordinates">The coordinates.</param>
        /// <param name="metric">     The metric.</param>
        /// <param name="language">   The language.</param>
        /// <param name="count">      The count.</param>
        /// <param name="accuracy">   The accuracy.</param>
        /// <returns>
        ///     Task {SearchResponse}.
        /// </returns>
        Task<SearchResponse> GetByCoordinates(Coordinates coordinates, MetricSystem metric = MetricSystem.Internal, OpenWeatherMapLanguage language = OpenWeatherMapLanguage.EN, int? count = null, Accuracy? accuracy = null);
    }
}
