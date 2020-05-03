// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="NullSettingStore.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Noob.DependencyInjection;

namespace Noob.Settings
{
    /// <summary>
    /// Class NullSettingStore.
    /// Implements the <see cref="Noob.Settings.ISettingStore" />
    /// Implements the <see cref="Noob.DependencyInjection.ISingletonDependency" />
    /// </summary>
    /// <seealso cref="Noob.Settings.ISettingStore" />
    /// <seealso cref="Noob.DependencyInjection.ISingletonDependency" />
    [Dependency(TryRegister = true)]
    public class NullSettingStore : ISettingStore, ISingletonDependency
    {
        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        /// <value>The logger.</value>
        public ILogger<NullSettingStore> Logger { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullSettingStore"/> class.
        /// </summary>
        public NullSettingStore()
        {
            Logger = NullLogger<NullSettingStore>.Instance;
        }

        /// <summary>
        /// Gets the or null asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="providerName">Name of the provider.</param>
        /// <param name="providerKey">The provider key.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public Task<string> GetOrNullAsync(string name, string providerName, string providerKey)
        {
            return Task.FromResult((string) null);
        }
    }
}