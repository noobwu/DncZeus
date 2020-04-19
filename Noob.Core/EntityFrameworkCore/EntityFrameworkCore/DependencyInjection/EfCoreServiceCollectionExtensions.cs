// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="EfCoreServiceCollectionExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Noob.EntityFrameworkCore;
using Noob.EntityFrameworkCore.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class EfCoreServiceCollectionExtensions.
    /// </summary>
    public static class EfCoreServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the ef core database context.
        /// </summary>
        /// <typeparam name="TDbContext">The type of the t database context.</typeparam>
        /// <param name="services">The services.</param>
        /// <param name="optionsBuilder">The options builder.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddEfCoreDbContext<TDbContext>(
            this IServiceCollection services, 
            Action<IEfCoreDbContextRegistrationOptionsBuilder> optionsBuilder = null)
            where TDbContext :EfCoreDbContext<TDbContext>
        {
            services.AddMemoryCache();

            var options = new EfCoreDbContextRegistrationOptions(typeof(TDbContext), services);
            optionsBuilder?.Invoke(options);

            services.TryAddTransient(DbContextOptionsFactory.Create<TDbContext>);

            foreach (var dbContextType in options.ReplacedDbContextTypes)
            {
                services.Replace(ServiceDescriptor.Transient(dbContextType, typeof(TDbContext)));
            }

            new EfCoreRepositoryRegistrar(options).AddRepositories();

            return services;
        }
    }
}
