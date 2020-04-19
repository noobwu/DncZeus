// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2019-03-03
// ***********************************************************************
// <copyright file="ServiceCollectionPreConfigureExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.DependencyInjection;
using Noob.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class ServiceCollectionPreConfigureExtensions.
    /// </summary>
    public static class ServiceCollectionPreConfigureExtensions
    {
        /// <summary>
        /// Pres the configure.
        /// </summary>
        /// <typeparam name="TOptions">The type of the t options.</typeparam>
        /// <param name="services">The services.</param>
        /// <param name="optionsAction">The options action.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection PreConfigure<TOptions>(this IServiceCollection services, Action<TOptions> optionsAction)
        {
            services.GetPreConfigureActions<TOptions>().Add(optionsAction);
            return services;
        }

        /// <summary>
        /// Executes the pre configured actions.
        /// </summary>
        /// <typeparam name="TOptions">The type of the t options.</typeparam>
        /// <param name="services">The services.</param>
        /// <returns>TOptions.</returns>
        public static TOptions ExecutePreConfiguredActions<TOptions>(this IServiceCollection services)
            where TOptions : new()
        {
            return services.ExecutePreConfiguredActions(new TOptions());
        }

        /// <summary>
        /// Executes the pre configured actions.
        /// </summary>
        /// <typeparam name="TOptions">The type of the t options.</typeparam>
        /// <param name="services">The services.</param>
        /// <param name="options">The options.</param>
        /// <returns>TOptions.</returns>
        public static TOptions ExecutePreConfiguredActions<TOptions>(this IServiceCollection services, TOptions options)
        {
            services.GetPreConfigureActions<TOptions>().Configure(options);
            return options;
        }

        /// <summary>
        /// Gets the pre configure actions.
        /// </summary>
        /// <typeparam name="TOptions">The type of the t options.</typeparam>
        /// <param name="services">The services.</param>
        /// <returns>PreConfigureActionList&lt;TOptions&gt;.</returns>
        public static PreConfigureActionList<TOptions> GetPreConfigureActions<TOptions>(this IServiceCollection services)
        {
            var actionList = services.GetSingletonInstanceOrNull<IObjectAccessor<PreConfigureActionList<TOptions>>>()?.Value;
            if (actionList == null)
            {
                actionList = new PreConfigureActionList<TOptions>();
                services.AddObjectAccessor(actionList);
            }

            return actionList;
        }
    }
}
