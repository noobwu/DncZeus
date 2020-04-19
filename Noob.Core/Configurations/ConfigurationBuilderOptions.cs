// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2019-10-22
// ***********************************************************************
// <copyright file="AbpConfigurationBuilderOptions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Reflection;

namespace Microsoft.Extensions.Configuration
{
    /// <summary>
    /// Class ConfigurationBuilderOptions.
    /// </summary>
    public class ConfigurationBuilderOptions
    {
        /// <summary>
        /// Used to set assembly which is used to get the user secret id for the application.
        /// Use this or <see cref="UserSecretsId" /> (higher priority)
        /// </summary>
        /// <value>The user secrets assembly.</value>
        public Assembly UserSecretsAssembly { get; set; }

        /// <summary>
        /// Used to set user secret id for the application.
        /// Use this (higher priority) or <see cref="UserSecretsAssembly" />
        /// </summary>
        /// <value>The user secrets identifier.</value>
        public string UserSecretsId { get; set; }

        /// <summary>
        /// Default value: "appsettings".
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; set; } = "appsettings";

        /// <summary>
        /// Environment name. Generally used "Development", "Staging" or "Production".
        /// </summary>
        /// <value>The name of the environment.</value>
        public string EnvironmentName { get; set; }

        /// <summary>
        /// Base path to read the configuration file indicated by <see cref="FileName" />.
        /// </summary>
        /// <value>The base path.</value>
        public string BasePath { get; set; }

        /// <summary>
        /// Prefix for the environment variables.
        /// </summary>
        /// <value>The environment variables prefix.</value>
        public string EnvironmentVariablesPrefix { get; set; }

        /// <summary>
        /// Command line arguments.
        /// </summary>
        /// <value>The command line arguments.</value>
        public string[] CommandLineArgs { get; set; }
    }
}