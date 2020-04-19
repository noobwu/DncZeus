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
using JetBrains.Annotations;
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

        //TODO: Switch to OnFailed (sync) and OnDisposed (sync) methods to be compatible with OnCompleted
        /// <summary>
        /// Occurs when [failed].
        /// </summary>
        event EventHandler<UnitOfWorkFailedEventArgs> Failed;

        /// <summary>
        /// Occurs when [disposed].
        /// </summary>
        event EventHandler<UnitOfWorkEventArgs> Disposed;

        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <value>The options.</value>
        IUnitOfWorkOptions Options { get; }

        /// <summary>
        /// Gets the outer.
        /// </summary>
        /// <value>The outer.</value>
        IUnitOfWork Outer { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is reserved.
        /// </summary>
        /// <value><c>true</c> if this instance is reserved; otherwise, <c>false</c>.</value>
        bool IsReserved { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value><c>true</c> if this instance is disposed; otherwise, <c>false</c>.</value>
        bool IsDisposed { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is completed.
        /// </summary>
        /// <value><c>true</c> if this instance is completed; otherwise, <c>false</c>.</value>
        bool IsCompleted { get; }

        /// <summary>
        /// Gets the name of the reservation.
        /// </summary>
        /// <value>The name of the reservation.</value>
        string ReservationName { get; }

        /// <summary>
        /// Sets the outer.
        /// </summary>
        /// <param name="outer">The outer.</param>
        void SetOuter([CanBeNull] IUnitOfWork outer);

        /// <summary>
        /// Initializes the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        void Initialize([NotNull] UnitOfWorkOptions options);

        /// <summary>
        /// Reserves the specified reservation name.
        /// </summary>
        /// <param name="reservationName">Name of the reservation.</param>
        void Reserve([NotNull] string reservationName);

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
