// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IOnPostApplicationInitialization.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;

namespace Noob.Modularity
{
    /// <summary>
    /// Interface IOnPostApplicationInitialization
    /// </summary>
    public interface IOnPostApplicationInitialization
    {
        /// <summary>
        /// Called when [post application initialization].
        /// </summary>
        /// <param name="context">The context.</param>
        void OnPostApplicationInitialization([NotNull] ApplicationInitializationContext context);
    }
}