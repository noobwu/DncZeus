// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="City.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using Noob.Domain.Entities;

namespace Noob.TestApp.Domain
{
    /// <summary>
    /// Class City.
    /// Implements the <see cref="Noob.Domain.Entities.AggregateRoot{System.Guid}" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.AggregateRoot{System.Guid}" />
    public class City : AggregateRoot<Guid>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the districts.
        /// </summary>
        /// <value>The districts.</value>
        public ICollection<District> Districts { get; set; }

        /// <summary>
        /// Prevents a default instance of the <see cref="City"/> class from being created.
        /// </summary>
        private City()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="City"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        public City(Guid id, string name)
            : base(id)
        {
            Name = name;
            Districts = new List<District>();
        }

        /// <summary>
        /// Gets the population.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetPopulation()
        {
            return Districts.Select(d => d.Population).Sum();
        }
    }
}
