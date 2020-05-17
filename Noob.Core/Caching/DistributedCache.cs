// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-17
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-17
// ***********************************************************************
// <copyright file="DistributedCache.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Nito.AsyncEx;
using Noob.DependencyInjection;
using Noob.ExceptionHandling;
using Noob.Threading;

namespace Noob.Caching
{
    /// <summary>
    /// Represents a distributed cache of <typeparamref name="TCacheItem" /> type.
    /// Implements the <see cref="Noob.Caching.DistributedCache{TCacheItem, System.String}" />
    /// Implements the <see cref="Noob.Caching.IDistributedCache{TCacheItem}" />
    /// </summary>
    /// <typeparam name="TCacheItem">The type of cache item being cached.</typeparam>
    /// <seealso cref="Noob.Caching.DistributedCache{TCacheItem, System.String}" />
    /// <seealso cref="Noob.Caching.IDistributedCache{TCacheItem}" />
    public class DistributedCache<TCacheItem> : DistributedCache<TCacheItem, string>, IDistributedCache<TCacheItem>
        where TCacheItem : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DistributedCache{TCacheItem}"/> class.
        /// </summary>
        /// <param name="distributedCacheOption">The distributed cache option.</param>
        /// <param name="cache">The cache.</param>
        /// <param name="cancellationTokenProvider">The cancellation token provider.</param>
        /// <param name="serializer">The serializer.</param>
        /// <param name="keyNormalizer">The key normalizer.</param>
        /// <param name="serviceScopeFactory">The service scope factory.</param>
        public DistributedCache(
            IOptions<DistributedCacheOptions> distributedCacheOption,
            IDistributedCache cache,
            ICancellationTokenProvider cancellationTokenProvider,
            IDistributedCacheSerializer serializer,
            IDistributedCacheKeyNormalizer keyNormalizer,
            IHybridServiceScopeFactory serviceScopeFactory) : base(
                distributedCacheOption: distributedCacheOption,
                cache: cache,
                cancellationTokenProvider: cancellationTokenProvider,
                serializer: serializer,
                keyNormalizer: keyNormalizer,
                serviceScopeFactory: serviceScopeFactory)
        {
        }

    }
    /// <summary>
    /// Represents a distributed cache of <typeparamref name="TCacheItem" /> type.
    /// Uses a generic cache key type of <typeparamref name="TCacheKey" /> type.
    /// Implements the <see cref="Noob.Caching.IDistributedCache{TCacheItem, TCacheKey}" />
    /// </summary>
    /// <typeparam name="TCacheItem">The type of cache item being cached.</typeparam>
    /// <typeparam name="TCacheKey">The type of cache key being used.</typeparam>
    /// <seealso cref="Noob.Caching.IDistributedCache{TCacheItem, TCacheKey}" />
    public class DistributedCache<TCacheItem, TCacheKey> : IDistributedCache<TCacheItem, TCacheKey>
        where TCacheItem : class
    {
        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        /// <value>The logger.</value>
        public ILogger<DistributedCache<TCacheItem, TCacheKey>> Logger { get; set; }

        /// <summary>
        /// Gets or sets the name of the cache.
        /// </summary>
        /// <value>The name of the cache.</value>
        protected string CacheName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [ignore multi tenancy].
        /// </summary>
        /// <value><c>true</c> if [ignore multi tenancy]; otherwise, <c>false</c>.</value>
        protected bool IgnoreMultiTenancy { get; set; }

        /// <summary>
        /// Gets the cache.
        /// </summary>
        /// <value>The cache.</value>
        protected IDistributedCache Cache { get; }

        /// <summary>
        /// Gets the cancellation token provider.
        /// </summary>
        /// <value>The cancellation token provider.</value>
        protected ICancellationTokenProvider CancellationTokenProvider { get; }

        /// <summary>
        /// Gets the serializer.
        /// </summary>
        /// <value>The serializer.</value>
        protected IDistributedCacheSerializer Serializer { get; }

        /// <summary>
        /// Gets the key normalizer.
        /// </summary>
        /// <value>The key normalizer.</value>
        protected IDistributedCacheKeyNormalizer KeyNormalizer { get; }

        /// <summary>
        /// Gets the service scope factory.
        /// </summary>
        /// <value>The service scope factory.</value>
        protected IHybridServiceScopeFactory ServiceScopeFactory { get; }

        /// <summary>
        /// Gets the synchronize semaphore.
        /// </summary>
        /// <value>The synchronize semaphore.</value>
        protected SemaphoreSlim SyncSemaphore { get; }

        /// <summary>
        /// The default cache options
        /// </summary>
        protected DistributedCacheEntryOptions DefaultCacheOptions;

        /// <summary>
        /// The distributed cache option
        /// </summary>
        private readonly DistributedCacheOptions _distributedCacheOption;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistributedCache{TCacheItem, TCacheKey}"/> class.
        /// </summary>
        /// <param name="distributedCacheOption">The distributed cache option.</param>
        /// <param name="cache">The cache.</param>
        /// <param name="cancellationTokenProvider">The cancellation token provider.</param>
        /// <param name="serializer">The serializer.</param>
        /// <param name="keyNormalizer">The key normalizer.</param>
        /// <param name="serviceScopeFactory">The service scope factory.</param>
        public DistributedCache(
            IOptions<DistributedCacheOptions> distributedCacheOption,
            IDistributedCache cache,
            ICancellationTokenProvider cancellationTokenProvider,
            IDistributedCacheSerializer serializer,
            IDistributedCacheKeyNormalizer keyNormalizer,
            IHybridServiceScopeFactory serviceScopeFactory)
        {
            _distributedCacheOption = distributedCacheOption.Value;
            Cache = cache;
            CancellationTokenProvider = cancellationTokenProvider;
            Logger = NullLogger<DistributedCache<TCacheItem, TCacheKey>>.Instance;
            Serializer = serializer;
            KeyNormalizer = keyNormalizer;
            ServiceScopeFactory = serviceScopeFactory;

            SyncSemaphore = new SemaphoreSlim(1, 1);

            SetDefaultOptions();
        }

        /// <summary>
        /// Normalizes the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        protected virtual string NormalizeKey(TCacheKey key)
        {
            return KeyNormalizer.NormalizeKey(
                new DistributedCacheKeyNormalizeArgs(
                    key.ToString(),
                    CacheName
                )
            );
        }

        /// <summary>
        /// Gets the default cache entry options.
        /// </summary>
        /// <returns>DistributedCacheEntryOptions.</returns>
        protected virtual DistributedCacheEntryOptions GetDefaultCacheEntryOptions()
        {
            foreach (var configure in _distributedCacheOption.CacheConfigurators)
            {
                var options = configure.Invoke(CacheName);
                if (options != null)
                {
                    return options;
                }
            }

            return _distributedCacheOption.GlobalCacheEntryOptions;
        }

        /// <summary>
        /// Sets the default options.
        /// </summary>
        protected virtual void SetDefaultOptions()
        {
            CacheName = CacheNameAttribute.GetCacheName(typeof(TCacheItem));

            //Configure default cache entry options
            DefaultCacheOptions = GetDefaultCacheEntryOptions();
        }

        /// <summary>
        /// Gets a cache item with the given key. If no cache item is found for the given key then returns null.
        /// </summary>
        /// <param name="key">The key of cached item to be retrieved from the cache.</param>
        /// <param name="hideErrors">Indicates to throw or hide the exceptions for the distributed cache.</param>
        /// <returns>The cache item, or null.</returns>
        public virtual TCacheItem Get(
            TCacheKey key,
            bool? hideErrors = null)
        {
            hideErrors = hideErrors ?? _distributedCacheOption.HideErrors;

            byte[] cachedBytes;

            try
            {
                cachedBytes = Cache.Get(NormalizeKey(key));
            }
            catch (Exception ex)
            {
                if (hideErrors == true)
                {
                    AsyncHelper.RunSync(() => HandleExceptionAsync(ex));
                    return null;
                }

                throw;
            }

            if (cachedBytes == null)
            {
                return null;
            }

            return Serializer.Deserialize<TCacheItem>(cachedBytes);
        }

        /// <summary>
        /// Gets a cache item with the given key. If no cache item is found for the given key then returns null.
        /// </summary>
        /// <param name="key">The key of cached item to be retrieved from the cache.</param>
        /// <param name="hideErrors">Indicates to throw or hide the exceptions for the distributed cache.</param>
        /// <param name="token">The <see cref="T:System.Threading.CancellationToken" /> for the task.</param>
        /// <returns>The cache item, or null.</returns>
        public virtual async Task<TCacheItem> GetAsync(
            TCacheKey key,
            bool? hideErrors = null,
            CancellationToken token = default)
        {
            hideErrors = hideErrors ?? _distributedCacheOption.HideErrors;

            byte[] cachedBytes;

            try
            {
                cachedBytes = await Cache.GetAsync(
                    NormalizeKey(key),
                    CancellationTokenProvider.FallbackToProvider(token)
                );
            }
            catch (Exception ex)
            {
                if (hideErrors == true)
                {
                    await HandleExceptionAsync(ex);
                    return null;
                }

                throw;
            }

            if (cachedBytes == null)
            {
                return null;
            }

            return Serializer.Deserialize<TCacheItem>(cachedBytes);
        }

        /// <summary>
        /// Gets or Adds a cache item with the given key. If no cache item is found for the given key then adds a cache item
        /// provided by <paramref name="factory" /> delegate and returns the provided cache item.
        /// </summary>
        /// <param name="key">The key of cached item to be retrieved from the cache.</param>
        /// <param name="factory">The factory delegate is used to provide the cache item when no cache item is found for the given <paramref name="key" />.</param>
        /// <param name="optionsFactory">The cache options for the factory delegate.</param>
        /// <param name="hideErrors">Indicates to throw or hide the exceptions for the distributed cache.</param>
        /// <returns>The cache item.</returns>
        public virtual TCacheItem GetOrAdd(
            TCacheKey key,
            Func<TCacheItem> factory,
            Func<DistributedCacheEntryOptions> optionsFactory = null,
            bool? hideErrors = null)
        {
            var value = Get(key, hideErrors);
            if (value != null)
            {
                return value;
            }

            using (SyncSemaphore.Lock())
            {
                value = Get(key, hideErrors);
                if (value != null)
                {
                    return value;
                }

                value = factory();
                Set(key, value, optionsFactory?.Invoke(), hideErrors);
            }

            return value;
        }

        /// <summary>
        /// Gets or Adds a cache item with the given key. If no cache item is found for the given key then adds a cache item
        /// provided by <paramref name="factory" /> delegate and returns the provided cache item.
        /// </summary>
        /// <param name="key">The key of cached item to be retrieved from the cache.</param>
        /// <param name="factory">The factory delegate is used to provide the cache item when no cache item is found for the given <paramref name="key" />.</param>
        /// <param name="optionsFactory">The cache options for the factory delegate.</param>
        /// <param name="hideErrors">Indicates to throw or hide the exceptions for the distributed cache.</param>
        /// <param name="token">The <see cref="T:System.Threading.CancellationToken" /> for the task.</param>
        /// <returns>The cache item.</returns>
        public virtual async Task<TCacheItem> GetOrAddAsync(
            TCacheKey key,
            Func<Task<TCacheItem>> factory,
            Func<DistributedCacheEntryOptions> optionsFactory = null,
            bool? hideErrors = null,
            CancellationToken token = default)
        {
            token = CancellationTokenProvider.FallbackToProvider(token);
            var value = await GetAsync(key, hideErrors, token);
            if (value != null)
            {
                return value;
            }

            using (await SyncSemaphore.LockAsync(token))
            {
                value = await GetAsync(key, hideErrors, token);
                if (value != null)
                {
                    return value;
                }

                value = await factory();
                await SetAsync(key, value, optionsFactory?.Invoke(), hideErrors, token);
            }

            return value;
        }

        /// <summary>
        /// Sets the cache item value for the provided key.
        /// </summary>
        /// <param name="key">The key of cached item to be retrieved from the cache.</param>
        /// <param name="value">The cache item value to set in the cache.</param>
        /// <param name="options">The cache options for the value.</param>
        /// <param name="hideErrors">Indicates to throw or hide the exceptions for the distributed cache.</param>
        public virtual void Set(
            TCacheKey key,
            TCacheItem value,
            DistributedCacheEntryOptions options = null,
            bool? hideErrors = null)
        {
            hideErrors = hideErrors ?? _distributedCacheOption.HideErrors;

            try
            {
                Cache.Set(
                    NormalizeKey(key),
                    Serializer.Serialize(value),
                    options ?? DefaultCacheOptions
                );
            }
            catch (Exception ex)
            {
                if (hideErrors == true)
                {
                    AsyncHelper.RunSync(() => HandleExceptionAsync(ex));
                    return;
                }

                throw;
            }
        }

        /// <summary>
        /// Sets the cache item value for the provided key.
        /// </summary>
        /// <param name="key">The key of cached item to be retrieved from the cache.</param>
        /// <param name="value">The cache item value to set in the cache.</param>
        /// <param name="options">The cache options for the value.</param>
        /// <param name="hideErrors">Indicates to throw or hide the exceptions for the distributed cache.</param>
        /// <param name="token">The <see cref="T:System.Threading.CancellationToken" /> for the task.</param>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> indicating that the operation is asynchronous.</returns>
        public virtual async Task SetAsync(
            TCacheKey key,
            TCacheItem value,
            DistributedCacheEntryOptions options = null,
            bool? hideErrors = null,
            CancellationToken token = default)
        {
            hideErrors = hideErrors ?? _distributedCacheOption.HideErrors;

            try
            {
                await Cache.SetAsync(
                    NormalizeKey(key),
                    Serializer.Serialize(value),
                    options ?? DefaultCacheOptions,
                    CancellationTokenProvider.FallbackToProvider(token)
                );
            }
            catch (Exception ex)
            {
                if (hideErrors == true)
                {
                    await HandleExceptionAsync(ex);
                    return;
                }

                throw;
            }
        }

        /// <summary>
        /// Refreshes the cache value of the given key, and resets its sliding expiration timeout.
        /// </summary>
        /// <param name="key">The key of cached item to be retrieved from the cache.</param>
        /// <param name="hideErrors">Indicates to throw or hide the exceptions for the distributed cache.</param>
        public virtual void Refresh(
            TCacheKey key, bool?
            hideErrors = null)
        {
            hideErrors = hideErrors ?? _distributedCacheOption.HideErrors;

            try
            {
                Cache.Refresh(NormalizeKey(key));
            }
            catch (Exception ex)
            {
                if (hideErrors == true)
                {
                    AsyncHelper.RunSync(() => HandleExceptionAsync(ex));
                    return;
                }

                throw;
            }
        }
        /// <summary>
        /// Refreshes the cache value of the given key, and resets its sliding expiration timeout.
        /// </summary>
        /// <param name="key">The key of cached item to be retrieved from the cache.</param>
        /// <param name="hideErrors">Indicates to throw or hide the exceptions for the distributed cache.</param>
        /// <param name="token">The <see cref="T:System.Threading.CancellationToken" /> for the task.</param>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> indicating that the operation is asynchronous.</returns>
        public virtual async Task RefreshAsync(
            TCacheKey key,
            bool? hideErrors = null,
            CancellationToken token = default)
        {
            hideErrors = hideErrors ?? _distributedCacheOption.HideErrors;

            try
            {
                await Cache.RefreshAsync(NormalizeKey(key), CancellationTokenProvider.FallbackToProvider(token));
            }
            catch (Exception ex)
            {
                if (hideErrors == true)
                {
                    await HandleExceptionAsync(ex);
                    return;
                }

                throw;
            }
        }

        /// <summary>
        /// Removes the cache item for given key from cache.
        /// </summary>
        /// <param name="key">The key of cached item to be retrieved from the cache.</param>
        /// <param name="hideErrors">Indicates to throw or hide the exceptions for the distributed cache.</param>
        public virtual void Remove(
            TCacheKey key,
            bool? hideErrors = null)
        {
            hideErrors = hideErrors ?? _distributedCacheOption.HideErrors;

            try
            {
                Cache.Remove(NormalizeKey(key));
            }
            catch (Exception ex)
            {
                if (hideErrors == true)
                {
                    AsyncHelper.RunSync(() => HandleExceptionAsync(ex));
                    return;
                }

                throw;
            }
        }

        /// <summary>
        /// Removes the cache item for given key from cache.
        /// </summary>
        /// <param name="key">The key of cached item to be retrieved from the cache.</param>
        /// <param name="hideErrors">Indicates to throw or hide the exceptions for the distributed cache.</param>
        /// <param name="token">The <see cref="T:System.Threading.CancellationToken" /> for the task.</param>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> indicating that the operation is asynchronous.</returns>
        public virtual async Task RemoveAsync(
            TCacheKey key,
            bool? hideErrors = null,
            CancellationToken token = default)
        {
            hideErrors = hideErrors ?? _distributedCacheOption.HideErrors;

            try
            {
                await Cache.RemoveAsync(NormalizeKey(key), CancellationTokenProvider.FallbackToProvider(token));
            }
            catch (Exception ex)
            {
                if (hideErrors == true)
                {
                    await HandleExceptionAsync(ex);
                    return;
                }

                throw;
            }
        }

        /// <summary>
        /// handle exception as an asynchronous operation.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns>Task.</returns>
        protected virtual async Task HandleExceptionAsync(Exception ex)
        {
            Logger.LogException(ex, LogLevel.Warning);

            using (var scope = ServiceScopeFactory.CreateScope())
            {
                await scope.ServiceProvider
                    .GetRequiredService<IExceptionNotifier>()
                    .NotifyAsync(new ExceptionNotificationContext(ex, LogLevel.Warning));
            }
        }
    }
}