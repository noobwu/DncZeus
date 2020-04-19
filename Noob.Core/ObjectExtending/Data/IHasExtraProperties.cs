// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="IHasExtraProperties.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace Noob.Data
{
    /// <summary>
    /// Interface IHasExtraProperties
    /// </summary>
    public interface IHasExtraProperties
    {
        /// <summary>
        /// Gets the extra properties.
        /// </summary>
        /// <value>The extra properties.</value>
        Dictionary<string, object> ExtraProperties { get; }
    }
}
