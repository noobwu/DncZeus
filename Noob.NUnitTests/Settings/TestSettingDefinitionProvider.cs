// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="TestSettingDefinitionProvider.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Noob.Settings
{
    /// <summary>
    /// Class TestSettingDefinitionProvider.
    /// Implements the <see cref="SettingDefinitionProvider" />
    /// </summary>
    /// <seealso cref="SettingDefinitionProvider" />
    public class TestSettingDefinitionProvider : SettingDefinitionProvider
    {
        /// <summary>
        /// Defines the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(TestSettingNames.TestSettingWithoutDefaultValue),
                new SettingDefinition(TestSettingNames.TestSettingWithDefaultValue, "default-value"),
                new SettingDefinition(TestSettingNames.TestSettingEncrypted, isEncrypted: true)
            );
        }
    }
}
