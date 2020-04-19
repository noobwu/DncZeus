// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="TestEntityExtensionConfigurator.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.ObjectExtending;
using Noob.TestApp.Domain;
using Noob.Threading;

namespace Noob.EntityFrameworkCore.Domain
{
    /// <summary>
    /// Class TestEntityExtensionConfigurator.
    /// </summary>
    public static class TestEntityExtensionConfigurator
    {
        // private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        /// <summary>
        /// Configures this instance.
        /// </summary>
        public static void Configure()
        {
            //OneTimeRunner.Run(() =>
            //{
            //    ObjectExtensionManager.Instance
            //        .MapEfCoreProperty<City, string>(
            //            "PhoneCode",
            //            p => p.HasMaxLength(8)
            //        );
            //});
        }
    }
}
