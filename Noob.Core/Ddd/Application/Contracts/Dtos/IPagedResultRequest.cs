// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="IPagedResultRequest.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Application.Dtos
{
    /// <summary>
    /// This interface is defined to standardize to request a paged result.
    /// Implements the <see cref="Noob.Application.Dtos.ILimitedResultRequest" />
    /// </summary>
    /// <seealso cref="Noob.Application.Dtos.ILimitedResultRequest" />
    public interface IPagedResultRequest : ILimitedResultRequest
    {
        /// <summary>
        /// Skip count (beginning of the page).
        /// </summary>
        /// <value>The skip count.</value>
        int SkipCount { get; set; }
    }
}