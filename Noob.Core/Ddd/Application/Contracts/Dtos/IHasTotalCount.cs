// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="IHasTotalCount.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Application.Dtos
{
    /// <summary>
    /// This interface is defined to standardize to set "Total Count of Items" to a DTO.
    /// </summary>
    public interface IHasTotalCount
    {
        /// <summary>
        /// Total count of Items.
        /// </summary>
        /// <value>The total count.</value>
        long TotalCount { get; set; }
    }
}