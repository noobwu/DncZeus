// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-17
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-17
// ***********************************************************************
// <copyright file="CacheNameAttribute.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using JetBrains.Annotations;

namespace Noob.Caching
{
    /// <summary>
    /// Class CacheNameAttribute.
    /// Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct)]
    public class CacheNameAttribute : Attribute
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheNameAttribute"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public CacheNameAttribute([NotNull] string name)
        {
            Check.NotNull(name, nameof(name));

            Name = name;
        }

        /// <summary>
        /// Gets the name of the cache.
        /// </summary>
        /// <param name="cacheItemType">Type of the cache item.</param>
        /// <returns>System.String.</returns>
        public static string GetCacheName(Type cacheItemType)
        {
            var cacheNameAttribute = cacheItemType
                .GetCustomAttributes(true)
                .OfType<CacheNameAttribute>()
                .FirstOrDefault();

            if (cacheNameAttribute != null)
            {
                return cacheNameAttribute.Name;
            }

            return cacheItemType.FullName.RemovePostFix("CacheItem");
        }
    }
}