// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-17
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-17
// ***********************************************************************
// <copyright file="DistributedCacheKeyNormalizer.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Options;
using Noob.DependencyInjection;
namespace Noob.Caching
{
    /// <summary>
    /// Class DistributedCacheKeyNormalizer.
    /// Implements the <see cref="Noob.Caching.IDistributedCacheKeyNormalizer" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.Caching.IDistributedCacheKeyNormalizer" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class DistributedCacheKeyNormalizer : IDistributedCacheKeyNormalizer, ITransientDependency
    {

        /// <summary>
        /// Gets the distributed cache options.
        /// </summary>
        /// <value>The distributed cache options.</value>
        protected DistributedCacheOptions DistributedCacheOptions { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DistributedCacheKeyNormalizer"/> class.
        /// </summary>
        /// <param name="distributedCacheOptions">The distributed cache options.</param>
        public DistributedCacheKeyNormalizer(
            IOptions<DistributedCacheOptions> distributedCacheOptions)
        {
            DistributedCacheOptions = distributedCacheOptions.Value;
        }

        /// <summary>
        /// Normalizes the key.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>System.String.</returns>
        public virtual string NormalizeKey(DistributedCacheKeyNormalizeArgs args)
        {
            var normalizedKey = $"c:{args.CacheName},k:{DistributedCacheOptions.KeyPrefix}{args.Key}";
            return normalizedKey;
        }
    }
}