// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="IEntityHistorySelectorList.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace Noob.Auditing
{
    /// <summary>
    /// Interface IEntityHistorySelectorList
    /// Implements the <see cref="System.Collections.Generic.IList{NamedTypeSelector}" />
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IList{NamedTypeSelector}" />
    public interface IEntityHistorySelectorList : IList<NamedTypeSelector>
    {
        /// <summary>
        /// Removes a selector by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool RemoveByName(string name);
    }
}
