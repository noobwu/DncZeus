// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-01
// ***********************************************************************
// <copyright file="AppEntityWithDisableAuditingAndPropertyHasAudited.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.Domain.Entities;

namespace Noob.Auditing.App.Entities
{
    /// <summary>
    /// Class AppEntityWithDisableAuditingAndPropertyHasAudited.
    /// Implements the <see cref="Noob.Domain.Entities.AggregateRoot{System.Guid}" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.AggregateRoot{System.Guid}" />
    [DisableAuditing]
    public class AppEntityWithDisableAuditingAndPropertyHasAudited : AggregateRoot<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppEntityWithDisableAuditingAndPropertyHasAudited"/> class.
        /// </summary>
        protected AppEntityWithDisableAuditingAndPropertyHasAudited()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppEntityWithDisableAuditingAndPropertyHasAudited"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="name2">The name2.</param>
        public AppEntityWithDisableAuditingAndPropertyHasAudited(Guid id, string name, string name2)
            : base(id)
        {
            Name = name;
            Name2 = name2;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Audited]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name2.
        /// </summary>
        /// <value>The name2.</value>
        public string Name2 { get; set; }
    }
}
