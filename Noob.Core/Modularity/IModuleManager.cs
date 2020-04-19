// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IModuleManager.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;

namespace Noob.Modularity
{
    /// <summary>
    /// Interface IModuleManager
    /// </summary>
    public interface IModuleManager
    {
        /// <summary>
        /// Initializes the modules.
        /// </summary>
        /// <param name="context">The context.</param>
        void InitializeModules([NotNull] ApplicationInitializationContext context);

        /// <summary>
        /// Shutdowns the modules.
        /// </summary>
        /// <param name="context">The context.</param>
        void ShutdownModules([NotNull] ApplicationShutdownContext context);
    }
}
