// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="SimpleLogAuditingStore.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Noob.DependencyInjection;

namespace Noob.Auditing
{
    /// <summary>
    /// Class SimpleLogAuditingStore.
    /// Implements the <see cref="Noob.Auditing.IAuditingStore" />
    /// Implements the <see cref="Noob.DependencyInjection.ISingletonDependency" />
    /// </summary>
    /// <seealso cref="Noob.Auditing.IAuditingStore" />
    /// <seealso cref="Noob.DependencyInjection.ISingletonDependency" />
    [Dependency(TryRegister = true)]
    public class SimpleLogAuditingStore : IAuditingStore, ISingletonDependency
    {
        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        /// <value>The logger.</value>
        public ILogger<SimpleLogAuditingStore> Logger { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleLogAuditingStore"/> class.
        /// </summary>
        public SimpleLogAuditingStore()
        {
            Logger = NullLogger<SimpleLogAuditingStore>.Instance;
        }

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <param name="auditInfo">The audit information.</param>
        /// <returns>Task.</returns>
        public Task SaveAsync(AuditLogInfo auditInfo)
        {
            Logger.LogInformation(auditInfo.ToString());
            return Task.FromResult(0);
        }
    }
}