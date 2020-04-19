// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IOnApplicationInitialization.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;

namespace Noob
{
    /// <summary>
    /// Interface IOnApplicationInitialization
    /// </summary>
    public interface IOnApplicationInitialization
    {
        /// <summary>
        /// Called when [application initialization].
        /// </summary>
        /// <param name="context">The context.</param>
        void OnApplicationInitialization([NotNull] ApplicationInitializationContext context);
    }
}