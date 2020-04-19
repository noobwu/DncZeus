// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="UnitOfWorkDbContextProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.Data;
using Noob.Uow.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Noob.EntityFrameworkCore.Uow
{
    /// <summary>
    /// Class UnitOfWorkDbContextProvider.
    /// Implements the <see cref="Noob.EntityFrameworkCore.IDbContextProvider{TDbContext}" />
    /// </summary>
    /// <typeparam name="TDbContext">The type of the t database context.</typeparam>
    /// <seealso cref="Noob.EntityFrameworkCore.IDbContextProvider{TDbContext}" />
    public class UnitOfWorkDbContextProvider<TDbContext> : IDbContextProvider<TDbContext>
       where TDbContext : IEfCoreDbContext
    {
        private readonly IConnectionStringResolver _connectionStringResolver;

        public UnitOfWorkDbContextProvider(
            IConnectionStringResolver connectionStringResolver)
        {
            _connectionStringResolver = connectionStringResolver;
        }

        public TDbContext GetDbContext()
        {
            //var connectionStringName = ConnectionStringNameAttribute.GetConnStringName<TDbContext>();
            //var connectionString = _connectionStringResolver.Resolve(connectionStringName);

            //var dbContextKey = $"{typeof(TDbContext).FullName}_{connectionString}";

            //var databaseApi = unitOfWork.GetOrAddDatabaseApi(
            //    dbContextKey,
            //    () => new EfCoreDatabaseApi<TDbContext>(
            //        CreateDbContext(unitOfWork, connectionStringName, connectionString)
            //    ));

            //return ((EfCoreDatabaseApi<TDbContext>)databaseApi).DbContext;
            return default(TDbContext);
        }
    }
}
