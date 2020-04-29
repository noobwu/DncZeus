// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="AuditLogContributor.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Auditing
{
    /// <summary>
    /// Class AuditLogContributor.
    /// </summary>
    public abstract class AuditLogContributor
    {
        /// <summary>
        /// Pres the contribute.
        /// </summary>
        /// <param name="context">The context.</param>
        public virtual void PreContribute(AuditLogContributionContext context)
        {

        }

        /// <summary>
        /// Posts the contribute.
        /// </summary>
        /// <param name="context">The context.</param>
        public virtual void PostContribute(AuditLogContributionContext context)
        {

        }
    }
}