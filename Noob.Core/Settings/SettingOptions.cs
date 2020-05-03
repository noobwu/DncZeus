// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="SettingOptions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.Collections;

namespace Noob.Settings
{
    /// <summary>
    /// Class SettingOptions.
    /// </summary>
    public class SettingOptions
    {
        /// <summary>
        /// Gets the definition providers.
        /// </summary>
        /// <value>The definition providers.</value>
        public ITypeList<ISettingDefinitionProvider> DefinitionProviders { get; }

        /// <summary>
        /// Gets the value providers.
        /// </summary>
        /// <value>The value providers.</value>
        public ITypeList<ISettingValueProvider> ValueProviders { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingOptions"/> class.
        /// </summary>
        public SettingOptions()
        {
            DefinitionProviders = new TypeList<ISettingDefinitionProvider>();
            ValueProviders = new TypeList<ISettingValueProvider>();
        }
    }
}
