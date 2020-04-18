// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="EfCoreDatabaseProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.EntityFrameworkCore
{
    /// <summary>
    /// Enum EfCoreDatabaseProvider
    /// </summary>
    public enum EfCoreDatabaseProvider
    {
        /// <summary>
        /// The SQL server
        /// </summary>
        SqlServer,
        /// <summary>
        /// My SQL
        /// </summary>
        MySql,
        /// <summary>
        /// The oracle
        /// </summary>
        Oracle,
        /// <summary>
        /// The postgre SQL
        /// </summary>
        PostgreSql,
        /// <summary>
        /// The sqlite
        /// </summary>
        Sqlite,
        /// <summary>
        /// The in memory
        /// </summary>
        InMemory,
        /// <summary>
        /// The cosmos
        /// </summary>
        Cosmos,
        /// <summary>
        /// The firebird
        /// </summary>
        Firebird
    }
}
