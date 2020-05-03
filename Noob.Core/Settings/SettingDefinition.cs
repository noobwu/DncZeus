// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="SettingDefinition.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Noob.Settings
{
    /// <summary>
    /// Class SettingDefinition.
    /// </summary>
    public class SettingDefinition
    {
        /// <summary>
        /// Unique name of the setting.
        /// </summary>
        /// <value>The name.</value>
        [NotNull]
        public string Name { get; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        [NotNull]
        public string DisplayName
        {
            get => _displayName;
            set => _displayName = Check.NotNull(value, nameof(value));
        }
        /// <summary>
        /// The display name
        /// </summary>
        private string _displayName;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [CanBeNull]
        public string Description { get; set; }

        /// <summary>
        /// Default value of the setting.
        /// </summary>
        /// <value>The default value.</value>
        [CanBeNull]
        public string DefaultValue { get; set; }

        /// <summary>
        /// Can clients see this setting and it's value.
        /// It maybe dangerous for some settings to be visible to clients (such as an email server password).
        /// Default: false.
        /// </summary>
        /// <value><c>true</c> if this instance is visible to clients; otherwise, <c>false</c>.</value>
        public bool IsVisibleToClients { get; set; }

        /// <summary>
        /// A list of allowed providers to get/set value of this setting.
        /// An empty list indicates that all providers are allowed.
        /// </summary>
        /// <value>The providers.</value>
        public List<string> Providers { get; } //TODO: Rename to AllowedProviders

        /// <summary>
        /// Is this setting inherited from parent scopes.
        /// Default: True.
        /// </summary>
        /// <value><c>true</c> if this instance is inherited; otherwise, <c>false</c>.</value>
        public bool IsInherited { get; set; }

        /// <summary>
        /// Can be used to get/set custom properties for this setting definition.
        /// </summary>
        /// <value>The properties.</value>
        [NotNull]
        public Dictionary<string, object> Properties { get; }

        /// <summary>
        /// Is this setting stored as encrypted in the data source.
        /// Default: False.
        /// </summary>
        /// <value><c>true</c> if this instance is encrypted; otherwise, <c>false</c>.</value>
        public bool IsEncrypted { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingDefinition"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="displayName">The display name.</param>
        /// <param name="description">The description.</param>
        /// <param name="isVisibleToClients">if set to <c>true</c> [is visible to clients].</param>
        /// <param name="isInherited">if set to <c>true</c> [is inherited].</param>
        /// <param name="isEncrypted">if set to <c>true</c> [is encrypted].</param>
        public SettingDefinition(
            string name,
            string defaultValue = null,
            string displayName = null,
            string description = null,
            bool isVisibleToClients = false,
            bool isInherited = true,
            bool isEncrypted = false)
        {
            Name = name;
            DefaultValue = defaultValue;
            IsVisibleToClients = isVisibleToClients;
            DisplayName = displayName;
            Description = description;
            IsInherited = isInherited;
            IsEncrypted = isEncrypted;

            Properties = new Dictionary<string, object>();
            Providers = new List<string>();
        }

        /// <summary>
        /// Sets a property in the <see cref="Properties" /> dictionary.
        /// This is a shortcut for nested calls on this object.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>SettingDefinition.</returns>
        public virtual SettingDefinition WithProperty(string key, object value)
        {
            Properties[key] = value;
            return this;
        }

        /// <summary>
        /// Sets a property in the <see cref="Properties" /> dictionary.
        /// This is a shortcut for nested calls on this object.
        /// </summary>
        /// <param name="providers">The providers.</param>
        /// <returns>SettingDefinition.</returns>
        public virtual SettingDefinition WithProviders(params string[] providers)
        {
            if (!providers.IsNullOrEmpty())
            {
                Providers.AddRange(providers);
            }

            return this;
        }
    }
}