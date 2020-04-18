// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="ServiceConfigurationContext.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Noob.Modularity
{
    /// <summary>
    /// Class ServiceConfigurationContext.
    /// </summary>
    public class ServiceConfigurationContext
    {
        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <value>The services.</value>
        public IServiceCollection Services { get; }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public IDictionary<string, object> Items { get; }

        /// <summary>
        /// Gets/sets arbitrary named objects those can be stored during
        /// the service registration phase and shared between modules.
        /// This is a shortcut usage of the <see cref="Items" /> dictionary.
        /// Returns null if given key is not found in the <see cref="Items" /> dictionary.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.Object.</returns>
        public object this[string key]
        {
            get => Items.GetOrDefault(key);
            set => Items[key] = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceConfigurationContext" /> class.
        /// </summary>
        /// <param name="services">The services.</param>
        public ServiceConfigurationContext([NotNull] IServiceCollection services)
        {
            Services = Check.NotNull(services, nameof(services));
            Items = new Dictionary<string, object>();
        }
    }
}