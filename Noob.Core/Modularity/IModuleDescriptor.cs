// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2019-03-03
// ***********************************************************************
// <copyright file="IModuleDescriptor.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Noob.Modularity
{
    /// <summary>
    /// Interface IModuleDescriptor
    /// </summary>
    public interface IModuleDescriptor
    {
        /// <summary>
        /// 模块的具体类型。
        /// </summary>
        /// <value>The type.</value>
        Type Type { get; }

        /// <summary>
        /// 模块所在的程序集。
        /// </summary>
        /// <value>The assembly.</value>
        Assembly Assembly { get; }

        /// <summary>
        /// 模块的单例实例。
        /// </summary>
        /// <value>The instance.</value>
        IModule Instance { get; }

        /// <summary>
        /// 是否是一个插件。
        /// </summary>
        /// <value><c>true</c> if this instance is loaded as plug in; otherwise, <c>false</c>.</value>
        bool IsLoadedAsPlugIn { get; }

        /// <summary>
        /// 依赖的其他模块。
        /// </summary>
        /// <value>The dependencies.</value>
        IReadOnlyList<IModuleDescriptor> Dependencies { get; }
    }
}