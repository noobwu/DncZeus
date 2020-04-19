// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ThirdDbContextDummyEntity.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.Domain.Entities;

namespace Noob.EntityFrameworkCore.TestApp.ThirdDbContext
{
    /// <summary>
    /// Class ThirdDbContextDummyEntity.
    /// Implements the <see cref="Noob.Domain.Entities.AggregateRoot{System.Guid}" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.AggregateRoot{System.Guid}" />
    public class ThirdDbContextDummyEntity : AggregateRoot<Guid>
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }
    }
}