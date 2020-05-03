// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="ISettingDefinitionManager.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Noob.Settings
{
    /// <summary>
    /// Interface ISettingDefinitionManager
    /// </summary>
    public interface ISettingDefinitionManager
    {
        /// <summary>
        /// Gets the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>SettingDefinition.</returns>
        [NotNull]
        SettingDefinition Get([NotNull] string name);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IReadOnlyList&lt;SettingDefinition&gt;.</returns>
        IReadOnlyList<SettingDefinition> GetAll();

        /// <summary>
        /// Gets the or null.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>SettingDefinition.</returns>
        SettingDefinition GetOrNull(string name);
    }
}