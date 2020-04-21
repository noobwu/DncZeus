// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-21
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-21
// ***********************************************************************
// <copyright file="IAmbientScopeProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.Threading
{
    /// <summary>
    /// Interface IAmbientScopeProvider
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAmbientScopeProvider<T>
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="contextKey">The context key.</param>
        /// <returns>T.</returns>
        T GetValue(string contextKey);

        /// <summary>
        /// Begins the scope.
        /// </summary>
        /// <param name="contextKey">The context key.</param>
        /// <param name="value">The value.</param>
        /// <returns>IDisposable.</returns>
        IDisposable BeginScope(string contextKey, T value);
    }
}