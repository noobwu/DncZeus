// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-09
// ***********************************************************************
// <copyright file="ConfigurationHelper.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;

namespace Microsoft.Extensions.Configuration
{
    /// <summary>
    /// Class ConfigurationHelper.
    /// </summary>
    public static class ConfigurationHelper
    {
        /// <summary>
        /// Builds the configuration.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="builderAction">The builder action.</param>
        /// <returns>IConfigurationRoot.</returns>
        public static IConfigurationRoot BuildConfiguration(
            ConfigurationBuilderOptions options = null, 
            Action<IConfigurationBuilder> builderAction = null)
        {
            options = options ?? new ConfigurationBuilderOptions();

            if (options.BasePath.IsNullOrEmpty())
            {
                options.BasePath = Directory.GetCurrentDirectory();
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(options.BasePath)
                .AddJsonFile(options.FileName + ".json", optional: true, reloadOnChange: true);

            if (!options.EnvironmentName.IsNullOrEmpty())
            {
                builder = builder.AddJsonFile($"{options.FileName}.{options.EnvironmentName}.json", optional: true, reloadOnChange: true);
            }

            if (options.EnvironmentName == "Development")
            {
                if (options.UserSecretsId != null)
                {
                    builder.AddUserSecrets(options.UserSecretsId);
                }
                else if (options.UserSecretsAssembly != null)
                {
                    builder.AddUserSecrets(options.UserSecretsAssembly, true);
                }
            }

            builder = builder.AddEnvironmentVariables(options.EnvironmentVariablesPrefix);

            if (options.CommandLineArgs != null)
            {
                builder = builder.AddCommandLine(options.CommandLineArgs);
            }

            builderAction?.Invoke(builder);
            
            return builder.Build();
        }
    }
}
