// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-18
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-18
// ***********************************************************************
// <copyright file="ConnectionStringResolver_Tests.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using NUnit.Framework;
using Noob.Modularity;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Noob.Data
{
    /// <summary>
    /// Class ConnectionStringResolver_Tests.
    /// Implements the <see cref="Noob.IntegratedTest{Noob.Data.ConnectionStringResolver_Tests}" />
    /// </summary>
    /// <seealso cref="Noob.IntegratedTest{Noob.Data.ConnectionStringResolver_Tests}" />
    public class ConnectionStringResolver_Tests : IntegratedTest<ConnectionStringResolver_Tests>
    {
        /// <summary>
        /// The default connection string
        /// </summary>
        private const string DefaultConnString = "default-value";
        /// <summary>
        /// The database1 name
        /// </summary>
        private const string Database1Name = "Database1";
        /// <summary>
        /// The database1 connection string
        /// </summary>
        private const string Database1ConnString = "database-1-value";
        /// <summary>
        /// The database2 name
        /// </summary>
        private const string Database2Name = "Database2";

        /// <summary>
        /// The connection string resolver
        /// </summary>
        private readonly IConnectionStringResolver _connectionStringResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionStringResolver_Tests"/> class.
        /// </summary>
        public ConnectionStringResolver_Tests()
        {
            _connectionStringResolver = ServiceProvider.GetRequiredService<IConnectionStringResolver>();
        }

        /// <summary>
        /// Defines the test method Should_Get_Default_ConnString_By_Default.
        /// </summary>
        [TestCase]
        public void Should_Get_Default_ConnString_By_Default()
        {
            _connectionStringResolver.Resolve().ShouldBe(DefaultConnString);
        }

        /// <summary>
        /// Defines the test method Should_Get_Specific_ConnString_IfDefined.
        /// </summary>
        [TestCase]
        public void Should_Get_Specific_ConnString_IfDefined()
        {
            _connectionStringResolver.Resolve(Database1Name).ShouldBe(Database1ConnString);
        }

        /// <summary>
        /// Defines the test method Should_Get_Default_ConnString_If_Not_Specified.
        /// </summary>
        [TestCase]
        public void Should_Get_Default_ConnString_If_Not_Specified()
        {
            _connectionStringResolver.Resolve(Database2Name).ShouldBe(DefaultConnString);
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<DbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = DefaultConnString;
                options.ConnectionStrings[Database1Name] = Database1ConnString;
            });
            context.Services.TryAddTransient(typeof(IConnectionStringResolver), typeof(DefaultConnectionStringResolver));
        }
    }
}
