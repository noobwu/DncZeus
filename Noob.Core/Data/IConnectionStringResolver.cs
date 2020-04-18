// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="IConnectionStringResolver.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;

namespace Noob.Data
{
    /// <summary>
    /// Interface IConnectionStringResolver
    /// </summary>
    public interface IConnectionStringResolver
    {
        /// <summary>
        /// Resolves the specified connection string name.
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string.</param>
        /// <returns>System.String.</returns>
        [NotNull]
        string Resolve(string connectionStringName = null);
    }
}
