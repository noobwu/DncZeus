// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="AssemblyHelper.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

/// <summary>
/// The Reflection namespace.
/// </summary>
namespace Noob.Reflection
{
    /// <summary>
    /// Class AssemblyHelper.
    /// </summary>
    internal static class AssemblyHelper
    {
        /// <summary>
        /// Loads the assemblies.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        /// <param name="searchOption">The search option.</param>
        /// <returns>List&lt;Assembly&gt;.</returns>
        public static List<Assembly> LoadAssemblies(string folderPath, SearchOption searchOption)
        {
            return GetAssemblyFiles(folderPath, searchOption)
                .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                .ToList();
        }

        /// <summary>
        /// Gets the assembly files.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        /// <param name="searchOption">The search option.</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public static IEnumerable<string> GetAssemblyFiles(string folderPath, SearchOption searchOption)
        {
            return Directory
                .EnumerateFiles(folderPath, "*.*", searchOption)
                .Where(s => s.EndsWith(".dll") || s.EndsWith(".exe"));
        }

        /// <summary>
        /// Gets all types.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>IReadOnlyList&lt;Type&gt;.</returns>
        public static IReadOnlyList<Type> GetAllTypes(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                return ex.Types;
            }
        }
    }
}
