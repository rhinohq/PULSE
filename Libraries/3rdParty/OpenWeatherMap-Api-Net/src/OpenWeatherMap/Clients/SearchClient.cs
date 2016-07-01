// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchClient.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the search client class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System.Threading.Tasks;

    /// <summary>
    ///     Class SearchClient.
    /// </summary>
    /// <seealso cref="T:OpenWeatherMap.ApiClientBase"/>
    /// <seealso cref="T:OpenWeatherMap.ISearchClient"/>
    internal sealed class SearchClient : ApiClientBase, ISearchClient
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SearchClient"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public SearchClient(IOpenWeatherMapRequest request)
            : base(request, "find")
        {
        }

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
        /// <seealso cref="M:OpenWeatherMap.ISearchClient.GetByName(string,MetricSystem,OpenWeatherMapLanguage,int?,Accuracy?)"/>
        public Task<SearchResponse> GetByName(string cityName, MetricSystem metric = MetricSystem.Internal, OpenWeatherMapLanguage language = OpenWeatherMapLanguage.EN, int? count = null, Accuracy? accuracy = null)
        {
            return this.GetByName<SearchResponse>(cityName, metric, language, count, accuracy);
        }

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
        /// <seealso cref="M:OpenWeatherMap.ISearchClient.GetByCoordinates(Coordinates,MetricSystem,OpenWeatherMapLanguage,int?,Accuracy?)"/>
        public Task<SearchResponse> GetByCoordinates(Coordinates coordinates, MetricSystem metric = MetricSystem.Internal, OpenWeatherMapLanguage language = OpenWeatherMapLanguage.EN, int? count = null, Accuracy? accuracy = null)
        {
            return this.GetByCoordinates<SearchResponse>(coordinates, metric, language, count, accuracy);
        }
    }
}
