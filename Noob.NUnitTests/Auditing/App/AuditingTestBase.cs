// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-01
// ***********************************************************************
// <copyright file="AuditingTestBase.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.Testing;

namespace Noob.Auditing
{
    /// <summary>
    /// Class AuditingTestBase.
    /// Implements the <see cref="Noob.Testing.IntegratedTest{Noob.Auditing.AuditingTestModule}" />
    /// </summary>
    /// <seealso cref="Noob.Testing.IntegratedTest{Noob.Auditing.AuditingTestModule}" />
    public class AuditingTestBase : IntegratedTest<AuditingTestModule>
    {
        /// <summary>
        /// Sets the application creation options.
        /// </summary>
        /// <param name="options">The options.</param>
        protected override void SetApplicationCreationOptions(ApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
