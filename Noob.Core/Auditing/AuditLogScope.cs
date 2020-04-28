// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="AuditLogScope.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Auditing
{
    /// <summary>
    /// Class AuditLogScope.
    /// Implements the <see cref="IAuditLogScope" />
    /// </summary>
    /// <seealso cref="IAuditLogScope" />
    public class AuditLogScope : IAuditLogScope
    {
        /// <summary>
        /// Gets the log.
        /// </summary>
        /// <value>The log.</value>
        public AuditLogInfo Log { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditLogScope"/> class.
        /// </summary>
        /// <param name="log">The log.</param>
        public AuditLogScope(AuditLogInfo log)
        {
            Log = log;
        }
    }
}