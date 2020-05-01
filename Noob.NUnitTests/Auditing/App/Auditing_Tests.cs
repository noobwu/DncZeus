// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-01
// ***********************************************************************
// <copyright file="Auditing_Tests.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NSubstitute;
using Noob.Auditing.App.Entities;
using Noob.DependencyInjection;
using Noob.Domain.Repositories;
using NUnit.Framework;

namespace Noob.Auditing
{
    /// <summary>
    /// Class Auditing_Tests.
    /// Implements the <see cref="Noob.Auditing.AuditingTestBase" />
    /// </summary>
    /// <seealso cref="Noob.Auditing.AuditingTestBase" />
    public class Auditing_Tests : AuditingTestBase
    {
        /// <summary>
        /// The auditing store
        /// </summary>
        private IAuditingStore _auditingStore;
        /// <summary>
        /// The auditing manager
        /// </summary>
        private IAuditingManager _auditingManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="Auditing_Tests"/> class.
        /// </summary>
        public Auditing_Tests()
        {
            _auditingManager = GetRequiredService<IAuditingManager>();
        }

        /// <summary>
        /// Afters the add application.
        /// </summary>
        /// <param name="services">The services.</param>
        protected override void AfterAddApplication(IServiceCollection services)
        {
            _auditingStore = Substitute.For<IAuditingStore>();
            services.Replace(ServiceDescriptor.Singleton(_auditingStore));
        }

        /// <summary>
        /// Defines the test method Should_Write_AuditLog_For_Classes_That_Implement_IAuditingEnabled.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public async Task Should_Write_AuditLog_For_Classes_That_Implement_IAuditingEnabled()
        {
            var myAuditedObject1 = GetRequiredService<MyAuditedObject1>();

            using (var scope = _auditingManager.BeginScope())
            {
                await myAuditedObject1.DoItAsync(new InputObject { Value1 = "forty-two", Value2 = 42 });
                await scope.SaveAsync();
            }

#pragma warning disable 4014
            _auditingStore.Received().SaveAsync(Arg.Any<AuditLogInfo>());
#pragma warning restore 4014
        }

        /// <summary>
        /// Interface IMyAuditedObject
        /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
        /// Implements the <see cref="Noob.Auditing.IAuditingEnabled" />
        /// </summary>
        /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
        /// <seealso cref="Noob.Auditing.IAuditingEnabled" />
        public interface IMyAuditedObject : ITransientDependency, IAuditingEnabled
        {

        }

        /// <summary>
        /// Class MyAuditedObject1.
        /// Implements the <see cref="Noob.Auditing.Auditing_Tests.IMyAuditedObject" />
        /// </summary>
        /// <seealso cref="Noob.Auditing.Auditing_Tests.IMyAuditedObject" />
        public class MyAuditedObject1 : IMyAuditedObject
        {
            /// <summary>
            /// do it as an asynchronous operation.
            /// </summary>
            /// <param name="inputObject">The input object.</param>
            /// <returns>Task&lt;ResultObject&gt;.</returns>
            public async virtual Task<ResultObject> DoItAsync(InputObject inputObject)
            {
                return new ResultObject
                {
                    Value1 = inputObject.Value1 + "-result",
                    Value2 = inputObject.Value2 + 1
                };
            }
        }

        /// <summary>
        /// Class ResultObject.
        /// </summary>
        public class ResultObject
        {
            /// <summary>
            /// Gets or sets the value1.
            /// </summary>
            /// <value>The value1.</value>
            public string Value1 { get; set; }

            /// <summary>
            /// Gets or sets the value2.
            /// </summary>
            /// <value>The value2.</value>
            public int Value2 { get; set; }
        }

        /// <summary>
        /// Class InputObject.
        /// </summary>
        public class InputObject
        {
            /// <summary>
            /// Gets or sets the value1.
            /// </summary>
            /// <value>The value1.</value>
            public string Value1 { get; set; }

            /// <summary>
            /// Gets or sets the value2.
            /// </summary>
            /// <value>The value2.</value>
            public int Value2 { get; set; }
        }

        /// <summary>
        /// Defines the test method Should_Write_AuditLog_For_Entity_That_Has_Audited_Attribute.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public virtual async Task Should_Write_AuditLog_For_Entity_That_Has_Audited_Attribute()
        {
            using (var scope = _auditingManager.BeginScope())
            {
                var repository = ServiceProvider.GetRequiredService<IBasicRepository<AppEntityWithAudited, Guid>>();
                await repository.InsertAsync(new AppEntityWithAudited(Guid.NewGuid(), "test name"));
                await scope.SaveAsync();
            }

#pragma warning disable 4014
            _auditingStore.Received().SaveAsync(Arg.Any<AuditLogInfo>());
#pragma warning restore 4014
        }

        /// <summary>
        /// Defines the test method Should_Not_Write_AuditLog_For_Property_That_Has_DisableAuditing_Attribute.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public virtual async Task Should_Not_Write_AuditLog_For_Property_That_Has_DisableAuditing_Attribute()
        {
            using (var scope = _auditingManager.BeginScope())
            {
                var repository = ServiceProvider.GetRequiredService<IBasicRepository<AppEntityWithAuditedAndPropertyHasDisableAuditing, Guid>>();
                await repository.InsertAsync(new AppEntityWithAuditedAndPropertyHasDisableAuditing(Guid.NewGuid(), "test name", "test name2"));
                await scope.SaveAsync();
            }

#pragma warning disable 4014
            _auditingStore.Received().SaveAsync(Arg.Is<AuditLogInfo>(x =>
                x.EntityChanges.Count == 1 &&
                !(x.EntityChanges[0].PropertyChanges.Any(p =>
                    p.PropertyName == nameof(AppEntityWithDisableAuditingAndPropertyHasAudited.Name2)))));
#pragma warning restore 4014
        }

        /// <summary>
        /// Defines the test method Should_Not_Write_AuditLog_For_Entity_That_Has_DisableAuditing_Attribute.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public virtual async Task Should_Not_Write_AuditLog_For_Entity_That_Has_DisableAuditing_Attribute()
        {
            using (var scope = _auditingManager.BeginScope())
            {
                var repository = ServiceProvider.GetRequiredService<IBasicRepository<AppEntityWithDisableAuditing, Guid>>();
                await repository.InsertAsync(new AppEntityWithDisableAuditing(Guid.NewGuid(), "test name"));
                await scope.SaveAsync();
            }

#pragma warning disable 4014
            _auditingStore.Received().SaveAsync(Arg.Is<AuditLogInfo>(a => !a.EntityChanges.Any()));
#pragma warning restore 4014
        }

        /// <summary>
        /// Defines the test method Should_Write_AuditLog_For_Entity_That_Meet_Selectors.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public virtual async Task Should_Write_AuditLog_For_Entity_That_Meet_Selectors()
        {
            using (var scope = _auditingManager.BeginScope())
            {
                var repository = ServiceProvider.GetRequiredService<IBasicRepository<AppEntityWithSelector, Guid>>();
                await repository.InsertAsync(new AppEntityWithSelector(Guid.NewGuid(), "test name"));
                await scope.SaveAsync();
            }

#pragma warning disable 4014
            _auditingStore.Received().SaveAsync(Arg.Any<AuditLogInfo>());
#pragma warning restore 4014
        }

        /// <summary>
        /// Defines the test method Should_Write_AuditLog_For_Entity_That_Property_Has_Audited_Attribute.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public virtual async Task Should_Write_AuditLog_For_Entity_That_Property_Has_Audited_Attribute()
        {
            using (var scope = _auditingManager.BeginScope())
            {
                var repository = ServiceProvider.GetRequiredService<IBasicRepository<AppEntityWithPropertyHasAudited, Guid>>();
                await repository.InsertAsync(new AppEntityWithPropertyHasAudited(Guid.NewGuid(), "test name"));
                await scope.SaveAsync();
            }

#pragma warning disable 4014
            _auditingStore.Received().SaveAsync(Arg.Any<AuditLogInfo>());
#pragma warning restore 4014
        }

        /// <summary>
        /// Defines the test method Should_Write_AuditLog_For_Entity_That_Property_Has_Audited_Attribute_Even_Entity_Has_DisableAuditing_Attribute.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public virtual async Task Should_Write_AuditLog_For_Entity_That_Property_Has_Audited_Attribute_Even_Entity_Has_DisableAuditing_Attribute()
        {
            using (var scope = _auditingManager.BeginScope())
            {
                var repository = ServiceProvider.GetRequiredService<IBasicRepository<AppEntityWithDisableAuditingAndPropertyHasAudited, Guid>>();
                await repository.InsertAsync(new AppEntityWithDisableAuditingAndPropertyHasAudited(Guid.NewGuid(), "test name", "test name2"));
                await scope.SaveAsync();
            }

#pragma warning disable 4014
            _auditingStore.Received().SaveAsync(Arg.Is<AuditLogInfo>(x =>
                x.EntityChanges.Count == 1 && x.EntityChanges[0].PropertyChanges.Count == 1 &&
                x.EntityChanges[0].PropertyChanges[0].PropertyName ==
                nameof(AppEntityWithDisableAuditingAndPropertyHasAudited.Name)));
#pragma warning restore 4014
        }


        /// <summary>
        /// Defines the test method Should_Write_AuditLog_If_There_No_Action_And_No_EntityChanges.
        /// </summary>
        /// <returns>Task.</returns>
        [TestCase]
        public virtual async Task Should_Write_AuditLog_If_There_No_Action_And_No_EntityChanges()
        {
            using (var scope = _auditingManager.BeginScope())
            {
                await scope.SaveAsync();
            }

#pragma warning disable 4014
            _auditingStore.Received().SaveAsync(Arg.Any<AuditLogInfo>());
#pragma warning restore 4014
        }

    }
}
