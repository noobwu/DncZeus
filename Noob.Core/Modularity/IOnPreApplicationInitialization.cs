// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IOnPreApplicationInitialization.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;

namespace Noob.Modularity
{
    /// <summary>
    /// Interface IOnPreApplicationInitialization
    /// </summary>
    public interface IOnPreApplicationInitialization
    {
        /// <summary>
        /// Called when [pre application initialization].
        /// </summary>
        /// <param name="context">The context.</param>
        void OnPreApplicationInitialization([NotNull] ApplicationInitializationContext context);
    }
}