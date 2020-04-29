// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="IAvoidDuplicateCrossCuttingConcerns.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace Noob.Aspects
{
    /// <summary>
    /// Interface IAvoidDuplicateCrossCuttingConcerns
    /// </summary>
    public interface IAvoidDuplicateCrossCuttingConcerns
    {
        /// <summary>
        /// Gets the applied cross cutting concerns.
        /// </summary>
        /// <value>The applied cross cutting concerns.</value>
        List<string> AppliedCrossCuttingConcerns { get; }
    }
}