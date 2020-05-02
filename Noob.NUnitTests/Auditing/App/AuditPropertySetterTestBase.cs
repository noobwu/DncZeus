// ***********************************************************************
// Assembly         : Noob.NUnitTests
// Author           : Administrator
// Created          : 2020-05-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-05-01
// ***********************************************************************
// <copyright file="AuditPropertySetterTestBase.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using NSubstitute;
using Noob.Users;

namespace Noob.Auditing
{
    /// <summary>
    /// Class AuditPropertySetterTestBase.
    /// </summary>
    public class AuditPropertySetterTestBase
    {
        /// <summary>
        /// The current user identifier
        /// </summary>
        protected Guid? CurrentUserId = null;
        /// <summary>
        /// The time subtract seconds
        /// </summary>
        protected int TimeSubtractSeconds = 5;
        /// <summary>
        /// The now
        /// </summary>
        protected DateTime Now = DateTime.Now;

        /// <summary>
        /// The target object
        /// </summary>
        protected MyAuditedObject TargetObject;

        /// <summary>
        /// The audit property setter
        /// </summary>
        protected readonly AuditPropertySetter AuditPropertySetter;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditPropertySetterTestBase"/> class.
        /// </summary>
        public AuditPropertySetterTestBase()
        {
            AuditPropertySetter = CreateAuditPropertySetter();
            TargetObject = new MyAuditedObject();
        }

        /// <summary>
        /// Creates the audit property setter.
        /// </summary>
        /// <returns>AuditPropertySetter.</returns>
        private AuditPropertySetter CreateAuditPropertySetter()
        {
            var currentUser = Substitute.For<ICurrentUser>();
            currentUser.Id.Returns(ci => CurrentUserId);
            return new AuditPropertySetter(
                currentUser
            );
        }

        /// <summary>
        /// Class MyEmptyObject.
        /// </summary>
        public class MyEmptyObject
        {
            
        }

        /// <summary>
        /// Class MyAuditedObject.
        /// Implements the <see cref="IMultiTenant" />
        /// Implements the <see cref="Noob.Auditing.IFullAuditedObject" />
        /// </summary>
        /// <seealso cref="IMultiTenant" />
        /// <seealso cref="Noob.Auditing.IFullAuditedObject" />
        public class MyAuditedObject : IFullAuditedObject
        {
            /// <summary>
            /// Gets or sets the creation time.
            /// </summary>
            /// <value>The creation time.</value>
            public DateTime CreationTime { get; set; }
            /// <summary>
            /// Gets or sets the creator identifier.
            /// </summary>
            /// <value>The creator identifier.</value>
            public Guid? CreatorId { get; set; }
            /// <summary>
            /// Gets or sets the last modification time.
            /// </summary>
            /// <value>The last modification time.</value>
            public DateTime? LastModificationTime { get; set; }
            /// <summary>
            /// Gets or sets the last modifier identifier.
            /// </summary>
            /// <value>The last modifier identifier.</value>
            public Guid? LastModifierId { get; set; }
            /// <summary>
            /// Gets or sets a value indicating whether this instance is deleted.
            /// </summary>
            /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
            public bool IsDeleted { get; set; }
            /// <summary>
            /// Gets or sets the deletion time.
            /// </summary>
            /// <value>The deletion time.</value>
            public DateTime? DeletionTime { get; set; }
            /// <summary>
            /// Gets or sets the deleter identifier.
            /// </summary>
            /// <value>The deleter identifier.</value>
            public Guid? DeleterId { get; set; }
        }
    }
}
