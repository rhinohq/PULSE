// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionnaryExtensions.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the dictionnary extensions class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    ///     Class DictionnaryExtensions.
    /// </summary>
    internal static class DictionnaryExtensions
    {
        /// <summary>
        ///     Transform the dictionnary into URL parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1630:DocumentationTextMustContainWhitespace", Justification = "Reviewed. Suppression is OK here.")]
        public static string ToUrlParameters(this IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var array = parameters.Select(x => string.Format("{0}={1}", Uri.EscapeUriString(x.Key), Uri.EscapeUriString(x.Value))).ToArray();
            return string.Join("&", array);
        }
    }
}
