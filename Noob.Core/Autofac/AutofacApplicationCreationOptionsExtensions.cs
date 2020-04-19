// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="AutofacApplicationCreationOptionsExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Noob.Autofac;

namespace Noob
{
    /// <summary>
    /// Class AutofacApplicationCreationOptionsExtensions.
    /// </summary>
    public static class AutofacApplicationCreationOptionsExtensions
    {
        /// <summary>
        /// Uses the autofac.
        /// </summary>
        /// <param name="options">The options.</param>
        public static void UseAutofac(this ApplicationCreationOptions options)
        {
            var builder = new ContainerBuilder();
            options.Services.AddObjectAccessor(builder);
            options.Services.AddSingleton((IServiceProviderFactory<ContainerBuilder>) new AutofacServiceProviderFactory(builder));
        }
    }
}
