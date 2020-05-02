// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="ISortedResultRequest.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Application.Dtos
{
    /// <summary>
    /// This interface is defined to standardize to request a sorted result.
    /// </summary>
    public interface ISortedResultRequest
    {
        /// <summary>
        /// Sorting information.
        /// Should include sorting field and optionally a direction (ASC or DESC)
        /// Can contain more than one field separated by comma (,).
        /// </summary>
        /// <value>The sorting.</value>
        /// <example>
        /// Examples:
        /// "Name"
        /// "Name DESC"
        /// "Name ASC, Age DESC"
        /// </example>
        string Sorting { get; set; }
    }
}