// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="HasExtraPropertiesExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Globalization;
using Noob.Reflection;

namespace Noob.Data
{
    /// <summary>
    /// Class HasExtraPropertiesExtensions.
    /// </summary>
    public static class HasExtraPropertiesExtensions
    {
        /// <summary>
        /// Determines whether the specified name has property.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> if the specified name has property; otherwise, <c>false</c>.</returns>
        public static bool HasProperty(this IHasExtraProperties source, string name)
        {
            return source.ExtraProperties.ContainsKey(name);
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="name">The name.</param>
        /// <returns>System.Object.</returns>
        public static object GetProperty(this IHasExtraProperties source, string name)
        {
            return source.ExtraProperties?.GetOrDefault(name);
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="name">The name.</param>
        /// <returns>TProperty.</returns>
        /// <exception cref="AbpException">GetProperty<TProperty> does not support non-primitive types. Use non-generic GetProperty method and handle type casting manually.</exception>
        public static TProperty GetProperty<TProperty>(this IHasExtraProperties source, string name)
        {
            var value = source.GetProperty(name);
            if (value == default)
            {
                return default;
            }

            if (TypeHelper.IsPrimitiveExtended(typeof(TProperty), includeEnums: true))
            {
                return (TProperty)Convert.ChangeType(value, typeof(TProperty), CultureInfo.InvariantCulture);
            }

            throw new Exception("GetProperty<TProperty> does not support non-primitive types. Use non-generic GetProperty method and handle type casting manually.");
        }

        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns>TSource.</returns>
        public static TSource SetProperty<TSource>(this TSource source, string name, object value)
            where TSource : IHasExtraProperties
        {
            source.ExtraProperties[name] = value;
            return source;
        }

        /// <summary>
        /// Removes the property.
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="name">The name.</param>
        /// <returns>TSource.</returns>
        public static TSource RemoveProperty<TSource>(this TSource source, string name)
            where TSource : IHasExtraProperties
        {
            source.ExtraProperties.Remove(name);
            return source;
        }
    }
}