// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="ITypeFinder.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace Noob.Reflection
{
    /// <summary>
    /// Used to get types in the application.
    /// It may not return all types, but those are related with modules.
    /// </summary>
    public interface ITypeFinder
    {
        /// <summary>
        /// Gets the types.
        /// </summary>
        /// <value>The types.</value>
        IReadOnlyList<Type> Types { get; }
    }
}