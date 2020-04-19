// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="PersonRepository.cs" company="Noob.NUnitTests">
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
    /// Class PersonRepository.
    /// Implements the <see cref="Noob.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{Noob.TestApp.EntityFrameworkCore.TestAppDbContext, Noob.TestApp.Domain.Person, System.Guid}" />
    /// Implements the <see cref="Noob.TestApp.Domain.IPersonRepository" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{Noob.TestApp.EntityFrameworkCore.TestAppDbContext, Noob.TestApp.Domain.Person, System.Guid}" />
    /// <seealso cref="Noob.TestApp.Domain.IPersonRepository" />
    public class PersonRepository : EfCoreRepository<TestAppDbContext, Person, Guid>, IPersonRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        /// <param name="dbContextProvider">The database context provider.</param>
        public PersonRepository(IDbContextProvider<TestAppDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        /// <summary>
        /// get view as an asynchronous operation.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;PersonView&gt;.</returns>
        public async Task<PersonView> GetViewAsync(string name)
        {
            return await DbContext.PersonView.Where(x => x.Name == name).FirstOrDefaultAsync();
        }
    }
}