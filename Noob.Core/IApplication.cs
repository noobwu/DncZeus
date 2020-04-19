// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="IApplication.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Noob.Modularity;
namespace Noob
{
    /// <summary>
    /// Interface IApplication
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IApplication : IModuleContainer, IDisposable
    {
        /// <summary>
        /// Type of the startup (entrance) module of the application.
        /// </summary>
        /// <value>The type of the startup module.</value>
        Type StartupModuleType { get; }

        /// <summary>
        /// List of services registered to this application.
        /// Can not add new services to this collection after application initialize.
        /// </summary>
        /// <value>The services.</value>
        IServiceCollection Services { get; }

        /// <summary>
        /// Reference to the root service provider used by the application.
        /// This can not be used before initialize the application.
        /// </summary>
        /// <value>The service provider.</value>
        IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Used to gracefully shutdown the application and all modules.
        /// </summary>
        void Shutdown();
    }
}
