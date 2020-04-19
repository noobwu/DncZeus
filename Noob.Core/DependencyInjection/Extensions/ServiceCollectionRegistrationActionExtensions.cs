// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ServiceCollectionRegistrationActionExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Noob.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class ServiceCollectionRegistrationActionExtensions.
    /// </summary>
    public static class ServiceCollectionRegistrationActionExtensions
    {
        // OnRegistred

        /// <summary>
        /// Called when [registred].
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="registrationAction">The registration action.</param>
        public static void OnRegistred(this IServiceCollection services, Action<IOnServiceRegistredContext> registrationAction)
        {
            GetOrCreateRegistrationActionList(services).Add(registrationAction);
        }

        /// <summary>
        /// Gets the registration action list.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>ServiceRegistrationActionList.</returns>
        public static ServiceRegistrationActionList GetRegistrationActionList(this IServiceCollection services)
        {
            return GetOrCreateRegistrationActionList(services);
        }

        /// <summary>
        /// Gets the or create registration action list.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>ServiceRegistrationActionList.</returns>
        private static ServiceRegistrationActionList GetOrCreateRegistrationActionList(IServiceCollection services)
        {
            var actionList = services.GetSingletonInstanceOrNull<IObjectAccessor<ServiceRegistrationActionList>>()?.Value;
            if (actionList == null)
            {
                actionList = new ServiceRegistrationActionList();
                services.AddObjectAccessor(actionList);
            }

            return actionList;
        }

        // OnExposing

        /// <summary>
        /// Called when [exposing].
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="exposeAction">The expose action.</param>
        public static void OnExposing(this IServiceCollection services, Action<IOnServiceExposingContext> exposeAction)
        {
            GetOrCreateExposingList(services).Add(exposeAction);
        }

        /// <summary>
        /// Gets the exposing action list.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>ServiceExposingActionList.</returns>
        public static ServiceExposingActionList GetExposingActionList(this IServiceCollection services)
        {
            return GetOrCreateExposingList(services);
        }

        /// <summary>
        /// Gets the or create exposing list.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>ServiceExposingActionList.</returns>
        private static ServiceExposingActionList GetOrCreateExposingList(IServiceCollection services)
        {
            var actionList = services.GetSingletonInstanceOrNull<IObjectAccessor<ServiceExposingActionList>>()?.Value;
            if (actionList == null)
            {
                actionList = new ServiceExposingActionList();
                services.AddObjectAccessor(actionList);
            }

            return actionList;
        }
    }
}
