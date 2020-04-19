// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IUnitOfWorkManager.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;

namespace Noob.Uow
{
    /// <summary>
    /// Interface IUnitOfWorkManager
    /// </summary>
    public interface IUnitOfWorkManager
    {
        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>The current.</value>
        [CanBeNull]
        IUnitOfWork Current { get; }

        /// <summary>
        /// Begins the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requiresNew">if set to <c>true</c> [requires new].</param>
        /// <returns>IUnitOfWork.</returns>
        [NotNull]
        IUnitOfWork Begin([NotNull] UnitOfWorkOptions options, bool requiresNew = false);

        /// <summary>
        /// Reserves the specified reservation name.
        /// </summary>
        /// <param name="reservationName">Name of the reservation.</param>
        /// <param name="requiresNew">if set to <c>true</c> [requires new].</param>
        /// <returns>IUnitOfWork.</returns>
        [NotNull]
        IUnitOfWork Reserve([NotNull] string reservationName, bool requiresNew = false);

        /// <summary>
        /// Begins the reserved.
        /// </summary>
        /// <param name="reservationName">Name of the reservation.</param>
        /// <param name="options">The options.</param>
        void BeginReserved([NotNull] string reservationName, [NotNull] UnitOfWorkOptions options);

        /// <summary>
        /// Tries the begin reserved.
        /// </summary>
        /// <param name="reservationName">Name of the reservation.</param>
        /// <param name="options">The options.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool TryBeginReserved([NotNull] string reservationName, [NotNull] UnitOfWorkOptions options);
    }
}