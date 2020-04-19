// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="EntityFrameworkCoreModule.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Noob.Modularity;
using Noob.Uow.EntityFrameworkCore;
/// <summary>
/// The EntityFrameworkCore namespace.
/// </summary>
namespace Noob.EntityFrameworkCore
{
    //[DependsOn(typeof(AbpDddDomainModule))]
    /// <summary>
    /// Class EntityFrameworkCoreModule.
    /// Implements the <see cref="Noob.Modularity.Module" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.Module" />
    public class EntityFrameworkCoreModule :Module
    {
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //Configure<EfCoreDbContextOptions>(options =>
            //{
            //    options.PreConfigure(dbContextConfigurationContext =>
            //    {
            //        dbContextConfigurationContext.DbContextOptions
            //            .ConfigureWarnings(warnings =>
            //            {
            //                warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning);
            //            });
            //    });
            //});

            //context.Services.TryAddTransient(typeof(IDbContextProvider<>), typeof(UnitOfWorkDbContextProvider<>));
        }
    }
}
