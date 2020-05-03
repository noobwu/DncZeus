// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="SettingDefinitionProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.DependencyInjection;

namespace Noob.Settings
{
    /// <summary>
    /// Class SettingDefinitionProvider.
    /// Implements the <see cref="Noob.Settings.ISettingDefinitionProvider" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.Settings.ISettingDefinitionProvider" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public abstract class SettingDefinitionProvider : ISettingDefinitionProvider, ITransientDependency
    {
        /// <summary>
        /// Defines the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public abstract void Define(ISettingDefinitionContext context);
    }
}