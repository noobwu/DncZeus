// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2019-03-03
// ***********************************************************************
// <copyright file="ISettingDefinitionContext.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Settings
{
    /// <summary>
    /// Interface ISettingDefinitionContext
    /// </summary>
    public interface ISettingDefinitionContext
    {
        /// <summary>
        /// Gets the or null.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>SettingDefinition.</returns>
        SettingDefinition GetOrNull(string name);

        /// <summary>
        /// Adds the specified definitions.
        /// </summary>
        /// <param name="definitions">The definitions.</param>
        void Add(params SettingDefinition[] definitions);
    }
}