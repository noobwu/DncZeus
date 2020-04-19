// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="EfCoreDbContextOptions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Noob.EntityFrameworkCore.DependencyInjection;

namespace Noob.EntityFrameworkCore
{
    /// <summary>
    /// Class EfCoreDbContextOptions.
    /// </summary>
    public class EfCoreDbContextOptions
    {
        /// <summary>
        /// Gets or sets the default pre configure actions.
        /// </summary>
        /// <value>The default pre configure actions.</value>
        internal List<Action<EfCoreDbContextConfigurationContext>> DefaultPreConfigureActions { get; set; }

        /// <summary>
        /// Gets or sets the default configure action.
        /// </summary>
        /// <value>The default configure action.</value>
        internal Action<EfCoreDbContextConfigurationContext> DefaultConfigureAction { get; set; }

        /// <summary>
        /// Gets or sets the pre configure actions.
        /// </summary>
        /// <value>The pre configure actions.</value>
        internal Dictionary<Type, List<object>> PreConfigureActions { get; set; }

        /// <summary>
        /// Gets or sets the configure actions.
        /// </summary>
        /// <value>The configure actions.</value>
        internal Dictionary<Type, object> ConfigureActions { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EfCoreDbContextOptions"/> class.
        /// </summary>
        public EfCoreDbContextOptions()
        {
            DefaultPreConfigureActions = new List<Action<EfCoreDbContextConfigurationContext>>();
            PreConfigureActions = new Dictionary<Type, List<object>>();
            ConfigureActions = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Pres the configure.
        /// </summary>
        /// <param name="action">The action.</param>
        public void PreConfigure([NotNull] Action<EfCoreDbContextConfigurationContext> action)
        {
            Check.NotNull(action, nameof(action));

            DefaultPreConfigureActions.Add(action);
        }

        /// <summary>
        /// Configures the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        public void Configure([NotNull] Action<EfCoreDbContextConfigurationContext> action)
        {
            Check.NotNull(action, nameof(action));

            DefaultConfigureAction = action;
        }

        /// <summary>
        /// Pres the configure.
        /// </summary>
        /// <typeparam name="TDbContext">The type of the t database context.</typeparam>
        /// <param name="action">The action.</param>
        public void PreConfigure<TDbContext>([NotNull] Action<DbContextConfigurationContext<TDbContext>> action)
            where TDbContext : EfCoreDbContext<TDbContext>
        {
            Check.NotNull(action, nameof(action));

            var actions = PreConfigureActions.GetOrDefault(typeof(TDbContext));
            if (actions == null)
            {
                PreConfigureActions[typeof(TDbContext)] = actions = new List<object>();
            }

            actions.Add(action);
        }

        /// <summary>
        /// Configures the specified action.
        /// </summary>
        /// <typeparam name="TDbContext">The type of the t database context.</typeparam>
        /// <param name="action">The action.</param>
        public void Configure<TDbContext>([NotNull] Action<DbContextConfigurationContext<TDbContext>> action) 
            where TDbContext : EfCoreDbContext<TDbContext>
        {
            Check.NotNull(action, nameof(action));

            ConfigureActions[typeof(TDbContext)] = action;
        }
    }
}