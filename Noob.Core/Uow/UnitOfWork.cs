﻿using JetBrains.Annotations;
using Noob.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Noob.Uow
{
    public class UnitOfWork : IUnitOfWork, ITransientDependency
    {
        public Guid Id { get; } = Guid.NewGuid();
        public bool IsDisposed { get; private set; }

        public bool IsCompleted { get; private set; }

        public IServiceProvider ServiceProvider { get; }
        private readonly Dictionary<string, IDatabaseApi> _databaseApis;
        private readonly Dictionary<string, ITransactionApi> _transactionApis;
        protected List<Func<Task>> CompletedHandlers { get; } = new List<Func<Task>>();
        [NotNull]
        public Dictionary<string, object> Items { get; }
        private Exception _exception;
        private bool _isCompleting;
        private bool _isRolledback;
        public event EventHandler<UnitOfWorkFailedEventArgs> Failed;
        public event EventHandler<UnitOfWorkEventArgs> Disposed;
        public UnitOfWork(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            _databaseApis = new Dictionary<string, IDatabaseApi>();
            _transactionApis = new Dictionary<string, ITransactionApi>();

            Items = new Dictionary<string, object>();
        }
        public IReadOnlyList<IDatabaseApi> GetAllActiveDatabaseApis()
        {
            return _databaseApis.Values.ToImmutableList();
        }

        public IReadOnlyList<ITransactionApi> GetAllActiveTransactionApis()
        {
            return _transactionApis.Values.ToImmutableList();
        }
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

        public virtual async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (_isRolledback)
            {
                return;
            }

            _isRolledback = true;

            await RollbackAllAsync(cancellationToken);
        }

        public IDatabaseApi FindDatabaseApi(string key)
        {
            return _databaseApis.GetOrDefault(key);
        }

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

        public IDatabaseApi GetOrAddDatabaseApi(string key, Func<IDatabaseApi> factory)
        {
            Check.NotNull(key, nameof(key));
            Check.NotNull(factory, nameof(factory));

            return _databaseApis.GetOrAdd(key, factory);
        }

        public ITransactionApi FindTransactionApi(string key)
        {
            Check.NotNull(key, nameof(key));

            return _transactionApis.GetOrDefault(key);
        }

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

        public ITransactionApi GetOrAddTransactionApi(string key, Func<ITransactionApi> factory)
        {
            Check.NotNull(key, nameof(key));
            Check.NotNull(factory, nameof(factory));

            return _transactionApis.GetOrAdd(key, factory);
        }

        public void OnCompleted(Func<Task> handler)
        {
            CompletedHandlers.Add(handler);
        }

        protected virtual async Task OnCompletedAsync()
        {
            foreach (var handler in CompletedHandlers)
            {
                await handler.Invoke();
            }
        }
        protected virtual void OnFailed()
        {
            Failed.InvokeSafely(this, new UnitOfWorkFailedEventArgs(this, _exception, _isRolledback));
        }

        protected virtual void OnDisposed()
        {
            Disposed.InvokeSafely(this, new UnitOfWorkEventArgs(this));
        }

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

        private void PreventMultipleComplete()
        {
            if (IsCompleted || _isCompleting)
            {
                throw new Exception("Complete is called before!");
            }
        }

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

        protected virtual void CommitTransactions()
        {
            foreach (var transaction in GetAllActiveTransactionApis())
            {
                transaction.Commit();
            }
        }

        protected virtual async Task CommitTransactionsAsync()
        {
            foreach (var transaction in GetAllActiveTransactionApis())
            {
                await transaction.CommitAsync();
            }
        }

        public override string ToString()
        {
            return $"[UnitOfWork {Id}]";
        }


    }
}
