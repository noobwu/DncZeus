// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2019-03-03
// ***********************************************************************
// <copyright file="IHasErrorCode.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.ExceptionHandling
{
    /// <summary>
    /// Interface IHasErrorCode
    /// </summary>
    public interface IHasErrorCode
    {
        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>The code.</value>
        string Code { get; }
    }
}