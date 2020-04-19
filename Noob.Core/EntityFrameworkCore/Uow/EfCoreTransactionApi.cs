// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="EfCoreTransactionApi.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Noob.EntityFrameworkCore;

namespace Noob.Uow.EntityFrameworkCore
{
    /// <summary>
    /// Class EfCoreTransactionApi.
    /// Implements the <see cref="Noob.Uow.ITransactionApi" />
    /// Implements the <see cref="Noob.Uow.ISupportsRollback" />
    /// </summary>
    /// <seealso cref="Noob.Uow.ITransactionApi" />
    /// <seealso cref="Noob.Uow.ISupportsRollback" />
    public class EfCoreTransactionApi : ITransactionApi, ISupportsRollback
    {
        /// <summary>
        /// Gets the database context transaction.
        /// </summary>
        /// <value>The database context transaction.</value>
        public IDbContextTransaction DbContextTransaction { get; }
        /// <summary>
        /// Gets the starter database context.
        /// </summary>
        /// <value>The starter database context.</value>
        public IEfCoreDbContext StarterDbContext { get; }
        /// <summary>
        /// Gets the attended database contexts.
        /// </summary>
        /// <value>The attended database contexts.</value>
        public List<IEfCoreDbContext> AttendedDbContexts { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EfCoreTransactionApi"/> class.
        /// </summary>
        /// <param name="dbContextTransaction">The database context transaction.</param>
        /// <param name="starterDbContext">The starter database context.</param>
        public EfCoreTransactionApi(IDbContextTransaction dbContextTransaction, IEfCoreDbContext starterDbContext)
        {
            DbContextTransaction = dbContextTransaction;
            StarterDbContext = starterDbContext;
            AttendedDbContexts = new List<IEfCoreDbContext>();
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            DbContextTransaction.Commit();

            foreach (var dbContext in AttendedDbContexts)
            {
                if (dbContext.As<DbContext>().HasRelationalTransactionManager())
                {
                    continue; //Relational databases use the shared transaction
                }

                dbContext.Database.CommitTransaction();
            }
        }

        /// <summary>
        /// Commits the asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        public Task CommitAsync()
        {
            Commit();
            return Task.CompletedTask;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            DbContextTransaction.Dispose();
        }

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        public void Rollback()
        {
            DbContextTransaction.Rollback();
        }

        /// <summary>
        /// Rollbacks the asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public Task RollbackAsync(CancellationToken cancellationToken)
        {
            DbContextTransaction.Rollback();
            return Task.CompletedTask;
        }
    }
}