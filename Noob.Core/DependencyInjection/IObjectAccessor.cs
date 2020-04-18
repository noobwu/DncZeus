// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="IObjectAccessor.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using JetBrains.Annotations;

/// <summary>
/// The DependencyInjection namespace.
/// </summary>
namespace Noob.DependencyInjection
{
    /// <summary>
    /// Interface IObjectAccessor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObjectAccessor<out T>
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        [CanBeNull]
        T Value { get; }
    }
}