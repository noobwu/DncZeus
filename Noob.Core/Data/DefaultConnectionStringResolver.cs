// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="DefaultConnectionStringResolver.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Noob.DependencyInjection;

namespace Noob.Data
{
    /// <summary>
    /// Class DefaultConnectionStringResolver.
    /// Implements the <see cref="Noob.Data.IConnectionStringResolver" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.Data.IConnectionStringResolver" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class DefaultConnectionStringResolver : IConnectionStringResolver, ITransientDependency
    {
        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <value>The options.</value>
        protected DbConnectionOptions Options { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultConnectionStringResolver"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public DefaultConnectionStringResolver(IOptionsSnapshot<DbConnectionOptions> options)
        {
            Options = options.Value;
        }

        /// <summary>
        /// Resolves the specified connection string name.
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string.</param>
        /// <returns>System.String.</returns>
        public virtual string Resolve(string connectionStringName = null)
        {
            //Get module specific value if provided
            if (!connectionStringName.IsNullOrEmpty())
            {
                var moduleConnString = Options.ConnectionStrings.GetOrDefault(connectionStringName);
                if (!moduleConnString.IsNullOrEmpty())
                {
                    return moduleConnString;
                }
            }
            
            //Get default value
            return Options.ConnectionStrings.Default;
        }
    }
}