// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="ISettingProvider.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Noob.Settings
{
    /// <summary>
    /// Interface ISettingProvider
    /// </summary>
    public interface ISettingProvider
    {
        /// <summary>
        /// Gets the or null asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetOrNullAsync([NotNull]string name);

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns>Task&lt;List&lt;SettingValue&gt;&gt;.</returns>
        Task<List<SettingValue>> GetAllAsync();
    }
}
