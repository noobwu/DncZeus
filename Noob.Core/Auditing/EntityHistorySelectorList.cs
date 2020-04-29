// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-30
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-30
// ***********************************************************************
// <copyright file="EntityHistorySelectorList.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace Noob.Auditing
{
    /// <summary>
    /// Class EntityHistorySelectorList.
    /// Implements the <see cref="System.Collections.Generic.List{Noob.NamedTypeSelector}" />
    /// Implements the <see cref="Noob.Auditing.IEntityHistorySelectorList" />
    /// </summary>
    /// <seealso cref="System.Collections.Generic.List{Noob.NamedTypeSelector}" />
    /// <seealso cref="Noob.Auditing.IEntityHistorySelectorList" />
    internal class EntityHistorySelectorList : List<NamedTypeSelector>, IEntityHistorySelectorList
    {
        /// <summary>
        /// Removes a selector by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RemoveByName(string name)
        {
            return RemoveAll(s => s.Name == name) > 0;
        }
    }
}
