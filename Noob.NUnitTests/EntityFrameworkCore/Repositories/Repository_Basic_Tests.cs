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
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Noob.Castle.DynamicProxy;
using Noob.Data;
using Noob.DependencyInjection;
using Noob.EntityFrameworkCore.DependencyInjection;
using Noob.Modularity;
using Noob.TestApp;
using Noob.TestApp.Domain;
using Noob.TestApp.EntityFrameworkCore;
using Noob.TestApp.Testing;
using Noob.Uow;
using Noob.Uow.EntityFrameworkCore;
using Noob.Modularity.PlugIns;

namespace Noob.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Class Repository_Basic_Tests.
    /// Implements the <see cref="Noob.TestApp.Testing.Repository_Basic_Tests{Noob.EntityFrameworkCore.Repositories.Repository_Basic_Tests}" />
    /// </summary>
    /// <seealso cref="Noob.TestApp.Testing.Repository_Basic_Tests{Noob.EntityFrameworkCore.Repositories.Repository_Basic_Tests}" />
    public class Repository_Basic_Tests : Repository_Basic_Tests<EntityFrameworkCoreModule>
    {

        /// <summary>
        /// Sets the abp application creation options.
        /// </summary>
        /// <param name="options">The options.</param>
        protected override void SetApplicationCreationOptions(ApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
