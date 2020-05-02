// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="ILimitedResultRequest.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Application.Dtos
{
    /// <summary>
    /// This interface is defined to standardize to request a limited result.
    /// </summary>
    public interface ILimitedResultRequest
    {
        /// <summary>
        /// Maximum result count should be returned.
        /// This is generally used to limit result count on paging.
        /// </summary>
        /// <value>The maximum result count.</value>
        int MaxResultCount { get; set; }
    }
}