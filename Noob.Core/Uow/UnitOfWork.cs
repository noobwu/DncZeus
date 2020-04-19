// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="UnitOfWork.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;
using Microsoft.Extensions.Options;
using Noob.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Noob.Uow
{
    /// <summary>
    /// Class UnitOfWork.
    /// Implements the <see cref="Noob.Uow.IUnitOfWork" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.Uow.IUnitOfWork" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class UnitOfWork : IUnitOfWork, ITransientDependency
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; } = Guid.NewGuid();
        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <value>The options.</value>
        public IUnitOfWorkOptions Options { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value><c>true</c> if this instance is disposed; otherwise, <c>false</c>.</value>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is completed.
        /// </summary>
        /// <value><c>true</c> if this instance is completed; otherwise, <c>false</c>.</value>
        public bool IsCompleted { get; private set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is reserved.
        /// </summary>
        /// <value><c>true</c> if this instance is reserved; otherwise, <c>false</c>.</value>
        public bool IsReserved { get; set; }
        /// <summary>
        /// Gets or sets the name of the reservation.
        /// </summary>
        /// <value>The name of the reservation.</value>
        public string ReservationName { get; set; }
        /// <summary>
        /// Gets the service provider.
        /// </summary>
        /// <value>The service provider.</value>
        public IServiceProvider ServiceProvider { get; }
        /// <summary>
        /// The database apis
        /// </summary>
        private readonly Dictionary<string, IDatabaseApi> _databaseApis;
        /// <summary>
        /// The transaction apis
        /// </summary>
        private readonly Dictionary<string, ITransactionApi> _transactionApis;
        /// <summary>
        /// Gets the completed handlers.
        /// </summary>
        /// <value>The completed handlers.</value>
        protected List<Func<Task>> CompletedHandlers { get; } = new List<Func<Task>>();
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        [NotNull]
        public Dictionary<string, object> Items { get; }
        /// <summary>
        /// The exception
        /// </summary>
        private Exception _exception;
        /// <summary>
        /// The is completing
        /// </summary>
        private bool _isCompleting;
        /// <summary>
        /// The is rolledback
        /// </summary>
        private bool _isRolledback;
        /// <summary>
        /// Occurs when [failed].
        /// </summary>
        public event EventHandler<UnitOfWorkFailedEventArgs> Failed;
        /// <summary>
        /// Occurs when [disposed].
        /// </summary>
        public event EventHandler<UnitOfWorkEventArgs> Disposed;

        /// <summary>
        /// The default options
        /// </summary>
        private readonly UnitOfWorkDefaultOptions _defaultOptions;
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public UnitOfWork(IServiceProvider serviceProvider, IOptions<UnitOfWorkDefaultOptions> options)
        {
            ServiceProvider = serviceProvider;
            _defaultOptions = options.Value;

            _databaseApis = new Dictionary<string, IDatabaseApi>();
            _transactionApis = new Dictionary<string, ITransactionApi>();
  
            Items = new Dictionary<string, object>();
        }

        /// <summary>
        /// Initializes the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <exception cref="Exception">This unit of work is already initialized before!</exception>
        public virtual void Initialize(UnitOfWorkOptions options)
        {
            Check.NotNull(options, nameof(options));

            if (Options != null)
            {
                throw new Exception("This unit of work is already initialized before!");
            }

            Options = _defaultOptions.Normalize(options.Clone());
            IsReserved = false;
        }

        /// <summary>
        /// Reserves the specified reservation name.
        /// </summary>
        /// <param name="reservationName">Name of the reservation.</param>
        public virtual void Reserve(string reservationName)
        {
            Check.NotNull(reservationName, nameof(reservationName));

            ReservationName = reservationName;
            IsReserved = true;
        }
        /// <summary>
        /// Gets all active database apis.
        /// </summary>
        /// <returns>IReadOnlyList&lt;IDatabaseApi&gt;.</returns>
        public IReadOnlyList<IDatabaseApi> GetAllActiveDatabaseApis()
        {
            return _databaseApis.Values.ToImmutableList();
        }

        /// <summary>
        /// Gets all active transaction apis.
        /// </summary>
        /// <returns>IReadOnlyList&lt;ITransactionApi&gt;.</returns>
        public IReadOnlyList<ITransactionApi> GetAllActiveTransactionApis()
        {
            return _transactionApis.Values.ToImmutableList();
        }
        /// <summary>
        /// save changes as an asynchronous operation.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var databaseApi in GetAllActiveDatabaseApis())
            {
                if (databaseApi is ISupportsSavingChanges)
                {
                    await (databaseApi as ISupportsSavingChanges).SaveChangesAsync(cancellationToken);
                }
            }
        }
        /// <summary>
        /// complete as an asynchronous operation.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public virtual async Task CompleteAsync(CancellationToken cancellationToken = default)
        {
            if (_isRolledback)
            {
                return;
            }

            PreventMultipleComplete();

            try
            {
                _isCompleting = true;
                await SaveChangesAsync(cancellationToken);
                await CommitTransactionsAsync();
                IsCompleted = true;
                await OnCompletedAsync();
            }
            catch (Exception ex)
            {
                _exception = ex;
                throw;
            }
        }

        /// <summary>
        /// rollback as an asynchronous operation.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public virtual async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (_isRolledback)
            {
                return;
            }

            _isRolledback = true;

            await RollbackAllAsync(cancellationToken);
        }

        /// <summary>
        /// Finds the database API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>IDatabaseApi.</returns>
        public IDatabaseApi FindDatabaseApi(string key)
        {
            return _databaseApis.GetOrDefault(key);
        }

        /// <summary>
        /// Adds the database API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="api">The API.</param>
        /// <exception cref="Exception">There is already a database API in this unit of work with given key: " + key</exception>
        public void AddDatabaseApi(string key, IDatabaseApi api)
        {
            Check.NotNull(key, nameof(key));
            Check.NotNull(api, nameof(api));

            if (_databaseApis.ContainsKey(key))
            {
                throw new Exception("There is already a database API in this unit of work with given key: " + key);
            }

            _databaseApis.Add(key, api);
        }

        /// <summary>
        /// Gets the or add database API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>IDatabaseApi.</returns>
        public IDatabaseApi GetOrAddDatabaseApi(string key, Func<IDatabaseApi> factory)
        {
            Check.NotNull(key, nameof(key));
            Check.NotNull(factory, nameof(factory));

            return _databaseApis.GetOrAdd(key, factory);
        }

        /// <summary>
        /// Finds the transaction API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>ITransactionApi.</returns>
        public ITransactionApi FindTransactionApi(string key)
        {
            Check.NotNull(key, nameof(key));

            return _transactionApis.GetOrDefault(key);
        }

        /// <summary>
        /// Adds the transaction API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="api">The API.</param>
        /// <exception cref="Exception">There is already a transaction API in this unit of work with given key: " + key</exception>
        public void AddTransactionApi(string key, ITransactionApi api)
        {
            Check.NotNull(key, nameof(key));
            Check.NotNull(api, nameof(api));

            if (_transactionApis.ContainsKey(key))
            {
                throw new Exception("There is already a transaction API in this unit of work with given key: " + key);
            }

            _transactionApis.Add(key, api);
        }

        /// <summary>
        /// Gets the or add transaction API.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>ITransactionApi.</returns>
        public ITransactionApi GetOrAddTransactionApi(string key, Func<ITransactionApi> factory)
        {
            Check.NotNull(key, nameof(key));
            Check.NotNull(factory, nameof(factory));

            return _transactionApis.GetOrAdd(key, factory);
        }

        /// <summary>
        /// Called when [completed].
        /// </summary>
        /// <param name="handler">The handler.</param>
        public void OnCompleted(Func<Task> handler)
        {
            CompletedHandlers.Add(handler);
        }

        /// <summary>
        /// on completed as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        protected virtual async Task OnCompletedAsync()
        {
            foreach (var handler in CompletedHandlers)
            {
                await handler.Invoke();
            }
        }
        /// <summary>
        /// Called when [failed].
        /// </summary>
        protected virtual void OnFailed()
        {
            Failed.InvokeSafely(this, new UnitOfWorkFailedEventArgs(this, _exception, _isRolledback));
        }

        /// <summary>
        /// Called when [disposed].
        /// </summary>
        protected virtual void OnDisposed()
        {
            Disposed.InvokeSafely(this, new UnitOfWorkEventArgs(this));
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            IsDisposed = true;

            DisposeTransactions();

            if (!IsCompleted || _exception != null)
            {
                OnFailed();
            }

            OnDisposed();
        }

        /// <summary>
        /// Disposes the transactions.
        /// </summary>
        private void DisposeTransactions()
        {
            foreach (var transactionApi in GetAllActiveTransactionApis())
            {
                try
                {
                    transactionApi.Dispose();
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Prevents the multiple complete.
        /// </summary>
        /// <exception cref="Exception">Complete is called before!</exception>
        private void PreventMultipleComplete()
        {
            if (IsCompleted || _isCompleting)
            {
                throw new Exception("Complete is called before!");
            }
        }

        /// <summary>
        /// Rollbacks all.
        /// </summary>
        protected virtual void RollbackAll()
        {
            foreach (var databaseApi in GetAllActiveDatabaseApis())
            {
                try
                {
                    (databaseApi as ISupportsRollback)?.Rollback();
                }
                catch { }
            }

            foreach (var transactionApi in GetAllActiveTransactionApis())
            {
                try
                {
                    (transactionApi as ISupportsRollback)?.Rollback();
                }
                catch { }
            }
        }

        /// <summary>
        /// rollback all as an asynchronous operation.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        protected virtual async Task RollbackAllAsync(CancellationToken cancellationToken)
        {
            foreach (var databaseApi in GetAllActiveDatabaseApis())
            {
                if (databaseApi is ISupportsRollback)
                {
                    try
                    {
                        await (databaseApi as ISupportsRollback).RollbackAsync(cancellationToken);
                    }
                    catch { }
                }
            }

            foreach (var transactionApi in GetAllActiveTransactionApis())
            {
                if (transactionApi is ISupportsRollback)
                {
                    try
                    {
                        await (transactionApi as ISupportsRollback).RollbackAsync(cancellationToken);
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// Commits the transactions.
        /// </summary>
        protected virtual void CommitTransactions()
        {
            foreach (var transaction in GetAllActiveTransactionApis())
            {
                transaction.Commit();
            }
        }

        /// <summary>
        /// commit transactions as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        protected virtual async Task CommitTransactionsAsync()
        {
            foreach (var transaction in GetAllActiveTransactionApis())
            {
                await transaction.CommitAsync();
            }
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
