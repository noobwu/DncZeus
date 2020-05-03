// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2019-03-03
// ***********************************************************************
// <copyright file="IMapFrom.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.ObjectMapping
{
    /// <summary>
    /// Interface IMapFrom
    /// </summary>
    /// <typeparam name="TSource">The type of the t source.</typeparam>
    public interface IMapFrom<in TSource>
    {
        /// <summary>
        /// Maps from.
        /// </summary>
        /// <param name="source">The source.</param>
        void MapFrom(TSource source);
    }
}