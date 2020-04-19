// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="PreConfigureActionList.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace Noob.Options
{
    /// <summary>
    /// Class PreConfigureActionList.
    /// Implements the <see cref="System.Collections.Generic.List{System.Action{TOptions}}" />
    /// </summary>
    /// <typeparam name="TOptions">The type of the t options.</typeparam>
    /// <seealso cref="System.Collections.Generic.List{System.Action{TOptions}}" />
    public class PreConfigureActionList<TOptions> : List<Action<TOptions>>
    {
        /// <summary>
        /// Configures the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        public void Configure(TOptions options)
        {
            foreach (var action in this)
            {
                action(options);
            }
        }
    }
}