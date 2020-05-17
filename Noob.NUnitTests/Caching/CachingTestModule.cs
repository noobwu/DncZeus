// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-17
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-17
// ***********************************************************************
// <copyright file="CachingTestModule.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Caching.Distributed;
using System;
using Noob.Modularity;

namespace Noob.Caching
{
    /// <summary>
    /// Class CachingTestModule.
    /// Implements the <see cref="Noob.Modularity.Module" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.Module" />
    [DependsOn(typeof(CachingModule))]
    public class CachingTestModule : Module
    {
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<DistributedCacheOptions>(option =>
            {
                option.CacheConfigurators.Add(cacheName =>
                {
                    if (cacheName == CacheNameAttribute.GetCacheName(typeof(Sail.Testing.Caching.PersonCacheItem)))
                    {
                        return new DistributedCacheEntryOptions()
                        {
                            AbsoluteExpiration = DateTime.Parse("2099-01-01 12:00:00")
                        };
                    }

                    return null;
                });

                option.GlobalCacheEntryOptions.SetSlidingExpiration(TimeSpan.FromMinutes(20));
            });
        }
    }
}