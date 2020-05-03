// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="SettingValueProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;
using Noob.DependencyInjection;

namespace Noob.Settings
{
    /// <summary>
    /// Class SettingValueProvider.
    /// Implements the <see cref="Noob.Settings.ISettingValueProvider" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.Settings.ISettingValueProvider" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public abstract class SettingValueProvider : ISettingValueProvider, ITransientDependency
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the setting store.
        /// </summary>
        /// <value>The setting store.</value>
        protected ISettingStore SettingStore { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingValueProvider"/> class.
        /// </summary>
        /// <param name="settingStore">The setting store.</param>
        protected SettingValueProvider(ISettingStore settingStore)
        {
            SettingStore = settingStore;
        }

        /// <summary>
        /// Gets the or null asynchronous.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public abstract Task<string> GetOrNullAsync(SettingDefinition setting);
    }
}