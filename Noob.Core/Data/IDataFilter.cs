// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="IDataFilter.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.Data
{
    /// <summary>
    /// Interface IDataFilter
    /// </summary>
    /// <typeparam name="TFilter">The type of the t filter.</typeparam>
    public interface IDataFilter<TFilter>
        where TFilter : class
    {
        /// <summary>
        /// Enables this instance.
        /// </summary>
        /// <returns>IDisposable.</returns>
        IDisposable Enable();

        /// <summary>
        /// Disables this instance.
        /// </summary>
        /// <returns>IDisposable.</returns>
        IDisposable Disable();

        /// <summary>
        /// Gets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value><c>true</c> if this instance is enabled; otherwise, <c>false</c>.</value>
        bool IsEnabled { get; }
    }

    /// <summary>
    /// Interface IDataFilter
    /// </summary>
    public interface IDataFilter
    {
        /// <summary>
        /// Enables this instance.
        /// </summary>
        /// <typeparam name="TFilter">The type of the t filter.</typeparam>
        /// <returns>IDisposable.</returns>
        IDisposable Enable<TFilter>()
            where TFilter : class;

        /// <summary>
        /// Disables this instance.
        /// </summary>
        /// <typeparam name="TFilter">The type of the t filter.</typeparam>
        /// <returns>IDisposable.</returns>
        IDisposable Disable<TFilter>()
            where TFilter : class;

        /// <summary>
        /// Determines whether this instance is enabled.
        /// </summary>
        /// <typeparam name="TFilter">The type of the t filter.</typeparam>
        /// <returns><c>true</c> if this instance is enabled; otherwise, <c>false</c>.</returns>
        bool IsEnabled<TFilter>()
            where TFilter : class;
    }
}
