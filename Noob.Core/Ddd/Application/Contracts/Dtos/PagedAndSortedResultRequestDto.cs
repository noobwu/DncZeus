// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="PagedAndSortedResultRequestDto.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.Application.Dtos
{
    /// <summary>
    /// Simply implements <see cref="IPagedAndSortedResultRequest" />.
    /// Implements the <see cref="Noob.Application.Dtos.PagedResultRequestDto" />
    /// Implements the <see cref="Noob.Application.Dtos.IPagedAndSortedResultRequest" />
    /// </summary>
    /// <seealso cref="Noob.Application.Dtos.PagedResultRequestDto" />
    /// <seealso cref="Noob.Application.Dtos.IPagedAndSortedResultRequest" />
    [Serializable]
    public class PagedAndSortedResultRequestDto : PagedResultRequestDto, IPagedAndSortedResultRequest
    {
        /// <summary>
        /// Gets or sets the sorting.
        /// </summary>
        /// <value>The sorting.</value>
        public virtual string Sorting { get; set; }
    }
}