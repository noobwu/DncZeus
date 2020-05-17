// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-17
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-17
// ***********************************************************************
// <copyright file="DistributedCacheOptions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Distributed;

namespace Noob.Caching
{
    /// <summary>
    /// Class DistributedCacheOptions.
    /// </summary>
    public class DistributedCacheOptions
    {
        /// <summary>
        /// Throw or hide exceptions for the distributed cache.
        /// </summary>
        /// <value><c>true</c> if [hide errors]; otherwise, <c>false</c>.</value>
        public bool HideErrors { get; set; } = true;

        /// <summary>
        /// Cache key prefix.
        /// </summary>
        /// <value>The key prefix.</value>
        public string KeyPrefix { get; set; }

        /// <summary>
        /// Global Cache entry options.
        /// </summary>
        /// <value>The global cache entry options.</value>
        public DistributedCacheEntryOptions GlobalCacheEntryOptions { get; set; }

        /// <summary>
        /// List of all cache configurators.
        /// (func argument:Name of cache)
        /// </summary>
        /// <value>The cache configurators.</value>
        public List<Func<string, DistributedCacheEntryOptions>> CacheConfigurators { get; set; } //TODO: use a configurator interface instead?

        /// <summary>
        /// Initializes a new instance of the <see cref="DistributedCacheOptions"/> class.
        /// </summary>
        public DistributedCacheOptions()
        {
            CacheConfigurators = new List<Func<string, DistributedCacheEntryOptions>>();
            GlobalCacheEntryOptions = new DistributedCacheEntryOptions();
            KeyPrefix = "";
        }
    }
}
