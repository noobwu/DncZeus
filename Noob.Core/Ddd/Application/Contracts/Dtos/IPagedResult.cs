// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="IPagedResult.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Application.Dtos
{
    /// <summary>
    /// This interface is defined to standardize to return a page of items to clients.
    /// Implements the <see cref="Noob.Application.Dtos.IListResult{T}" />
    /// Implements the <see cref="Noob.Application.Dtos.IHasTotalCount" />
    /// </summary>
    /// <typeparam name="T">Type of the items in the <see cref="IListResult{T}.Items" /> list</typeparam>
    /// <seealso cref="Noob.Application.Dtos.IListResult{T}" />
    /// <seealso cref="Noob.Application.Dtos.IHasTotalCount" />
    public interface IPagedResult<T> : IListResult<T>, IHasTotalCount
    {

    }
}