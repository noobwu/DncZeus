// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-17
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-17
// ***********************************************************************
// <copyright file="DistributedCache_Tests.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Threading.Tasks;
using Shouldly;
using Noob.Testing;
using NUnit.Framework;

namespace Noob.Caching
{
    /// <summary>
    /// Class DistributedCache_Tests.
    /// Implements the <see cref="Noob.Testing.IntegratedTest{Noob.Caching.CachingTestModule}" />
    /// </summary>
    /// <seealso cref="Noob.Testing.IntegratedTest{Noob.Caching.CachingTestModule}" />
    public class DistributedCache_Tests : IntegratedTest<CachingTestModule>
    {
        /// <summary>
        /// Defines the test method Should_Set_Get_And_Remove_Cache_Items.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public async Task Should_Set_Get_And_Remove_Cache_Items()
        {
            var personCache = GetRequiredService<IDistributedCache<PersonCacheItem>>();

            var cacheKey = Guid.NewGuid().ToString();
            const string personName = "john nash";

            //Get (not exists yet)
            var cacheItem = await personCache.GetAsync(cacheKey);
            cacheItem.ShouldBeNull();

            //Set
            cacheItem = new PersonCacheItem(personName);
            await personCache.SetAsync(cacheKey, cacheItem);

            //Get (it should be available now
            cacheItem = await personCache.GetAsync(cacheKey);
            cacheItem.ShouldNotBeNull();
            cacheItem.Name.ShouldBe(personName);

            //Remove 
            await personCache.RemoveAsync(cacheKey);

            //Get (not exists since removed)
            cacheItem = await personCache.GetAsync(cacheKey);
            cacheItem.ShouldBeNull();
        }

        /// <summary>
        /// Defines the test method GetOrAdd.
        /// </summary>
        [TestCase]
        public void GetOrAdd()
        {
            var personCache = GetRequiredService<IDistributedCache<PersonCacheItem>>();

            var cacheKey = Guid.NewGuid().ToString();
            const string personName = "john nash";

            //Will execute the factory method to create the cache item

            bool factoryExecuted = false;

            var cacheItem = personCache.GetOrAdd(cacheKey,
                () =>
                {
                    factoryExecuted = true;
                    return new PersonCacheItem(personName);
                });

            factoryExecuted.ShouldBeTrue();
            cacheItem.Name.ShouldBe(personName);

            //This time, it will not execute the factory

            factoryExecuted = false;

            cacheItem = personCache.GetOrAdd(cacheKey,
                () =>
                {
                    factoryExecuted = true;
                    return new PersonCacheItem(personName);
                });

            factoryExecuted.ShouldBeFalse();
            cacheItem.Name.ShouldBe(personName);
        }

        /// <summary>
        /// Defines the test method SameClassName_But_DiffNamespace_Should_Not_Use_Same_Cache.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public async Task SameClassName_But_DiffNamespace_Should_Not_Use_Same_Cache()
        {
            var personCache = GetRequiredService<IDistributedCache<PersonCacheItem>>();
            var otherPersonCache = GetRequiredService<IDistributedCache<Sail.Testing.Caching.PersonCacheItem>>();


            var cacheKey = Guid.NewGuid().ToString();
            const string personName = "john nash";

            //Get (not exists yet)
            var cacheItem = await personCache.GetAsync(cacheKey);
            cacheItem.ShouldBeNull();

            var cacheItem1 = await otherPersonCache.GetAsync(cacheKey);
            cacheItem1.ShouldBeNull();

            //Set
            cacheItem = new PersonCacheItem(personName);
            await personCache.SetAsync(cacheKey, cacheItem);

            //Get (it should be available now, but otherPersonCache not exists now.
            cacheItem = await personCache.GetAsync(cacheKey);
            cacheItem.ShouldNotBeNull();
            cacheItem.Name.ShouldBe(personName);

            cacheItem1 = await otherPersonCache.GetAsync(cacheKey);
            cacheItem1.ShouldBeNull();

            //set other person cache
            cacheItem1 = new Sail.Testing.Caching.PersonCacheItem(personName);
            await otherPersonCache.SetAsync(cacheKey, cacheItem1);

            cacheItem1 = await otherPersonCache.GetAsync(cacheKey);
            cacheItem1.ShouldNotBeNull();
            cacheItem1.Name.ShouldBe(personName);

            //Remove 
            await personCache.RemoveAsync(cacheKey);


            //Get (not exists since removed)
            cacheItem = await personCache.GetAsync(cacheKey);
            cacheItem.ShouldBeNull();

            cacheItem1 = await otherPersonCache.GetAsync(cacheKey);
            cacheItem1.ShouldNotBeNull();

        }

        /// <summary>
        /// Defines the test method Should_Set_Get_And_Remove_Cache_Items_With_Integer_Type_CacheKey.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public async Task Should_Set_Get_And_Remove_Cache_Items_With_Integer_Type_CacheKey()
        {
            var personCache = GetRequiredService<IDistributedCache<PersonCacheItem, int>>();

            var cacheKey = 42;
            const string personName = "john nash";

            //Get (not exists yet)
            var cacheItem = await personCache.GetAsync(cacheKey);
            cacheItem.ShouldBeNull();

            //Set
            cacheItem = new PersonCacheItem(personName);
            await personCache.SetAsync(cacheKey, cacheItem);

            //Get (it should be available now
            cacheItem = await personCache.GetAsync(cacheKey);
            cacheItem.ShouldNotBeNull();
            cacheItem.Name.ShouldBe(personName);

            //Remove 
            await personCache.RemoveAsync(cacheKey);

            //Get (not exists since removed)
            cacheItem = await personCache.GetAsync(cacheKey);
            cacheItem.ShouldBeNull();
        }

        /// <summary>
        /// Defines the test method GetOrAddAsync_With_Integer_Type_CacheKey.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public async Task GetOrAddAsync_With_Integer_Type_CacheKey()
        {
            var personCache = GetRequiredService<IDistributedCache<PersonCacheItem, int>>();

            var cacheKey = 42;
            const string personName = "john nash";

            //Will execute the factory method to create the cache item

            bool factoryExecuted = false;

            var cacheItem = personCache.GetOrAdd(cacheKey,
                () =>
                {
                    factoryExecuted = true;
                    return new PersonCacheItem(personName);
                });

            factoryExecuted.ShouldBeTrue();
            cacheItem.Name.ShouldBe(personName);

            //This time, it will not execute the factory

            factoryExecuted = false;

            cacheItem = await personCache.GetOrAddAsync(cacheKey,
                async () =>
                {
                    factoryExecuted = true;
                    return new PersonCacheItem(personName);
                });

            factoryExecuted.ShouldBeFalse();
            cacheItem.Name.ShouldBe(personName);
        }

        /// <summary>
        /// Defines the test method SameClassName_But_DiffNamespace_Should_Not_Use_Same_Cache_With_Integer_CacheKey.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public async Task SameClassName_But_DiffNamespace_Should_Not_Use_Same_Cache_With_Integer_CacheKey()
        {
            var personCache = GetRequiredService<IDistributedCache<PersonCacheItem, int>>();
            var otherPersonCache = GetRequiredService<IDistributedCache<Sail.Testing.Caching.PersonCacheItem, int>>();


            var cacheKey = 42;
            const string personName = "john nash";

            //Get (not exists yet)
            var cacheItem = await personCache.GetAsync(cacheKey);
            cacheItem.ShouldBeNull();

            var cacheItem1 = await otherPersonCache.GetAsync(cacheKey);
            cacheItem1.ShouldBeNull();

            //Set
            cacheItem = new PersonCacheItem(personName);
            await personCache.SetAsync(cacheKey, cacheItem);

            //Get (it should be available now, but otherPersonCache not exists now.
            cacheItem = await personCache.GetAsync(cacheKey);
            cacheItem.ShouldNotBeNull();
            cacheItem.Name.ShouldBe(personName);

            cacheItem1 = await otherPersonCache.GetAsync(cacheKey);
            cacheItem1.ShouldBeNull();

            //set other person cache
            cacheItem1 = new Sail.Testing.Caching.PersonCacheItem(personName);
            await otherPersonCache.SetAsync(cacheKey, cacheItem1);

            cacheItem1 = await otherPersonCache.GetAsync(cacheKey);
            cacheItem1.ShouldNotBeNull();
            cacheItem1.Name.ShouldBe(personName);

            //Remove 
            await personCache.RemoveAsync(cacheKey);


            //Get (not exists since removed)
            cacheItem = await personCache.GetAsync(cacheKey);
            cacheItem.ShouldBeNull();

            cacheItem1 = await otherPersonCache.GetAsync(cacheKey);
            cacheItem1.ShouldNotBeNull();

        }

        /// <summary>
        /// Defines the test method Should_Set_Get_And_Remove_Cache_Items_With_Object_Type_CacheKey.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public async Task Should_Set_Get_And_Remove_Cache_Items_With_Object_Type_CacheKey()
        {
            var personCache = GetRequiredService<IDistributedCache<PersonCacheItem, ComplexObjectAsCacheKey>>();

            var cacheKey = new ComplexObjectAsCacheKey { Name = "DummyData", Age = 42 };
            const string personName = "john nash";

            //Get (not exists yet)
            var cacheItem = await personCache.GetAsync(cacheKey);
            cacheItem.ShouldBeNull();

            //Set
            cacheItem = new PersonCacheItem(personName);
            await personCache.SetAsync(cacheKey, cacheItem);

            //Get (it should be available now
            cacheItem = await personCache.GetAsync(cacheKey);
            cacheItem.ShouldNotBeNull();
            cacheItem.Name.ShouldBe(personName);

            //Remove 
            await personCache.RemoveAsync(cacheKey);

            //Get (not exists since removed)
            cacheItem = await personCache.GetAsync(cacheKey);
            cacheItem.ShouldBeNull();
        }

        /// <summary>
        /// Defines the test method Should_Set_Get_And_Remove_Cache_Items_For_Same_Object_Type_With_Different_CacheKeys.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public async Task Should_Set_Get_And_Remove_Cache_Items_For_Same_Object_Type_With_Different_CacheKeys()
        {
            var personCache = GetRequiredService<IDistributedCache<PersonCacheItem, ComplexObjectAsCacheKey>>();

            var cache1Key = new ComplexObjectAsCacheKey { Name = "John", Age = 42 };
            var cache2Key = new ComplexObjectAsCacheKey { Name = "Jenny", Age = 24 };
            const string personName = "john nash";

            //Get (not exists yet)
            var cacheItem1 = await personCache.GetAsync(cache1Key);
            var cacheItem2 = await personCache.GetAsync(cache2Key);
            cacheItem1.ShouldBeNull();
            cacheItem2.ShouldBeNull();

            //Set
            cacheItem1 = new PersonCacheItem(personName);
            cacheItem2 = new PersonCacheItem(personName);
            await personCache.SetAsync(cache1Key, cacheItem1);
            await personCache.SetAsync(cache2Key, cacheItem2);

            //Get (it should be available now
            cacheItem1 = await personCache.GetAsync(cache1Key);
            cacheItem1.ShouldNotBeNull();
            cacheItem1.Name.ShouldBe(personName);

            cacheItem2 = await personCache.GetAsync(cache2Key);
            cacheItem2.ShouldNotBeNull();
            cacheItem2.Name.ShouldBe(personName);

            //Remove 
            await personCache.RemoveAsync(cache1Key);
            await personCache.RemoveAsync(cache2Key);

            //Get (not exists since removed)
            cacheItem1 = await personCache.GetAsync(cache1Key);
            cacheItem1.ShouldBeNull();
            cacheItem2 = await personCache.GetAsync(cache2Key);
            cacheItem2.ShouldBeNull();
        }

    }
}