// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="SettingsTestModule.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.Autofac;
using Noob.Modularity;

namespace Noob.Settings
{
    /// <summary>
    /// Class SettingsTestModule.
    /// Implements the <see cref="Noob.Modularity.Module" />
    /// </summary>
    /// <seealso cref="Noob.Modularity.Module" />
    [DependsOn(
        typeof(AutofacModule),
        typeof(SettingsModule),
        typeof(TestBaseModule)
        )]
    public class SettingsTestModule : Module
    {
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<SettingOptions>(options =>
            {
                options.ValueProviders.Add<TestSettingValueProvider>();
            });
        }
    }
}
