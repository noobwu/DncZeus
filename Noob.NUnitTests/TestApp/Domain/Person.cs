// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="Person.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.ObjectModel;
using Noob.Domain.Entities;

namespace Noob.TestApp.Domain
{
    /// <summary>
    /// Class Person.
    /// Implements the <see cref="Noob.Domain.Entities.AggregateRoot{System.Guid}" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.AggregateRoot{System.Guid}" />
    public class Person : AggregateRoot<Guid>
    {

        /// <summary>
        /// Gets or sets the city identifier.
        /// </summary>
        /// <value>The city identifier.</value>
        public virtual Guid? CityId { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public virtual string Name { get; private set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>The age.</value>
        public virtual int Age { get; set; }

        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        public virtual DateTime? Birthday { get; set; }

        /// <summary>
        /// Gets or sets the last active.
        /// </summary>
        /// <value>The last active.</value>
        public virtual DateTime? LastActive { get; set; }

        /// <summary>
        /// Gets or sets the phones.
        /// </summary>
        /// <value>The phones.</value>
        public virtual Collection<Phone> Phones { get; set; }

        /// <summary>
        /// Prevents a default instance of the <see cref="Person"/> class from being created.
        /// </summary>
        private Person()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="age">The age.</param>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="cityId">The city identifier.</param>
        public Person(Guid id, string name, int age, Guid? cityId = null)
            : base(id)
        {
            Name = name;
            Age = age;
            CityId = cityId;

            Phones = new Collection<Phone>();
        }

        /// <summary>
        /// Changes the name.
        /// </summary>
        /// <param name="name">The name.</param>
        public virtual void ChangeName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var oldName = Name;
            Name = name;
        }
    }
}