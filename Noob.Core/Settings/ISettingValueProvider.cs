// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="ISettingValueProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Noob.Settings
{
    /// <summary>
    /// Interface ISettingValueProvider
    /// </summary>
    public interface ISettingValueProvider
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; }

        /// <summary>
        /// Gets the or null asynchronous.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetOrNullAsync([NotNull] SettingDefinition setting);
    }
}