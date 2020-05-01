// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-01
// ***********************************************************************
// <copyright file="AuditPropertySetter_ModificationAudit_Tests.cs" company="">
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
    /// Class AuditPropertySetter_ModificationAudit_Tests.
    /// Implements the <see cref="Noob.Auditing.AuditPropertySetterTestBase" />
    /// </summary>
    /// <seealso cref="Noob.Auditing.AuditPropertySetterTestBase" />
    public class AuditPropertySetter_ModificationAudit_Tests : AuditPropertySetterTestBase
    {
        /// <summary>
        /// Defines the test method Should_Do_Nothing_For_Non_Audited_Entity.
        /// </summary>
        [TestCase]
        public void Should_Do_Nothing_For_Non_Audited_Entity()
        {
            AuditPropertySetter.SetModificationProperties(new MyEmptyObject());
        }

        /// <summary>
        /// Defines the test method Should_Set_LastModificationTime.
        /// </summary>
        [TestCase]
        public void Should_Set_LastModificationTime()
        {
            AuditPropertySetter.SetModificationProperties(TargetObject);

            TargetObject.LastModificationTime.ShouldBe(Now);
        }

        /// <summary>
        /// Defines the test method Should_Clear_LastModifierId_If_Current_User_Is_Not_Available.
        /// </summary>
        [TestCase]
        public void Should_Clear_LastModifierId_If_Current_User_Is_Not_Available()
        {
            TargetObject.LastModifierId = Guid.NewGuid();

            AuditPropertySetter.SetModificationProperties(TargetObject);

            TargetObject.LastModificationTime.ShouldBe(Now);
            TargetObject.LastModifierId.ShouldBe(null);
        }

        /// <summary>
        /// Defines the test method Should_Set_LastModifierId.
        /// </summary>
        [TestCase]
        public void Should_Set_LastModifierId()
        {
            CurrentUserId = Guid.NewGuid();

            AuditPropertySetter.SetModificationProperties(TargetObject);

            TargetObject.LastModificationTime.ShouldBe(Now);
            TargetObject.LastModifierId.ShouldBe(CurrentUserId);
        }

        /// <summary>
        /// Defines the test method Should_Set_LastModifierId_Again_Even_If_It_Is_Set_Before.
        /// </summary>
        [TestCase]
        public void Should_Set_LastModifierId_Again_Even_If_It_Is_Set_Before()
        {
            CurrentUserId = Guid.NewGuid();
            TargetObject.LastModifierId = Guid.NewGuid();

            AuditPropertySetter.SetModificationProperties(TargetObject);

            TargetObject.LastModificationTime.ShouldBe(Now);
            TargetObject.LastModifierId.ShouldBe(CurrentUserId);
        }

        /// <summary>
        /// Defines the test method Should_Set_LastModifierId_If_Entity_Tenant_Is_Same_With_Current_User_Tenant.
        /// </summary>
        [TestCase]
        public void Should_Set_LastModifierId_If_Entity_Tenant_Is_Same_With_Current_User_Tenant()
        {
            CurrentUserId = Guid.NewGuid();

            AuditPropertySetter.SetModificationProperties(TargetObject);

            TargetObject.LastModificationTime.ShouldBe(Now);
            TargetObject.LastModifierId.ShouldBe(CurrentUserId);
        }

        /// <summary>
        /// Defines the test method Should_Clear_LastModifierId_If_Entity_Tenant_Is_Different_From_Current_User_Tenant.
        /// </summary>
        [TestCase]
        public void Should_Clear_LastModifierId_If_Entity_Tenant_Is_Different_From_Current_User_Tenant()
        {
            CurrentUserId = Guid.NewGuid();
            TargetObject.LastModifierId = Guid.NewGuid();

            AuditPropertySetter.SetModificationProperties(TargetObject);

            TargetObject.LastModificationTime.ShouldBe(Now);
            TargetObject.LastModifierId.ShouldBe(null);
        }
    }
}