// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="IListResult.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace Noob.Application.Dtos
{
    /// <summary>
    /// This interface is defined to standardize to return a list of items to clients.
    /// </summary>
    /// <typeparam name="T">Type of the items in the <see cref="Items" /> list</typeparam>
    public interface IListResult<T>
    {
        /// <summary>
        /// List of items.
        /// </summary>
        /// <value>The items.</value>
        IReadOnlyList<T> Items { get; set; }
    }
}