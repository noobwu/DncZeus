// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="ISettingDefinitionProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Settings
{
    /// <summary>
    /// Interface ISettingDefinitionProvider
    /// </summary>
    public interface ISettingDefinitionProvider
    {
        /// <summary>
        /// Defines the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        void Define(ISettingDefinitionContext context);
    }
}