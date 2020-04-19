// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ITransactionApiContainer.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using JetBrains.Annotations;

namespace Noob.Uow
{
    /// <summary>
    /// Interface ITransactionApiContainer
    /// </summary>
    public interface ITransactionApiContainer
    {
        /// <summary>
        /// Finds the transaction API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>ITransactionApi.</returns>
        [CanBeNull]
        ITransactionApi FindTransactionApi([NotNull] string key);

        /// <summary>
        /// Adds the transaction API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="api">The API.</param>
        void AddTransactionApi([NotNull] string key, [NotNull] ITransactionApi api);

        /// <summary>
        /// Gets the or add transaction API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>ITransactionApi.</returns>
        [NotNull]
        ITransactionApi GetOrAddTransactionApi([NotNull] string key, [NotNull] Func<ITransactionApi> factory);
    }
}