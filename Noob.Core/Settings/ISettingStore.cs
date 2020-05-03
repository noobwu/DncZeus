// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="ISettingStore.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Noob.Settings
{
    /// <summary>
    /// Interface ISettingStore
    /// </summary>
    public interface ISettingStore
    {
        /// <summary>
        /// Gets the or null asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="providerName">Name of the provider.</param>
        /// <param name="providerKey">The provider key.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetOrNullAsync(
            [NotNull] string name,
            [CanBeNull] string providerName,
            [CanBeNull] string providerKey
        );
    }
}
