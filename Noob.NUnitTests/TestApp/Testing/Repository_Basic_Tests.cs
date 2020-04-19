// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="Repository_Basic_Tests.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.DependencyInjection;
using Noob.Domain.Repositories;
using Noob.TestApp.Domain;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Noob.Threading;
using Noob.Modularity;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Noob.TestApp.Testing
{
    /// <summary>
    /// Class Repository_Basic_Tests.
    /// Implements the <see cref="Noob.IntegratedTest{TStartupModule}" />
    /// </summary>
    /// <typeparam name="TStartupModule">The type of the t startup module.</typeparam>
    /// <seealso cref="Noob.IntegratedTest{TStartupModule}" />
    public abstract class Repository_Basic_Tests<TStartupModule> : IntegratedTest<TStartupModule>
          where TStartupModule : class
    {
        /// <summary>
        /// The person repository
        /// </summary>
        protected readonly IRepository<Person, Guid> PersonRepository;
        /// <summary>
        /// The city repository
        /// </summary>
        protected readonly ICityRepository CityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository_Basic_Tests{TStartupModule}"/> class.
        /// </summary>
        protected Repository_Basic_Tests()
        {
            PersonRepository = GetRequiredService<IRepository<Person, Guid>>();
            CityRepository = GetRequiredService<ICityRepository>();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public async Task GetAsync()
        {
            var person = await PersonRepository.GetAsync(TestDataBuilder.UserDouglasId);
            person.Name.ShouldBe("Douglas");
            person.Phones.Count.ShouldBe(2);
        }

        /// <summary>
        /// Defines the test method GetAsync_With_Predicate.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public async Task GetAsync_With_Predicate()
        {
            var person = await PersonRepository.GetAsync(p => p.Name == "Douglas");
            person.Name.ShouldBe("Douglas");
            person.Phones.Count.ShouldBe(2);
        }

        /// <summary>
        /// Defines the test method FindAsync_Should_Return_Null_For_Not_Found_Entity.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public async Task FindAsync_Should_Return_Null_For_Not_Found_Entity()
        {
            var person = await PersonRepository.FindAsync(Guid.NewGuid());
            person.ShouldBeNull();
        }

        /// <summary>
        /// Defines the test method FindAsync_Should_Return_Null_For_Not_Found_Entity_With_Predicate.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public async Task FindAsync_Should_Return_Null_For_Not_Found_Entity_With_Predicate()
        {
            var randomName = Guid.NewGuid().ToString();
            var person = await PersonRepository.FindAsync(p => p.Name == randomName);
            person.ShouldBeNull();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public async Task DeleteAsync()
        {
            await PersonRepository.DeleteAsync(TestDataBuilder.UserDouglasId);

            (await PersonRepository.FindAsync(TestDataBuilder.UserDouglasId)).ShouldBeNull();
        }

        /// <summary>
        /// Defines the test method Should_Access_To_Other_Collections_In_Same_Context_In_A_Custom_Method.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public async Task Should_Access_To_Other_Collections_In_Same_Context_In_A_Custom_Method()
        {
            var people = await CityRepository.GetPeopleInTheCityAsync("London");
            people.Count.ShouldBeGreaterThan(0);
        }

        /// <summary>
        /// Defines the test method Custom_Repository_Method.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public async Task Custom_Repository_Method()
        {
            var city = await CityRepository.FindByNameAsync("Istanbul");
            city.ShouldNotBeNull();
            city.Name.ShouldBe("Istanbul");
        }

        /// <summary>
        /// insert as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public virtual async Task InsertAsync()
        {
            var personId = Guid.NewGuid();

            await PersonRepository.InsertAsync(new Person(personId, "Adam", 42));

            var person = await PersonRepository.FindAsync(personId);
            person.ShouldNotBeNull();
        }
        /// <summary>
        /// Called when [application initialization].
        /// </summary>
        /// <param name="context">The context.</param>
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            SeedTestData(context);
        }
        /// <summary>
        /// Seeds the test data.
        /// </summary>
        /// <param name="context">The context.</param>
        private static void SeedTestData(ApplicationInitializationContext context)
        {
            using (var scope = context.ServiceProvider.CreateScope())
            {
                AsyncHelper.RunSync(() => scope.ServiceProvider
                    .GetRequiredService<TestDataBuilder>()
                    .BuildAsync());
            }
        }
    }
}
