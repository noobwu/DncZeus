// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2019-10-22
// ***********************************************************************
// <copyright file="DefaultValueSettingValueProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;

namespace Noob.Settings
{
    /// <summary>
    /// Class DefaultValueSettingValueProvider.
    /// Implements the <see cref="Noob.Settings.SettingValueProvider" />
    /// </summary>
    /// <seealso cref="Noob.Settings.SettingValueProvider" />
    public class DefaultValueSettingValueProvider : SettingValueProvider
    {
        /// <summary>
        /// The provider name
        /// </summary>
        public const string ProviderName = "D";

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public override string Name => ProviderName;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultValueSettingValueProvider"/> class.
        /// </summary>
        /// <param name="settingStore">The setting store.</param>
        public DefaultValueSettingValueProvider(ISettingStore settingStore) 
            : base(settingStore)
        {

        }

        /// <summary>
        /// Gets the or null asynchronous.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public override Task<string> GetOrNullAsync(SettingDefinition setting)
        {
            return Task.FromResult(setting.DefaultValue);
        }
    }
}