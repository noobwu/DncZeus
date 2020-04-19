// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IConventionalRegistrar.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Noob.DependencyInjection
{
    /// <summary>
    /// Interface IConventionalRegistrar
    /// </summary>
    public interface IConventionalRegistrar
    {
        /// <summary>
        /// Adds the assembly.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="assembly">The assembly.</param>
        void AddAssembly(IServiceCollection services, Assembly assembly);

        /// <summary>
        /// Adds the types.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="types">The types.</param>
        void AddTypes(IServiceCollection services, params Type[] types);

        /// <summary>
        /// Adds the type.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="type">The type.</param>
        void AddType(IServiceCollection services, Type type);
    }
}
