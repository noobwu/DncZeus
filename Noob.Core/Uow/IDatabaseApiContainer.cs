// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IDatabaseApiContainer.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;
using Noob.DependencyInjection;

namespace Noob.Uow
{
    /// <summary>
    /// Interface IDatabaseApiContainer
    /// Implements the <see cref="Noob.DependencyInjection.IServiceProviderAccessor" />
    /// </summary>
    /// <seealso cref="Noob.DependencyInjection.IServiceProviderAccessor" />
    public interface IDatabaseApiContainer : IServiceProviderAccessor
    {
        /// <summary>
        /// Finds the database API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>IDatabaseApi.</returns>
        [CanBeNull]
        IDatabaseApi FindDatabaseApi([NotNull] string key);

        /// <summary>
        /// Adds the database API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="api">The API.</param>
        void AddDatabaseApi([NotNull] string key, [NotNull] IDatabaseApi api);

        /// <summary>
        /// Gets the or add database API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>IDatabaseApi.</returns>
        [NotNull]
        IDatabaseApi GetOrAddDatabaseApi([NotNull] string key, [NotNull] Func<IDatabaseApi> factory);
    }
}