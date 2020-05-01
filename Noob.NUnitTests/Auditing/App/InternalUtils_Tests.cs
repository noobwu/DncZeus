// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-01
// ***********************************************************************
// <copyright file="InternalUtils_Tests.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Shouldly;
using NUnit.Framework;

namespace Noob.Auditing
{
    /// <summary>
    /// Class InternalUtils_Tests.
    /// </summary>
    public static class InternalUtils_Tests
    {
        /// <summary>
        /// Defines the test method AddCounter.
        /// </summary>
        [TestCase]
        public static void AddCounter()
        {
            InternalUtils.AddCounter("test").ShouldBe("test__2");
            InternalUtils.AddCounter("test__2").ShouldBe("test__3");
            InternalUtils.AddCounter("test__a").ShouldBe("test__a__2");
        }
    }
}
