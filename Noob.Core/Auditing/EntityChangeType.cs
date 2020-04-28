// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="EntityChangeType.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Auditing
{
    /// <summary>
    /// Enum EntityChangeType
    /// </summary>
    public enum EntityChangeType : byte
    {
        /// <summary>
        /// The created
        /// </summary>
        Created = 0,

        /// <summary>
        /// The updated
        /// </summary>
        Updated = 1,

        /// <summary>
        /// The deleted
        /// </summary>
        Deleted = 2
    }
}
