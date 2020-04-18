// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="ConnectionStrings.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace Noob.Data
{
    /// <summary>
    /// Class ConnectionStrings.
    /// Implements the <see cref="System.Collections.Generic.Dictionary{System.String, System.String}" />
    /// </summary>
    /// <seealso cref="System.Collections.Generic.Dictionary{System.String, System.String}" />
    [Serializable]
    public class ConnectionStrings : Dictionary<string, string>
    {
        /// <summary>
        /// The default connection string name
        /// </summary>
        public const string DefaultConnectionStringName = "Default";

        /// <summary>
        /// Gets or sets the default.
        /// </summary>
        /// <value>The default.</value>
        public string Default
        {
            get => this.GetOrDefault(DefaultConnectionStringName);
            set => this[DefaultConnectionStringName] = value;
        }
    }
}