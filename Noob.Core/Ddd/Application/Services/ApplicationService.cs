// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-03
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-03
// ***********************************************************************
// <copyright file="ApplicationService.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Noob.Aspects;
using Noob.Auditing;
using Noob.DependencyInjection;
using Noob.Guids;
using Noob.ObjectMapping;
using Noob.Uow;
using Noob.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Noob.Application.Services
{
    /// <summary>
    /// Class ApplicationService.
    /// Implements the <see cref="Noob.Application.Services.IApplicationService" />
    /// Implements the <see cref="Noob.Aspects.IAvoidDuplicateCrossCuttingConcerns" />
    /// Implements the <see cref="Noob.Validation.IValidationEnabled" />
    /// Implements the <see cref="Noob.Uow.IUnitOfWorkEnabled" />
    /// Implements the <see cref="Noob.Auditing.IAuditingEnabled" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.Application.Services.IApplicationService" />
    /// <seealso cref="Noob.Aspects.IAvoidDuplicateCrossCuttingConcerns" />
    /// <seealso cref="Noob.Validation.IValidationEnabled" />
    /// <seealso cref="Noob.Uow.IUnitOfWorkEnabled" />
    /// <seealso cref="Noob.Auditing.IAuditingEnabled" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public abstract class ApplicationService :
      IApplicationService,
      IAvoidDuplicateCrossCuttingConcerns,
      IValidationEnabled,
      IUnitOfWorkEnabled,
      IAuditingEnabled,
      ITransientDependency
    {
        /// <summary>
        /// Gets or sets the service provider.
        /// </summary>
        /// <value>The service provider.</value>
        public IServiceProvider ServiceProvider { get; set; }
        /// <summary>
        /// The service provider lock
        /// </summary>
        protected readonly object ServiceProviderLock = new object();

        /// <summary>
        /// Lazies the get required service.
        /// </summary>
        /// <typeparam name="TService">The type of the t service.</typeparam>
        /// <param name="reference">The reference.</param>
        /// <returns>TService.</returns>
        protected TService LazyGetRequiredService<TService>(ref TService reference)
            => LazyGetRequiredService(typeof(TService), ref reference);

        /// <summary>
        /// Lazies the get required service.
        /// </summary>
        /// <typeparam name="TRef">The type of the t reference.</typeparam>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="reference">The reference.</param>
        /// <returns>TRef.</returns>
        protected TRef LazyGetRequiredService<TRef>(Type serviceType, ref TRef reference)
        {
            if (reference == null)
            {
                lock (ServiceProviderLock)
                {
                    if (reference == null)
                    {
                        reference = (TRef)ServiceProvider.GetRequiredService(serviceType);
                    }
                }
            }

            return reference;
        }

        /// <summary>
        /// Gets or sets the common postfixes.
        /// </summary>
        /// <value>The common postfixes.</value>
        public static string[] CommonPostfixes { get; set; } = { "AppService", "ApplicationService", "Service" };

        /// <summary>
        /// Gets the applied cross cutting concerns.
        /// </summary>
        /// <value>The applied cross cutting concerns.</value>
        public List<string> AppliedCrossCuttingConcerns { get; } = new List<string>();

        /// <summary>
        /// Gets the unit of work manager.
        /// </summary>
        /// <value>The unit of work manager.</value>
        public IUnitOfWorkManager UnitOfWorkManager => LazyGetRequiredService(ref _unitOfWorkManager);
        /// <summary>
        /// The unit of work manager
        /// </summary>
        private IUnitOfWorkManager _unitOfWorkManager;

        /// <summary>
        /// Gets or sets the object mapper context.
        /// </summary>
        /// <value>The object mapper context.</value>
        protected Type ObjectMapperContext { get; set; }
        /// <summary>
        /// Gets the object mapper.
        /// </summary>
        /// <value>The object mapper.</value>
        public IObjectMapper ObjectMapper
        {
            get
            {
                if (_objectMapper != null)
                {
                    return _objectMapper;
                }

                if (ObjectMapperContext == null)
                {
                    return LazyGetRequiredService(ref _objectMapper);
                }

                return LazyGetRequiredService(
                    typeof(IObjectMapper<>).MakeGenericType(ObjectMapperContext),
                    ref _objectMapper
                );
            }
        }
        /// <summary>
        /// The object mapper
        /// </summary>
        private IObjectMapper _objectMapper;

        /// <summary>
        /// Gets or sets the unique identifier generator.
        /// </summary>
        /// <value>The unique identifier generator.</value>
        public IGuidGenerator GuidGenerator { get; set; }

        /// <summary>
        /// Gets the logger factory.
        /// </summary>
        /// <value>The logger factory.</value>
        public ILoggerFactory LoggerFactory => LazyGetRequiredService(ref _loggerFactory);
        /// <summary>
        /// The logger factory
        /// </summary>
        private ILoggerFactory _loggerFactory;
        /// <summary>
        /// Gets the authorization service.
        /// </summary>
        /// <value>The authorization service.</value>
        public IAuthorizationService AuthorizationService => LazyGetRequiredService(ref _authorizationService);
        /// <summary>
        /// The authorization service
        /// </summary>
        private IAuthorizationService _authorizationService;

        /// <summary>
        /// Checks for given <paramref name="policyName" />.
        /// Throws <see cref="AbpAuthorizationException" /> if given policy has not been granted.
        /// </summary>
        /// <param name="policyName">The policy name. This method does nothing if given <paramref name="policyName" /> is null or empty.</param>
        /// <returns>Task.</returns>
        protected virtual async Task CheckPolicyAsync([CanBeNull] string policyName)
        {
            if (string.IsNullOrEmpty(policyName))
            {
                return;
            }

            await AuthorizationService.CheckAsync(policyName);
        }
    }
}
