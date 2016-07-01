// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the string extensions class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///     Class StringExtensions.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        ///     encode string to be URL friendly.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1630:DocumentationTextMustContainWhitespace", Justification = "Reviewed. Suppression is OK here.")]
        public static string UrlEncode(this string input)
        {
            return Uri.EscapeDataString(input);
        }
    }
}
