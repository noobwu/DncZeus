// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="TestSettingValueProvider.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using Noob.DependencyInjection;

namespace Noob.Settings
{
    /// <summary>
    /// Class TestSettingValueProvider.
    /// Implements the <see cref="Noob.Settings.ISettingValueProvider" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.Settings.ISettingValueProvider" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class TestSettingValueProvider : ISettingValueProvider, ITransientDependency
    {
        /// <summary>
        /// The provider name
        /// </summary>
        public const string ProviderName = "Test";

        /// <summary>
        /// The values
        /// </summary>
        private readonly Dictionary<string, string> _values;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name => ProviderName;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestSettingValueProvider"/> class.
        /// </summary>
        public TestSettingValueProvider() 
        {
            _values = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets the or null asynchronous.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public Task<string> GetOrNullAsync(SettingDefinition setting)
        {
            return Task.FromResult(_values.GetOrDefault(setting.Name));
        }
    }
}
