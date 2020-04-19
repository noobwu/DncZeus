// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="CityRepository.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Noob.Domain.Repositories.EntityFrameworkCore;
using Noob.EntityFrameworkCore;
using Noob.TestApp.Domain;

namespace Noob.TestApp.EntityFrameworkCore
{
    /// <summary>
    /// Class CityRepository.
    /// Implements the <see cref="Noob.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{Noob.TestApp.EntityFrameworkCore.TestAppDbContext, Noob.TestApp.Domain.City, System.Guid}" />
    /// Implements the <see cref="Noob.TestApp.Domain.ICityRepository" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{Noob.TestApp.EntityFrameworkCore.TestAppDbContext, Noob.TestApp.Domain.City, System.Guid}" />
    /// <seealso cref="Noob.TestApp.Domain.ICityRepository" />
    public class CityRepository : EfCoreRepository<TestAppDbContext, City, Guid>, ICityRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CityRepository"/> class.
        /// </summary>
        /// <param name="dbContextProvider">The database context provider.</param>
        public CityRepository(IDbContextProvider<TestAppDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        /// <summary>
        /// find by name as an asynchronous operation.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;City&gt;.</returns>
        public async Task<City> FindByNameAsync(string name)
        {
            return await this.FirstOrDefaultAsync(c => c.Name == name);
        }

        /// <summary>
        /// get people in the city as an asynchronous operation.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        /// <returns>Task&lt;List&lt;Person&gt;&gt;.</returns>
        public async Task<List<Person>> GetPeopleInTheCityAsync(string cityName)
        {
            var city = await FindByNameAsync(cityName);
            return await DbContext.People.Where(p => p.CityId == city.Id).ToListAsync();
        }
    }
}
