// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IApplicationWithInternalServiceProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob
{
    /// <summary>
    /// Interface IApplicationWithInternalServiceProvider
    /// Implements the <see cref="Noob.IApplication" />
    /// </summary>
    /// <seealso cref="Noob.IApplication" />
    public interface IApplicationWithInternalServiceProvider : IApplication
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        void Initialize();
    }
}