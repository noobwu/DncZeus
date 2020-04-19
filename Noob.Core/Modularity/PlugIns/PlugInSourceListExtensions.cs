// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="PlugInSourceListExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using JetBrains.Annotations;

namespace Noob.Modularity.PlugIns
{
    /// <summary>
    /// Class PlugInSourceListExtensions.
    /// </summary>
    public static class PlugInSourceListExtensions
    {
        /// <summary>
        /// Adds the folder.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="folder">The folder.</param>
        /// <param name="searchOption">The search option.</param>
        public static void AddFolder(
            [NotNull] this PlugInSourceList list, 
            [NotNull] string folder, 
            SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            Check.NotNull(list, nameof(list));

            list.Add(new FolderPlugInSource(folder, searchOption));
        }

        /// <summary>
        /// Adds the types.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="moduleTypes">The module types.</param>
        public static void AddTypes(
            [NotNull] this PlugInSourceList list, 
            params Type[] moduleTypes)
        {
            Check.NotNull(list, nameof(list));

            list.Add(new TypePlugInSource(moduleTypes));
        }

        /// <summary>
        /// Adds the files.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="filePaths">The file paths.</param>
        public static void AddFiles(
            [NotNull] this PlugInSourceList list,
            params string[] filePaths)
        {
            Check.NotNull(list, nameof(list));

            list.Add(new FilePlugInSource(filePaths));
        }
    }
}