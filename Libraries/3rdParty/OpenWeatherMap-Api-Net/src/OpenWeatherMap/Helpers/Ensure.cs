// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ensure.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the ensure class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System;

    /// <summary>
    ///     Class Ensure.
    /// </summary>
    internal static class Ensure
    {
        /// <summary>
        ///     Ensure that the Argument value is not null.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
        /// <param name="value">The value.</param>
        /// <param name="name"> The name.</param>
        public static void ArgumentNotNull(object value, string name)
        {
            if (value != null)
            {
                return;
            }

            throw new ArgumentNullException(name);
        }

        /// <summary>
        ///     Ensure that the string value is not null or empty .
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when one or more arguments have unsupported or
        ///     illegal values.</exception>
        /// <param name="value">The value.</param>
        /// <param name="name"> The name.</param>
        public static void ArgumentNotNullOrEmptyString(string value, string name)
        {
            ArgumentNotNull(value, name);
            if (!string.IsNullOrEmpty(value))
            {
                return;
            }

            throw new ArgumentException("String cannot be empty", name);
        }
    }
}
