// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="EfCoreDatabaseApi.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading;
using System.Threading.Tasks;
using Noob.EntityFrameworkCore;

namespace Noob.Uow.EntityFrameworkCore
{
    /// <summary>
    /// Class EfCoreDatabaseApi.
    /// Implements the <see cref="Noob.Uow.IDatabaseApi" />
    /// Implements the <see cref="Noob.Uow.ISupportsSavingChanges" />
    /// </summary>
    /// <typeparam name="TDbContext">The type of the t database context.</typeparam>
    /// <seealso cref="Noob.Uow.IDatabaseApi" />
    /// <seealso cref="Noob.Uow.ISupportsSavingChanges" />
    public class EfCoreDatabaseApi<TDbContext> : IDatabaseApi, ISupportsSavingChanges
        where TDbContext : IEfCoreDbContext
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>The database context.</value>
        public TDbContext DbContext { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EfCoreDatabaseApi{TDbContext}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public EfCoreDatabaseApi(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return DbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}