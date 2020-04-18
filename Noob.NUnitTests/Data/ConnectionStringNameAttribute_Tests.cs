// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="ConnectionStringNameAttribute_Tests.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Shouldly;
using NUnit.Framework;

namespace Noob.Data
{
    /// <summary>
    /// Class ConnectionStringNameAttribute_Tests.
    /// </summary>
    public class ConnectionStringNameAttribute_Tests
    {
        /// <summary>
        /// Defines the test method Should_Get_Class_FullName_If_Not_ConnStringNameAttribute_Specified.
        /// </summary>
        [TestCase]
        public void Should_Get_Class_FullName_If_Not_ConnStringNameAttribute_Specified()
        {
            ConnectionStringNameAttribute
                .GetConnStringName<MyClassWithoutConnStringName>()
                .ShouldBe(typeof(MyClassWithoutConnStringName).FullName);
        }

        /// <summary>
        /// Defines the test method Should_Get_ConnStringName_If_Not_Specified.
        /// </summary>
        [TestCase]
        public void Should_Get_ConnStringName_If_Not_Specified()
        {
            ConnectionStringNameAttribute
                .GetConnStringName<MyClassWithConnStringName>()
                .ShouldBe("MyDb");
        }
        /// <summary>
        /// Class MyClassWithoutConnStringName.
        /// </summary>
        private class MyClassWithoutConnStringName
        {
            
        }

        /// <summary>
        /// Class MyClassWithConnStringName.
        /// </summary>
        [ConnectionStringName("MyDb")]
        private class MyClassWithConnStringName
        {

        }
    }
}
