// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="ISettingEncryptionService.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;

namespace Noob.Settings
{
    /// <summary>
    /// Interface ISettingEncryptionService
    /// </summary>
    public interface ISettingEncryptionService
    {
        /// <summary>
        /// Encrypts the specified setting definition.
        /// </summary>
        /// <param name="settingDefinition">The setting definition.</param>
        /// <param name="plainValue">The plain value.</param>
        /// <returns>System.String.</returns>
        [CanBeNull]
        string Encrypt([NotNull]SettingDefinition settingDefinition, [CanBeNull] string plainValue);

        /// <summary>
        /// Decrypts the specified setting definition.
        /// </summary>
        /// <param name="settingDefinition">The setting definition.</param>
        /// <param name="encryptedValue">The encrypted value.</param>
        /// <returns>System.String.</returns>
        [CanBeNull]
        string Decrypt([NotNull]SettingDefinition settingDefinition, [CanBeNull] string encryptedValue);
    }
}
