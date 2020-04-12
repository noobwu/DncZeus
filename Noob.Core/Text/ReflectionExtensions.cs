// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-12
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-12
// ***********************************************************************
// <copyright file="ReflectionExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Noob
{
    /// <summary>
    /// Class ReflectionExtensions.
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Gets the type code.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>TypeCode.</returns>
        public static TypeCode GetTypeCode(this Type type)
        {
            return Type.GetTypeCode(type);
        }

        /// <summary>
        /// Determines whether [is instance of] [the specified this or base type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="thisOrBaseType">Type of the this or base.</param>
        /// <returns><c>true</c> if [is instance of] [the specified this or base type]; otherwise, <c>false</c>.</returns>
        public static bool IsInstanceOf(this Type type, Type thisOrBaseType)
        {
            while (type != null)
            {
                if (type == thisOrBaseType)
                    return true;

                type = type.BaseType;
            }

            return false;
        }
        /// <summary>
        /// Determines whether [has generic type] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if [has generic type] [the specified type]; otherwise, <c>false</c>.</returns>
        public static bool HasGenericType(this Type type)
        {
            while (type != null)
            {
                if (type.IsGenericType)
                    return true;

                type = type.BaseType;
            }
            return false;
        }
        /// <summary>
        /// Determines whether the specified interface type has interface.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="interfaceType">Type of the interface.</param>
        /// <returns><c>true</c> if the specified interface type has interface; otherwise, <c>false</c>.</returns>
        public static bool HasInterface(this Type type, Type interfaceType)
        {
            foreach (var t in type.GetInterfaces())
            {
                if (t == interfaceType)
                    return true;
            }
            return false;
        }
    }
}
