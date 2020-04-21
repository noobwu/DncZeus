// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="DataModule.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Noob.Modularity;
using Noob.ObjectExtending;
using Noob.Uow;

namespace Noob.Data
{
    //[DependsOn( typeof(ObjectExtendingModule),typeof(UnitOfWorkModule))]
    /// <summary>
    /// Class DataModule.
    /// Implements the <see cref="Noob.Modularity.Module" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.Module" />
    [DependsOn(typeof(UnitOfWorkModule))]
    public class DataModule : Module
    {
        /// <summary>
        /// Pres the configure services.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            AutoAddDataSeedContributors(context.Services);
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            Configure<DbConnectionOptions>(configuration);

            //context.Services.AddSingleton(typeof(IDataFilter<>), typeof(DataFilter<>));
        }

        /// <summary>
        /// Automatics the add data seed contributors.
        /// </summary>
        /// <param name="services">The services.</param>
        private static void AutoAddDataSeedContributors(IServiceCollection services)
        {
            var contributors = new List<Type>();

            //services.OnRegistred(context =>
            //{
            //    if (typeof(IDataSeedContributor).IsAssignableFrom(context.ImplementationType))
            //    {
            //        contributors.Add(context.ImplementationType);
            //    }
            //});

            //services.Configure<DataSeedOptions>(options =>
            //{
            //    options.Contributors.AddIfNotContains(contributors);
            //});
        }
    }
}
