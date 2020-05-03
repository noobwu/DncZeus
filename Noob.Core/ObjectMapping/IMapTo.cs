// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="IMapTo.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.ObjectMapping
{
    /// <summary>
    /// Interface IMapTo
    /// </summary>
    /// <typeparam name="TDestination">The type of the t destination.</typeparam>
    public interface IMapTo<TDestination>
    {
        /// <summary>
        /// Maps to.
        /// </summary>
        /// <returns>TDestination.</returns>
        TDestination MapTo();

        /// <summary>
        /// Maps to.
        /// </summary>
        /// <param name="destination">The destination.</param>
        void MapTo(TDestination destination);
    }
}
