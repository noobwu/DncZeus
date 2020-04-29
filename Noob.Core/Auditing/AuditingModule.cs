// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="AuditingModule.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.DependencyInjection;
using Noob.Modularity;

namespace Noob.Auditing
{
    /// <summary>
    /// Class AuditingModule.
    /// Implements the <see cref="Noob.Modularity.Module" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.Module" />
    public class AuditingModule : Module
    {
        /// <summary>
        /// Pres the configure services.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.OnRegistred(AuditingInterceptorRegistrar.RegisterIfNeeded);
        }
    }
}
