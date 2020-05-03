// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="IAutoObjectMappingProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.ObjectMapping
{
    /// <summary>
    /// Interface IAutoObjectMappingProvider
    /// </summary>
    public interface IAutoObjectMappingProvider
    {
        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <typeparam name="TDestination">The type of the t destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>TDestination.</returns>
        TDestination Map<TSource, TDestination>(object source);

        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <typeparam name="TDestination">The type of the t destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>TDestination.</returns>
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }

    /// <summary>
    /// Interface IAutoObjectMappingProvider
    /// Implements the <see cref="Noob.ObjectMapping.IAutoObjectMappingProvider" />
    /// </summary>
    /// <typeparam name="TContext">The type of the t context.</typeparam>
    /// <seealso cref="Noob.ObjectMapping.IAutoObjectMappingProvider" />
    public interface IAutoObjectMappingProvider<TContext> : IAutoObjectMappingProvider
    {

    }
}