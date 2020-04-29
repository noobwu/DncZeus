// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="AuditLogContributionContext.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.DependencyInjection;

namespace Noob.Auditing
{
    /// <summary>
    /// Class AuditLogContributionContext.
    /// Implements the <see cref="Noob.DependencyInjection.IServiceProviderAccessor" />
    /// </summary>
    /// <seealso cref="Noob.DependencyInjection.IServiceProviderAccessor" />
    public class AuditLogContributionContext : IServiceProviderAccessor
    {
        /// <summary>
        /// Gets the service provider.
        /// </summary>
        /// <value>The service provider.</value>
        public IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Gets the audit information.
        /// </summary>
        /// <value>The audit information.</value>
        public AuditLogInfo AuditInfo { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditLogContributionContext"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="auditInfo">The audit information.</param>
        public AuditLogContributionContext(IServiceProvider serviceProvider, AuditLogInfo auditInfo)
        {
            ServiceProvider = serviceProvider;
            AuditInfo = auditInfo;
        }
    }
}