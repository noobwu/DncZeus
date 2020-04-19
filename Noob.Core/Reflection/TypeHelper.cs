// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="TypeHelper.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Reflection;

/// <summary>
/// The Reflection namespace.
/// </summary>
namespace Noob.Reflection
{
    /// <summary>
    /// Class TypeHelper.
    /// </summary>
    public static class TypeHelper
    {
        /// <summary>
        /// Determines whether the specified object is function.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns><c>true</c> if the specified object is function; otherwise, <c>false</c>.</returns>
        public static bool IsFunc(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var type = obj.GetType();
            if (!type.GetTypeInfo().IsGenericType)
            {
                return false;
            }

            return type.GetGenericTypeDefinition() == typeof(Func<>);
        }

        /// <summary>
        /// Determines whether the specified object is function.
        /// </summary>
        /// <typeparam name="TReturn">The type of the t return.</typeparam>
        /// <param name="obj">The object.</param>
        /// <returns><c>true</c> if the specified object is function; otherwise, <c>false</c>.</returns>
        public static bool IsFunc<TReturn>(object obj)
        {
            return obj != null && obj.GetType() == typeof(Func<TReturn>);
        }

        /// <summary>
        /// Determines whether [is primitive extended] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="includeNullables">if set to <c>true</c> [include nullables].</param>
        /// <param name="includeEnums">if set to <c>true</c> [include enums].</param>
        /// <returns><c>true</c> if [is primitive extended] [the specified type]; otherwise, <c>false</c>.</returns>
        public static bool IsPrimitiveExtended(Type type, bool includeNullables = true, bool includeEnums = false)
        {
            if (IsPrimitiveExtendedInternal(type, includeEnums))
            {
                return true;
            }

            if (includeNullables &&
                type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return IsPrimitiveExtendedInternal(type.GenericTypeArguments[0], includeEnums);
            }

            return false;
        }

        /// <summary>
        /// Gets the first generic argument if nullable.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns>Type.</returns>
        public static Type GetFirstGenericArgumentIfNullable(this Type t)
        {
            if (t.GetGenericArguments().Length > 0 && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return t.GetGenericArguments().FirstOrDefault();
            }

            return t;
        }

        /// <summary>
        /// Determines whether [is primitive extended internal] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="includeEnums">if set to <c>true</c> [include enums].</param>
        /// <returns><c>true</c> if [is primitive extended internal] [the specified type]; otherwise, <c>false</c>.</returns>
        private static bool IsPrimitiveExtendedInternal(Type type, bool includeEnums)
        {
            if (type.IsPrimitive)
            {
                return true;
            }

            if (includeEnums && type.IsEnum)
            {
                return true;
            }

            return type == typeof(string) ||
                   type == typeof(decimal) ||
                   type == typeof(DateTime) ||
                   type == typeof(DateTimeOffset) ||
                   type == typeof(TimeSpan) ||
                   type == typeof(Guid);
        }
    }
}
