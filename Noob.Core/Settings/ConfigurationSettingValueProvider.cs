// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2019-12-08
// ***********************************************************************
// <copyright file="ConfigurationSettingValueProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Noob.DependencyInjection;

namespace Noob.Settings
{
    /// <summary>
    /// Class ConfigurationSettingValueProvider.
    /// Implements the <see cref="Noob.Settings.ISettingValueProvider" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.Settings.ISettingValueProvider" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class ConfigurationSettingValueProvider : ISettingValueProvider, ITransientDependency
    {
        /// <summary>
        /// The configuration name prefix
        /// </summary>
        public const string ConfigurationNamePrefix = "Settings:";

        /// <summary>
        /// The provider name
        /// </summary>
        public const string ProviderName = "C";

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name => ProviderName;

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        protected IConfiguration Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationSettingValueProvider"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ConfigurationSettingValueProvider(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the or null asynchronous.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public virtual Task<string> GetOrNullAsync(SettingDefinition setting)
        {
            return Task.FromResult(Configuration[ConfigurationNamePrefix + setting.Name]);
        }
    }
}