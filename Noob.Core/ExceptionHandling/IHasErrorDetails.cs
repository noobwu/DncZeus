// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-01
// ***********************************************************************
// <copyright file="IHasErrorDetails.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.ExceptionHandling
{
    /// <summary>
    /// Interface IHasErrorDetails
    /// </summary>
    public interface IHasErrorDetails
    {
        /// <summary>
        /// Gets the details.
        /// </summary>
        /// <value>The details.</value>
        string Details { get; }
    }
}