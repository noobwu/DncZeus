// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="SettingValue.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Noob.Settings
{
    /// <summary>
    /// Class SettingValue.
    /// Implements the <see cref="Noob.NameValue" />
    /// </summary>
    /// <seealso cref="Noob.NameValue" />
    [Serializable]
    public class SettingValue : NameValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingValue"/> class.
        /// </summary>
        public SettingValue()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingValue"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public SettingValue(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}