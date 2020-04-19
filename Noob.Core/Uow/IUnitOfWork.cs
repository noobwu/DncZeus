// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IUnitOfWork.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Noob.Uow
{
    /// <summary>
    /// Interface IUnitOfWork
    /// Implements the <see cref="Noob.Uow.IDatabaseApiContainer" />
    /// Implements the <see cref="Noob.Uow.ITransactionApiContainer" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="Noob.Uow.IDatabaseApiContainer" />
    /// <seealso cref="Noob.Uow.ITransactionApiContainer" />
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDatabaseApiContainer, ITransactionApiContainer, IDisposable
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        Guid Id { get; }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        Dictionary<string, object> Items { get; }


        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Completes the asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        Task CompleteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Rollbacks the asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        Task RollbackAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Called when [completed].
        /// </summary>
        /// <param name="handler">The handler.</param>
        void OnCompleted(Func<Task> handler);
    }
}
