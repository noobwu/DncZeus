// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="IHasConcurrencyStamp.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Domain.Entities
{
    /// <summary>
    /// Interface IHasConcurrencyStamp
    /// </summary>
    public interface IHasConcurrencyStamp
    {
        /// <summary>
        /// Gets or sets the concurrency stamp.
        /// </summary>
        /// <value>The concurrency stamp.</value>
        string ConcurrencyStamp { get; set; }
    }
}