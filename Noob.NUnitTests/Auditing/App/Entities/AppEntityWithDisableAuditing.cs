﻿// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-01
// ***********************************************************************
// <copyright file="AppEntityWithDisableAuditing.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.Domain.Entities;

namespace Noob.Auditing.App.Entities
{
    /// <summary>
    /// Class AppEntityWithDisableAuditing.
    /// Implements the <see cref="Noob.Domain.Entities.AggregateRoot{System.Guid}" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.AggregateRoot{System.Guid}" />
    [DisableAuditing]
    public class AppEntityWithDisableAuditing : AggregateRoot<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppEntityWithDisableAuditing"/> class.
        /// </summary>
        protected AppEntityWithDisableAuditing()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppEntityWithDisableAuditing"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        public AppEntityWithDisableAuditing(Guid id, string name)
            : base(id)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
    }
}
