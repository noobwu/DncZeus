// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="AutofacServiceCollectionExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Autofac;
using JetBrains.Annotations;
using Noob;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class AutofacServiceCollectionExtensions.
    /// </summary>
    public static class AutofacServiceCollectionExtensions
    {
        /// <summary>
        /// Gets the container builder.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>ContainerBuilder.</returns>
        /// <exception cref="Exception">Could not find ContainerBuilder. Be sure that you have called {nameof(AbpAutofacAbpApplicationCreationOptionsExtensions.UseAutofac)} method before!</exception>
        [NotNull]
        public static ContainerBuilder GetContainerBuilder([NotNull] this IServiceCollection services)
        {
            Check.NotNull(services, nameof(services));

            var builder = services.GetObjectOrNull<ContainerBuilder>();
            if (builder == null)
            {
                throw new Exception($"Could not find ContainerBuilder. Be sure that you have called {nameof(AutofacApplicationCreationOptionsExtensions.UseAutofac)} method before!");
            }

            return builder;
        }

        /// <summary>
        /// Builds the autofac service provider.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="builderAction">The builder action.</param>
        /// <returns>IServiceProvider.</returns>
        public static IServiceProvider BuildAutofacServiceProvider([NotNull] this IServiceCollection services, Action<ContainerBuilder> builderAction = null)
        {
	        return services.BuildServiceProviderFromFactory(builderAction);
        }
	}
}
