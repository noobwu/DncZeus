// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="Repository_Basic_Tests.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.Domain.Repositories;
using Noob.TestApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Noob.TestApp.Testing
{
    /// <summary>
    /// Class Repository_Basic_Tests.
    /// Implements the <see cref="Noob.IntegratedTest{TStartupModule}" />
    /// </summary>
    /// <typeparam name="TStartupModule">The type of the t startup module.</typeparam>
    /// <seealso cref="Noob.IntegratedTest{TStartupModule}" />
    public abstract class Repository_Basic_Tests<TStartupModule> : IntegratedTest<TStartupModule>
          where TStartupModule : class
    {
        /// <summary>
        /// The person repository
        /// </summary>
        protected readonly IRepository<Person, Guid> PersonRepository;
        /// <summary>
        /// The city repository
        /// </summary>
        protected readonly ICityRepository CityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository_Basic_Tests{TStartupModule}"/> class.
        /// </summary>
        protected Repository_Basic_Tests()
        {
            PersonRepository = GetRequiredService<IRepository<Person, Guid>>();
            CityRepository = GetRequiredService<ICityRepository>();
        }
    }
}
