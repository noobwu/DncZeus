// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IPersonRepository.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Noob.Domain.Repositories;

namespace Noob.TestApp.Domain
{
    /// <summary>
    /// Interface IPersonRepository
    /// Implements the <see cref="Noob.Domain.Repositories.IBasicRepository{Noob.TestApp.Domain.Person, System.Guid}" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Repositories.IBasicRepository{Noob.TestApp.Domain.Person, System.Guid}" />
    public interface IPersonRepository : IBasicRepository<Person, Guid>
    {
        /// <summary>
        /// Gets the view asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;PersonView&gt;.</returns>
        Task<PersonView> GetViewAsync(string name);
    }
}
