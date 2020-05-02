// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-01
// ***********************************************************************
// <copyright file="AuditPropertySetter_CreationAudit_Tests.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Shouldly;
using NUnit.Framework;

namespace Noob.Auditing
{
    /// <summary>
    /// Class AuditPropertySetter_CreationAudit_Tests.
    /// Implements the <see cref="Noob.Auditing.AuditPropertySetterTestBase" />
    /// </summary>
    /// <seealso cref="Noob.Auditing.AuditPropertySetterTestBase" />
    public class AuditPropertySetter_CreationAudit_Tests : AuditPropertySetterTestBase
    {
        /// <summary>
        /// Defines the test method Should_Do_Nothing_For_Non_Audited_Entity.
        /// </summary>
        [TestCase]
        public void Should_Do_Nothing_For_Non_Audited_Entity()
        {
            AuditPropertySetter.SetCreationProperties(new MyEmptyObject());
        }

        /// <summary>
        /// Defines the test method Should_Set_CreationTime.
        /// </summary>
        [TestCase]
        public void Should_Set_CreationTime()
        {
            AuditPropertySetter.SetCreationProperties(TargetObject);

            TargetObject.CreationTime.Subtract(Now).TotalSeconds.ShouldBeLessThanOrEqualTo(TimeSubtractSeconds);
        }

        /// <summary>
        /// Defines the test method Should_Not_Set_CreatorId_If_Current_User_Is_Not_Available.
        /// </summary>
        [TestCase]
        public void Should_Not_Set_CreatorId_If_Current_User_Is_Not_Available()
        {
            AuditPropertySetter.SetCreationProperties(TargetObject);

            TargetObject.CreationTime.Subtract(Now).TotalSeconds.ShouldBeLessThanOrEqualTo(TimeSubtractSeconds);
            TargetObject.CreatorId.ShouldBe(null);
        }

        /// <summary>
        /// Defines the test method Should_Set_CreatorId.
        /// </summary>
        [TestCase]
        public void Should_Set_CreatorId()
        {
            CurrentUserId = Guid.NewGuid();

            AuditPropertySetter.SetCreationProperties(TargetObject);

            TargetObject.CreationTime.Subtract(Now).TotalSeconds.ShouldBeLessThanOrEqualTo(TimeSubtractSeconds);
            TargetObject.CreatorId.ShouldBe(CurrentUserId);
        }

        /// <summary>
        /// Defines the test method Should_Not_Set_CreatorId_If_It_Is_Already_Set.
        /// </summary>
        [TestCase]
        public void Should_Not_Set_CreatorId_If_It_Is_Already_Set()
        {
            var oldCreatorUserId = Guid.NewGuid();

            CurrentUserId = Guid.NewGuid();
            TargetObject.CreatorId = oldCreatorUserId;

            AuditPropertySetter.SetCreationProperties(TargetObject);

            TargetObject.CreationTime.Subtract(Now).TotalSeconds.ShouldBeLessThanOrEqualTo(TimeSubtractSeconds);
            TargetObject.CreatorId.ShouldBe(oldCreatorUserId);
        }

        /// <summary>
        /// Defines the test method Should_Set_CreatorId_If_Entity_Tenant_Is_Same_With_Current_User_Tenant.
        /// </summary>
        [TestCase]
        public void Should_Set_CreatorId_If_Entity_Tenant_Is_Same_With_Current_User_Tenant()
        {
            CurrentUserId = Guid.NewGuid();

            AuditPropertySetter.SetCreationProperties(TargetObject);

            TargetObject.CreationTime.Subtract(Now).TotalSeconds.ShouldBeLessThanOrEqualTo(TimeSubtractSeconds);
            TargetObject.CreatorId.ShouldBe(CurrentUserId);
        }

        /// <summary>
        /// Defines the test method Should_Not_Set_CreatorId_If_Entity_Tenant_Is_Different_From_Current_User_Tenant.
        /// </summary>
        [TestCase]
        public void Should_Not_Set_CreatorId_If_Entity_Tenant_Is_Different_From_Current_User_Tenant()
        {
            CurrentUserId = Guid.NewGuid();

            AuditPropertySetter.SetCreationProperties(TargetObject);

            TargetObject.CreationTime.Subtract(Now).TotalSeconds.ShouldBeLessThanOrEqualTo(TimeSubtractSeconds);
            TargetObject.CreatorId.ShouldBe(null);
        }
    }
}