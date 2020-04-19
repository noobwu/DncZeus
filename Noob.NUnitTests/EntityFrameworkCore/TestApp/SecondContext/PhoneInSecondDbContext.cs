// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="PhoneInSecondDbContext.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Noob.Domain.Entities;

namespace Noob.EntityFrameworkCore.TestApp.SecondContext
{
    /// <summary>
    /// Class PhoneInSecondDbContext.
    /// Implements the <see cref="Noob.Domain.Entities.AggregateRoot" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.AggregateRoot" />
    [Table("AppPhones")]
    public class PhoneInSecondDbContext : AggregateRoot
    {
        /// <summary>
        /// Gets or sets the person identifier.
        /// </summary>
        /// <value>The person identifier.</value>
        public virtual Guid PersonId { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        public virtual string Number { get; set; }

        /// <summary>
        /// Returns an array of ordered keys for this entity.
        /// </summary>
        /// <returns>System.Object[].</returns>
        public override object[] GetKeys()
        {
            return new object[] {PersonId, Number};
        }
    }
}