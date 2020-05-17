// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-17
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-17
// ***********************************************************************
// <copyright file="IDistributedCacheSerializer.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Caching
{
    /// <summary>
    /// Interface IDistributedCacheSerializer
    /// </summary>
    public interface IDistributedCacheSerializer
    {
        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>System.Byte[].</returns>
        byte[] Serialize<T>(T obj);

        /// <summary>
        /// Deserializes the specified bytes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes">The bytes.</param>
        /// <returns>T.</returns>
        T Deserialize<T>(byte[] bytes);
    }
}
