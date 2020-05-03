// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="SettingProvider_Tests.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;
using Shouldly;
using Noob.Testing;
using NUnit.Framework;

namespace Noob.Settings
{
    /// <summary>
    /// Class SettingProvider_Tests.
    /// Implements the <see cref="Noob.Testing.IntegratedTest{Noob.Settings.SettingsTestModule}" />
    /// </summary>
    /// <seealso cref="Noob.Testing.IntegratedTest{Noob.Settings.SettingsTestModule}" />
    public class SettingProvider_Tests : IntegratedTest<SettingsTestModule>
    {
        /// <summary>
        /// The setting provider
        /// </summary>
        private readonly ISettingProvider _settingProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingProvider_Tests"/> class.
        /// </summary>
        public SettingProvider_Tests()
        {
            _settingProvider = GetRequiredService<ISettingProvider>();
        }

        /// <summary>
        /// Sets the application creation options.
        /// </summary>
        /// <param name="options">The options.</param>
        protected override void SetApplicationCreationOptions(ApplicationCreationOptions options)
        {
            options.UseAutofac();
        }

        /// <summary>
        /// Defines the test method Should_Get_Null_If_No_Value_Provided_And_No_Default_Value.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public async Task Should_Get_Null_If_No_Value_Provided_And_No_Default_Value()
        {
            (await _settingProvider.GetOrNullAsync(TestSettingNames.TestSettingWithoutDefaultValue))
                .ShouldBeNull();
        }

        /// <summary>
        /// Defines the test method Should_Get_Default_Value_If_No_Value_Provided_And_There_Is_A_Default_Value.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public async Task Should_Get_Default_Value_If_No_Value_Provided_And_There_Is_A_Default_Value()
        {
            (await _settingProvider.GetOrNullAsync(TestSettingNames.TestSettingWithDefaultValue))
                .ShouldBe("default-value");
        }
    }
}
