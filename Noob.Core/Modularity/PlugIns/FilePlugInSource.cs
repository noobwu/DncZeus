// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="FilePlugInSource.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Runtime.Loader;

namespace Noob.Modularity.PlugIns
{
    /// <summary>
    /// Class FilePlugInSource.
    /// Implements the <see cref="Noob.Modularity.PlugIns.IPlugInSource" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.PlugIns.IPlugInSource" />
    public class FilePlugInSource : IPlugInSource
    {
        /// <summary>
        /// Gets the file paths.
        /// </summary>
        /// <value>The file paths.</value>
        public string[] FilePaths { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilePlugInSource"/> class.
        /// </summary>
        /// <param name="filePaths">The file paths.</param>
        public FilePlugInSource(params string[] filePaths)
        {
            FilePaths = filePaths ?? new string[0];
        }

        /// <summary>
        /// Gets the modules.
        /// </summary>
        /// <returns>Type[].</returns>
        /// <exception cref="Exception">Could not get module types from assembly: " + assembly.FullName</exception>
        public Type[] GetModules()
        {
            var modules = new List<Type>();

            foreach (var filePath in FilePaths)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(filePath);

                try
                {
                    foreach (var type in assembly.GetTypes())
                    {
                        if (Module.IsModule(type))
                        {
                            modules.AddIfNotContains(type);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Could not get module types from assembly: " + assembly.FullName, ex);
                }
            }

            return modules.ToArray();
        }
    }
}