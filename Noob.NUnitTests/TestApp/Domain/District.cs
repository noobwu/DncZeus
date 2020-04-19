// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="District.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.Domain.Entities;
using System;
namespace Noob.TestApp.Domain
{
    /// <summary>
    /// Class District.
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    public class District : Entity
    {
        /// <summary>
        /// Gets the city identifier.
        /// </summary>
        /// <value>The city identifier.</value>
        public Guid CityId { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the population.
        /// </summary>
        /// <value>The population.</value>
        public int Population { get; set; }

        /// <summary>
        /// Prevents a default instance of the <see cref="District"/> class from being created.
        /// </summary>
        private District()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="District"/> class.
        /// </summary>
        /// <param name="cityId">The city identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="population">The population.</param>
        public District(Guid cityId, string name, int population = 0)
        {
            CityId = cityId;
            Name = name;
        }

        /// <summary>
        /// Returns an array of ordered keys for this entity.
        /// </summary>
        /// <returns>System.Object[].</returns>
        public override object[] GetKeys()
        {
            return new Object[] {CityId, Name};
        }
    }
}