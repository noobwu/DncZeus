// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ChildUnitOfWork.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Noob.Uow
{
    /// <summary>
    /// Class ChildUnitOfWork.
    /// Implements the <see cref="Noob.Uow.IUnitOfWork" />
    /// </summary>
    /// <seealso cref="Noob.Uow.IUnitOfWork" />
    internal class ChildUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id => _parent.Id;

        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <value>The options.</value>
        public IUnitOfWorkOptions Options => _parent.Options;

        /// <summary>
        /// Gets the outer.
        /// </summary>
        /// <value>The outer.</value>
        public IUnitOfWork Outer => _parent.Outer;

        /// <summary>
        /// Gets a value indicating whether this instance is reserved.
        /// </summary>
        /// <value><c>true</c> if this instance is reserved; otherwise, <c>false</c>.</value>
        public bool IsReserved => _parent.IsReserved;

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value><c>true</c> if this instance is disposed; otherwise, <c>false</c>.</value>
        public bool IsDisposed => _parent.IsDisposed;

        /// <summary>
        /// Gets a value indicating whether this instance is completed.
        /// </summary>
        /// <value><c>true</c> if this instance is completed; otherwise, <c>false</c>.</value>
        public bool IsCompleted => _parent.IsCompleted;

        /// <summary>
        /// Gets the name of the reservation.
        /// </summary>
        /// <value>The name of the reservation.</value>
        public string ReservationName => _parent.ReservationName;

        /// <summary>
        /// Occurs when [failed].
        /// </summary>
        public event EventHandler<UnitOfWorkFailedEventArgs> Failed;
        /// <summary>
        /// Occurs when [disposed].
        /// </summary>
        public event EventHandler<UnitOfWorkEventArgs> Disposed;

        /// <summary>
        /// Gets the service provider.
        /// </summary>
        /// <value>The service provider.</value>
        public IServiceProvider ServiceProvider => _parent.ServiceProvider;

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public Dictionary<string, object> Items => _parent.Items;

        /// <summary>
        /// The parent
        /// </summary>
        private readonly IUnitOfWork _parent;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChildUnitOfWork"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public ChildUnitOfWork([NotNull] IUnitOfWork parent)
        {
            Check.NotNull(parent, nameof(parent));

            _parent = parent;

            _parent.Failed += (sender, args) => { Failed.InvokeSafely(sender, args); };
            _parent.Disposed += (sender, args) => { Disposed.InvokeSafely(sender, args); };
        }

        /// <summary>
        /// Sets the outer.
        /// </summary>
        /// <param name="outer">The outer.</param>
        public void SetOuter(IUnitOfWork outer)
        {
            _parent.SetOuter(outer);
        }

        /// <summary>
        /// Initializes the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        public void Initialize(UnitOfWorkOptions options)
        {
            _parent.Initialize(options);
        }

        /// <summary>
        /// Reserves the specified reservation name.
        /// </summary>
        /// <param name="reservationName">Name of the reservation.</param>
        public void Reserve(string reservationName)
        {
            _parent.Reserve(reservationName);
        }

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _parent.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Completes the asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public Task CompleteAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Rollbacks the asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            return _parent.RollbackAsync(cancellationToken);
        }

        /// <summary>
        /// Called when [completed].
        /// </summary>
        /// <param name="handler">The handler.</param>
        public void OnCompleted(Func<Task> handler)
        {
            _parent.OnCompleted(handler);
        }

        /// <summary>
        /// Finds the database API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>IDatabaseApi.</returns>
        public IDatabaseApi FindDatabaseApi(string key)
        {
            return _parent.FindDatabaseApi(key);
        }

        /// <summary>
        /// Adds the database API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="api">The API.</param>
        public void AddDatabaseApi(string key, IDatabaseApi api)
        {
            _parent.AddDatabaseApi(key, api);
        }

        /// <summary>
        /// Gets the or add database API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>IDatabaseApi.</returns>
        public IDatabaseApi GetOrAddDatabaseApi(string key, Func<IDatabaseApi> factory)
        {
            return _parent.GetOrAddDatabaseApi(key, factory);
        }

        /// <summary>
        /// Finds the transaction API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>ITransactionApi.</returns>
        public ITransactionApi FindTransactionApi(string key)
        {
            return _parent.FindTransactionApi(key);
        }

        /// <summary>
        /// Adds the transaction API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="api">The API.</param>
        public void AddTransactionApi(string key, ITransactionApi api)
        {
            _parent.AddTransactionApi(key, api);
        }

        /// <summary>
        /// Gets the or add transaction API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>ITransactionApi.</returns>
        public ITransactionApi GetOrAddTransactionApi(string key, Func<ITransactionApi> factory)
        {
            return _parent.GetOrAddTransactionApi(key, factory);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {

        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"[UnitOfWork {Id}]";
        }
    }
}