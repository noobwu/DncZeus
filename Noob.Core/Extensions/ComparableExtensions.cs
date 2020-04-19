// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ComparableExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace System
{
    /// <summary>
    /// Extension methods for <see cref="IComparable{T}" />.
    /// </summary>
    public static class ComparableExtensions
    {
        /// <summary>
        /// Checks a value is between a minimum and maximum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value to be checked</param>
        /// <param name="minInclusiveValue">Minimum (inclusive) value</param>
        /// <param name="maxInclusiveValue">Maximum (inclusive) value</param>
        /// <returns><c>true</c> if the specified minimum inclusive value is between; otherwise, <c>false</c>.</returns>
        public static bool IsBetween<T>(this T value, T minInclusiveValue, T maxInclusiveValue) where T : IComparable<T>
        {
            return value.CompareTo(minInclusiveValue) >= 0 && value.CompareTo(maxInclusiveValue) <= 0;
        }
    }
}