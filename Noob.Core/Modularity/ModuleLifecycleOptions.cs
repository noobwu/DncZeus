// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ModuleLifecycleOptions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.Collections;

namespace Noob.Modularity
{
    /// <summary>
    /// Class ModuleLifecycleOptions.
    /// </summary>
    public class ModuleLifecycleOptions
    {
        /// <summary>
        /// Gets the contributors.
        /// </summary>
        /// <value>The contributors.</value>
        public ITypeList<IModuleLifecycleContributor> Contributors { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleLifecycleOptions"/> class.
        /// </summary>
        public ModuleLifecycleOptions()
        {
            Contributors = new TypeList<IModuleLifecycleContributor>();
        }
    }
}
