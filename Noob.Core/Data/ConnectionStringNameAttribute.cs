// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="ConnectionStringNameAttribute.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Reflection;
using JetBrains.Annotations;

namespace Noob.Data
{
    /// <summary>
    /// Class ConnectionStringNameAttribute.
    /// Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public class ConnectionStringNameAttribute : Attribute
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        [NotNull]
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionStringNameAttribute"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public ConnectionStringNameAttribute([NotNull] string name)
        {
            Check.NotNull(name, nameof(name));

            Name = name;
        }

        /// <summary>
        /// Gets the name of the connection string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>System.String.</returns>
        public static string GetConnStringName<T>()
        {
            return GetConnStringName(typeof(T));
        }

        /// <summary>
        /// Gets the name of the connection string.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.String.</returns>
        public static string GetConnStringName(Type type)
        {
            var nameAttribute = type.GetTypeInfo().GetCustomAttribute<ConnectionStringNameAttribute>();

            if (nameAttribute == null)
            {
                return type.FullName;
            }

            return nameAttribute.Name;
        }
    }
}