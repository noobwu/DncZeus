// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-05-17
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-17
// ***********************************************************************
// <copyright file="ExceptionNotifier.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Noob.DependencyInjection;

namespace Noob.ExceptionHandling
{
    /// <summary>
    /// Class ExceptionNotifier.
    /// Implements the <see cref="Noob.ExceptionHandling.IExceptionNotifier" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.ExceptionHandling.IExceptionNotifier" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class ExceptionNotifier : IExceptionNotifier, ITransientDependency
    {
        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        /// <value>The logger.</value>
        public ILogger<ExceptionNotifier> Logger { get; set; }

        /// <summary>
        /// Gets the service scope factory.
        /// </summary>
        /// <value>The service scope factory.</value>
        protected IHybridServiceScopeFactory ServiceScopeFactory { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionNotifier"/> class.
        /// </summary>
        /// <param name="serviceScopeFactory">The service scope factory.</param>
        public ExceptionNotifier(IHybridServiceScopeFactory serviceScopeFactory)
        {
            ServiceScopeFactory = serviceScopeFactory;
            Logger = NullLogger<ExceptionNotifier>.Instance;
        }

        /// <summary>
        /// notify as an asynchronous operation.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Task.</returns>
        public virtual async Task NotifyAsync([NotNull] ExceptionNotificationContext context)
        {
            Check.NotNull(context, nameof(context));

            using (var scope = ServiceScopeFactory.CreateScope())
            {
                var exceptionSubscribers = scope.ServiceProvider
                    .GetServices<IExceptionSubscriber>();

                foreach (var exceptionSubscriber in exceptionSubscribers)
                {
                    try
                    {
                        await exceptionSubscriber.HandleAsync(context);
                    }
                    catch (Exception e)
                    {
                        Logger.LogWarning($"Exception subscriber of type {exceptionSubscriber.GetType().AssemblyQualifiedName} has thrown an exception!");
                        Logger.LogException(e, LogLevel.Warning);
                    }
                }
            }
        }
    }
}
