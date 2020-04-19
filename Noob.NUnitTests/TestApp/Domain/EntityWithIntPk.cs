// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="EntityWithIntPk.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Noob.Domain.Entities;

namespace Noob.TestApp.Domain
{
    /// <summary>
    /// Class EntityWithIntPk.
    /// Implements the <see cref="Noob.Domain.Entities.AggregateRoot{System.Int32}" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.AggregateRoot{System.Int32}" />
    public class EntityWithIntPk : AggregateRoot<int>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityWithIntPk"/> class.
        /// </summary>
        public EntityWithIntPk()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityWithIntPk"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public EntityWithIntPk(string name)
        {
            Name = name;
        }
    }
}
