// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="TestDataBuilder.cs" company="Noob.NUnitTests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Threading.Tasks;
using Noob.DependencyInjection;
using Noob.Domain.Repositories;
using Noob.Modularity;
using Noob.TestApp.Domain;

namespace Noob.TestApp
{
    /// <summary>
    /// Class TestDataBuilder.
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class TestDataBuilder : ITransientDependency
    {
        /// <summary>
        /// Gets the user douglas identifier.
        /// </summary>
        /// <value>The user douglas identifier.</value>
        public static Guid UserDouglasId { get; } = new Guid("1fcf46b2-28c3-48d0-8bac-fa53268a2775");
        /// <summary>
        /// Gets the user john deleted identifier.
        /// </summary>
        /// <value>The user john deleted identifier.</value>
        public static Guid UserJohnDeletedId { get; } = new Guid("1e28ca9f-df84-4f39-83fe-f5450ecbf5d4");

        /// <summary>
        /// Gets the istanbul city identifier.
        /// </summary>
        /// <value>The istanbul city identifier.</value>
        public static Guid IstanbulCityId { get; } = new Guid("4d734a0e-3e6b-4bad-bb43-ef8cf1b09633");
        /// <summary>
        /// Gets the london city identifier.
        /// </summary>
        /// <value>The london city identifier.</value>
        public static Guid LondonCityId { get; } = new Guid("27237527-605e-4652-a2a5-68e0e512da36");

        /// <summary>
        /// The person repository
        /// </summary>
        private readonly IPersonRepository _personRepository;
        /// <summary>
        /// The city repository
        /// </summary>
        private readonly ICityRepository _cityRepository;
        /// <summary>
        /// The entity with int PKS repository
        /// </summary>
        private readonly IEntityWithIntPkRepository _entityWithIntPksRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestDataBuilder" /> class.
        /// </summary>
        /// <param name="personRepository">The person repository.</param>
        /// <param name="cityRepository">The city repository.</param>
        /// <param name="entityWithIntPksRepository">The entity with int PKS repository.</param>
        public TestDataBuilder(
            IPersonRepository personRepository,
            ICityRepository cityRepository,
            IEntityWithIntPkRepository entityWithIntPksRepository)
        {
            _personRepository = personRepository;
            _cityRepository = cityRepository;
            _entityWithIntPksRepository = entityWithIntPksRepository;
        }

        /// <summary>
        /// build as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task BuildAsync()
        {
            await AddCities();
            await AddPeople();
            await AddEntitiesWithPks();
        }

        /// <summary>
        /// Adds the cities.
        /// </summary>
        /// <returns>Task.</returns>
        private async Task AddCities()
        {
            var istanbul = new City(IstanbulCityId, "Istanbul");
            istanbul.Districts.Add(new District(istanbul.Id, "Bakirkoy", 1283999));
            istanbul.Districts.Add(new District(istanbul.Id, "Mecidiyekoy", 2222321));
            istanbul.Districts.Add(new District(istanbul.Id, "Uskudar", 726172));

            await _cityRepository.InsertAsync(new City(Guid.NewGuid(), "Tokyo"));
            await _cityRepository.InsertAsync(new City(Guid.NewGuid(), "Madrid"));
            await _cityRepository.InsertAsync(new City(LondonCityId, "London"));
            await _cityRepository.InsertAsync(istanbul);
            await _cityRepository.InsertAsync(new City(Guid.NewGuid(), "Paris"));
            await _cityRepository.InsertAsync(new City(Guid.NewGuid(), "Washington"));
            await _cityRepository.InsertAsync(new City(Guid.NewGuid(), "Sao Paulo"));
            await _cityRepository.InsertAsync(new City(Guid.NewGuid(), "Berlin"));
            await _cityRepository.InsertAsync(new City(Guid.NewGuid(), "Amsterdam"));
            await _cityRepository.InsertAsync(new City(Guid.NewGuid(), "Beijing"));
            await _cityRepository.InsertAsync(new City(Guid.NewGuid(), "Rome"));
        }

        /// <summary>
        /// Adds the people.
        /// </summary>
        /// <returns>Task.</returns>
        private async Task AddPeople()
        {
            var douglas = new Person(UserDouglasId, "Douglas", 42, cityId: LondonCityId);
            douglas.Phones.Add(new Phone(douglas.Id, "123456789"));
            douglas.Phones.Add(new Phone(douglas.Id, "123456780", PhoneType.Home));

            await _personRepository.InsertAsync(douglas);

            await _personRepository.InsertAsync(new Person(UserJohnDeletedId, "John-Deleted", 33));

            var person1 = new Person(Guid.NewGuid(), "Person1", 42);
            var person2 = new Person(Guid.NewGuid(),"Person2", 43);

            await _personRepository.InsertAsync(person1);
            await _personRepository.InsertAsync(person2);
        }
       
        /// <summary>
        /// Adds the entities with PKS.
        /// </summary>
        /// <returns>Task.</returns>
        private async Task AddEntitiesWithPks()
        {
            await _entityWithIntPksRepository.InsertAsync(new EntityWithIntPk("Entity1"));
        }
    }
}