// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-17
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-17
// ***********************************************************************
// <copyright file="IDistributedCacheKeyNormalizer.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Caching
{
    /// <summary>
    /// Interface IDistributedCacheKeyNormalizer
    /// </summary>
    public interface IDistributedCacheKeyNormalizer
    {
        /// <summary>
        /// Normalizes the key.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>System.String.</returns>
        string NormalizeKey(DistributedCacheKeyNormalizeArgs args);
    }
}
