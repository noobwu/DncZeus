// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="IHasCreationTime.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.Auditing
{
    /// <summary>
    /// A standard interface to add CreationTime property.
    /// </summary>
    public interface IHasCreationTime
    {
        /// <summary>
        /// Creation time.
        /// </summary>
        /// <value>The creation time.</value>
        DateTime CreationTime { get; set; }
    }
}