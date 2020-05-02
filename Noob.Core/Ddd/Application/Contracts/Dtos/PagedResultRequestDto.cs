// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="PagedResultRequestDto.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;

namespace Noob.Application.Dtos
{
    /// <summary>
    /// Simply implements <see cref="IPagedResultRequest" />.
    /// Implements the <see cref="Noob.Application.Dtos.LimitedResultRequestDto" />
    /// Implements the <see cref="Noob.Application.Dtos.IPagedResultRequest" />
    /// </summary>
    /// <seealso cref="Noob.Application.Dtos.LimitedResultRequestDto" />
    /// <seealso cref="Noob.Application.Dtos.IPagedResultRequest" />
    [Serializable]
    public class PagedResultRequestDto : LimitedResultRequestDto, IPagedResultRequest
    {
        /// <summary>
        /// Skip count (beginning of the page).
        /// </summary>
        /// <value>The skip count.</value>
        [Range(0, int.MaxValue)]
        public virtual int SkipCount { get; set; }
    }
}