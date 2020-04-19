// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ApplicationCreationOptions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Noob.Modularity.PlugIns;
namespace Noob
{
    /// <summary>
    /// Class ApplicationCreationOptions.
    /// </summary>
    public class ApplicationCreationOptions
    {
        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <value>The services.</value>
        [NotNull]
        public IServiceCollection Services { get; }
        /// <summary>
        /// Gets the plug in sources.
        /// </summary>
        /// <value>The plug in sources.</value>
        [NotNull]
        public PlugInSourceList PlugInSources { get; }
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        [NotNull]
        public ConfigurationBuilderOptions Configuration {get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationCreationOptions"/> class.
        /// </summary>
        /// <param name="services">The services.</param>
        public ApplicationCreationOptions([NotNull] IServiceCollection services)
        {
            Services = Check.NotNull(services, nameof(services));
            Configuration = new ConfigurationBuilderOptions();
        }
    }
}