// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="BookInSecondDbContext.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.Domain.Entities;

namespace Noob.EntityFrameworkCore.TestApp.SecondContext
{
    /// <summary>
    /// Class BookInSecondDbContext.
    /// Implements the <see cref="Noob.Domain.Entities.AggregateRoot{System.Guid}" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.AggregateRoot{System.Guid}" />
    public class BookInSecondDbContext : AggregateRoot<Guid>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookInSecondDbContext"/> class.
        /// </summary>
        public BookInSecondDbContext()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookInSecondDbContext"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        public BookInSecondDbContext(Guid id, string name)
            : base(id)
        {
            Name = name;
        }
    }
}