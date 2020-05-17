// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-17
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-17
// ***********************************************************************
// <copyright file="DistributedCacheKeyNormalizeArgs.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Caching
{
    /// <summary>
    /// Class DistributedCacheKeyNormalizeArgs.
    /// </summary>
    public class DistributedCacheKeyNormalizeArgs
    {
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        public string Key { get; }

        /// <summary>
        /// Gets the name of the cache.
        /// </summary>
        /// <value>The name of the cache.</value>
        public string CacheName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DistributedCacheKeyNormalizeArgs"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="cacheName">Name of the cache.</param>
        public DistributedCacheKeyNormalizeArgs(
            string key, 
            string cacheName)
        {
            Key = key;
            CacheName = cacheName;
        }
    }
}