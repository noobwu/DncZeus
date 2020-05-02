// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="IPagedAndSortedResultRequest.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Application.Dtos
{
    /// <summary>
    /// This interface is defined to standardize to request a paged and sorted result.
    /// Implements the <see cref="Noob.Application.Dtos.IPagedResultRequest" />
    /// Implements the <see cref="Noob.Application.Dtos.ISortedResultRequest" />
    /// </summary>
    /// <seealso cref="Noob.Application.Dtos.IPagedResultRequest" />
    /// <seealso cref="Noob.Application.Dtos.ISortedResultRequest" />
    public interface IPagedAndSortedResultRequest : IPagedResultRequest, ISortedResultRequest
    {
        
    }
}