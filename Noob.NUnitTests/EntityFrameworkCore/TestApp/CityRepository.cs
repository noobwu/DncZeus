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
    /// Class EntityWithIntPkRepository.
    /// Implements the <see cref="Noob.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{Noob.TestApp.EntityFrameworkCore.TestAppDbContext, Noob.TestApp.Domain.EntityWithIntPk, System.Int32}" />
    /// Implements the <see cref="Noob.TestApp.Domain.IEntityWithIntPkRepository" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{Noob.TestApp.EntityFrameworkCore.TestAppDbContext, Noob.TestApp.Domain.EntityWithIntPk, System.Int32}" />
    /// <seealso cref="Noob.TestApp.Domain.IEntityWithIntPkRepository" />
    public class EntityWithIntPkRepository : EfCoreRepository<TestAppDbContext, EntityWithIntPk, int>, IEntityWithIntPkRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CityRepository" /> class.
        /// </summary>
        /// <param name="dbContextProvider">The database context provider.</param>
        public EntityWithIntPkRepository(IDbContextProvider<TestAppDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}
