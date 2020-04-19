// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-19
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="UnitOfWorkInterceptor.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;
using Noob.DependencyInjection;
using Noob.DynamicProxy;

namespace Noob.Uow
{
    /// <summary>
    /// Class UnitOfWorkInterceptor.
    /// Implements the <see cref="Noob.DynamicProxy.Interceptor" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.DynamicProxy.Interceptor" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class UnitOfWorkInterceptor :Interceptor, ITransientDependency
    {
        /// <summary>
        /// The unit of work manager
        /// </summary>
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        /// <summary>
        /// The default options
        /// </summary>
        private readonly UnitOfWorkDefaultOptions _defaultOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkInterceptor"/> class.
        /// </summary>
        /// <param name="unitOfWorkManager">The unit of work manager.</param>
        /// <param name="options">The options.</param>
        public UnitOfWorkInterceptor(IUnitOfWorkManager unitOfWorkManager, IOptions<UnitOfWorkDefaultOptions> options)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _defaultOptions = options.Value;
        }

        /// <summary>
        /// intercept as an asynchronous operation.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <returns>Task.</returns>
        public override async Task InterceptAsync(IMethodInvocation invocation)
        {
            if (!UnitOfWorkHelper.IsUnitOfWorkMethod(invocation.Method, out var unitOfWorkAttribute))
            {
                await invocation.ProceedAsync();
                return;
            }

            using (var uow = _unitOfWorkManager.Begin(CreateOptions(invocation, unitOfWorkAttribute)))
            {
                await invocation.ProceedAsync();
                await uow.CompleteAsync();
            }
        }

        /// <summary>
        /// Creates the options.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <param name="unitOfWorkAttribute">The unit of work attribute.</param>
        /// <returns>UnitOfWorkOptions.</returns>
        private UnitOfWorkOptions CreateOptions(IMethodInvocation invocation, [CanBeNull] UnitOfWorkAttribute unitOfWorkAttribute)
        {
            var options = new UnitOfWorkOptions();

            unitOfWorkAttribute?.SetOptions(options);

            if (unitOfWorkAttribute?.IsTransactional == null)
            {
                options.IsTransactional = _defaultOptions.CalculateIsTransactional(
                    autoValue: !invocation.Method.Name.StartsWith("Get", StringComparison.InvariantCultureIgnoreCase)
                );
            }

            return options;
        }
    }
}
