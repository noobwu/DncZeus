// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-02
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-02
// ***********************************************************************
// <copyright file="LimitedResultRequestDto.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Noob.Application.Dtos
{
    /// <summary>
    /// Simply implements <see cref="ILimitedResultRequest" />.
    /// Implements the <see cref="Noob.Application.Dtos.ILimitedResultRequest" />
    /// Implements the <see cref="System.ComponentModel.DataAnnotations.IValidatableObject" />
    /// </summary>
    /// <seealso cref="Noob.Application.Dtos.ILimitedResultRequest" />
    /// <seealso cref="System.ComponentModel.DataAnnotations.IValidatableObject" />
    [Serializable]
    public class LimitedResultRequestDto : ILimitedResultRequest, IValidatableObject
    {
        /// <summary>
        /// Default value: 10.
        /// </summary>
        /// <value>The default maximum result count.</value>
        public static int DefaultMaxResultCount { get; set; } = 10;

        /// <summary>
        /// Maximum possible value of the <see cref="MaxResultCount" />.
        /// Default value: 1,000.
        /// </summary>
        /// <value>The maximum maximum result count.</value>
        public static int MaxMaxResultCount { get; set; } = 1000;

        /// <summary>
        /// Maximum result count should be returned.
        /// This is generally used to limit result count on paging.
        /// </summary>
        /// <value>The maximum result count.</value>
        [Range(1, int.MaxValue)]
        public virtual int MaxResultCount { get; set; } = DefaultMaxResultCount;

        /// <summary>
        /// Determines whether the specified object is valid.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>A collection that holds failed-validation information.</returns>
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MaxResultCount > MaxMaxResultCount)
            {
                yield return new ValidationResult($"已超过最大记录数{MaxMaxResultCount}");
            }
        }
    }
}