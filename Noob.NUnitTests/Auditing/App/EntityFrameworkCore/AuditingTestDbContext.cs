// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-22
// ***********************************************************************
// <copyright file="AuditingTestDbContext.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using Noob.Auditing.App.Entities;
using Noob.EntityFrameworkCore;

namespace Noob.Auditing.App.EntityFrameworkCore
{
    /// <summary>
    /// Class AuditingTestDbContext.
    /// Implements the <see cref="Noob.EntityFrameworkCore.EfCoreDbContext{Noob.Auditing.App.EntityFrameworkCore.AuditingTestDbContext}" />
    /// </summary>
    /// <seealso cref="Noob.EntityFrameworkCore.EfCoreDbContext{Noob.Auditing.App.EntityFrameworkCore.AuditingTestDbContext}" />
    public class AuditingTestDbContext : EfCoreDbContext<AuditingTestDbContext>
    {
        /// <summary>
        /// Gets or sets the application entity with audited.
        /// </summary>
        /// <value>The application entity with audited.</value>
        public DbSet<AppEntityWithAudited> AppEntityWithAudited { get; set; }

        /// <summary>
        /// Gets or sets the application entity with audited and property has disable auditing.
        /// </summary>
        /// <value>The application entity with audited and property has disable auditing.</value>
        public DbSet<AppEntityWithAuditedAndPropertyHasDisableAuditing> AppEntityWithAuditedAndPropertyHasDisableAuditing { get; set; }

        /// <summary>
        /// Gets or sets the application entity with disable auditing.
        /// </summary>
        /// <value>The application entity with disable auditing.</value>
        public DbSet<AppEntityWithDisableAuditing> AppEntityWithDisableAuditing { get; set; }

        /// <summary>
        /// Gets or sets the application entity with disable auditing and property has audited.
        /// </summary>
        /// <value>The application entity with disable auditing and property has audited.</value>
        public DbSet<AppEntityWithDisableAuditingAndPropertyHasAudited> AppEntityWithDisableAuditingAndPropertyHasAudited { get; set; }

        /// <summary>
        /// Gets or sets the application entity with property has audited.
        /// </summary>
        /// <value>The application entity with property has audited.</value>
        public DbSet<AppEntityWithPropertyHasAudited> AppEntityWithPropertyHasAudited { get; set; }

        /// <summary>
        /// Gets or sets the application entity with selector.
        /// </summary>
        /// <value>The application entity with selector.</value>
        public DbSet<AppEntityWithSelector> AppEntityWithSelector { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditingTestDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public AuditingTestDbContext(DbContextOptions<AuditingTestDbContext> options)
            : base(options)
        {

        }
    }
}