// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ICityRepository.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Noob.Domain.Repositories;

namespace Noob.TestApp.Domain
{
    /// <summary>
    /// Interface ICityRepository
    /// Implements the <see cref="Noob.Domain.Repositories.IBasicRepository{Noob.TestApp.Domain.City, System.Guid}" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Repositories.IBasicRepository{Noob.TestApp.Domain.City, System.Guid}" />
    public interface ICityRepository : IBasicRepository<City, Guid>
    {
        /// <summary>
        /// Finds the by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;City&gt;.</returns>
        Task<City> FindByNameAsync(string name);

        /// <summary>
        /// Gets the people in the city asynchronous.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        /// <returns>Task&lt;List&lt;Person&gt;&gt;.</returns>
        Task<List<Person>> GetPeopleInTheCityAsync(string cityName);
    }
}
