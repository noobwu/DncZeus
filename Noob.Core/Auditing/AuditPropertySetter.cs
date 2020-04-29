// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="AuditPropertySetter.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Noob.DependencyInjection;
using Noob.Users;

namespace Noob.Auditing
{
    /// <summary>
    /// Class AuditPropertySetter.
    /// Implements the <see cref="Noob.Auditing.IAuditPropertySetter" />
    /// Implements the <see cref="Noob.DependencyInjection.ITransientDependency" />
    /// </summary>
    /// <seealso cref="Noob.Auditing.IAuditPropertySetter" />
    /// <seealso cref="Noob.DependencyInjection.ITransientDependency" />
    public class AuditPropertySetter : IAuditPropertySetter, ITransientDependency
    {
        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <value>The current user.</value>
        protected ICurrentUser CurrentUser { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditPropertySetter"/> class.
        /// </summary>
        /// <param name="currentUser">The current user.</param>
        public AuditPropertySetter(ICurrentUser currentUser)
        {
            CurrentUser = currentUser;
        }

        /// <summary>
        /// Sets the creation properties.
        /// </summary>
        /// <param name="targetObject">The target object.</param>
        public void SetCreationProperties(object targetObject)
        {
            SetCreationTime(targetObject);
            SetCreatorId(targetObject);
        }

        /// <summary>
        /// Sets the modification properties.
        /// </summary>
        /// <param name="targetObject">The target object.</param>
        public void SetModificationProperties(object targetObject)
        {
            SetLastModificationTime(targetObject);
            SetLastModifierId(targetObject);
        }

        /// <summary>
        /// Sets the deletion properties.
        /// </summary>
        /// <param name="targetObject">The target object.</param>
        public void SetDeletionProperties(object targetObject)
        {
            SetDeletionTime(targetObject);
            SetDeleterId(targetObject);
        }

        /// <summary>
        /// Sets the creation time.
        /// </summary>
        /// <param name="targetObject">The target object.</param>
        private void SetCreationTime(object targetObject)
        {
            if (!(targetObject is IHasCreationTime objectWithCreationTime))
            {
                return;
            }

            if (objectWithCreationTime.CreationTime == default)
            {
                objectWithCreationTime.CreationTime = System.DateTime.Now;
            }
        }

        /// <summary>
        /// Sets the creator identifier.
        /// </summary>
        /// <param name="targetObject">The target object.</param>
        private void SetCreatorId(object targetObject)
        {
            if (!CurrentUser.Id.HasValue)
            {
                return;
            }
            if (targetObject is IMayHaveCreator mayHaveCreatorObject)
            {
                if (mayHaveCreatorObject.CreatorId.HasValue && mayHaveCreatorObject.CreatorId.Value != default)
                {
                    return;
                }

                mayHaveCreatorObject.CreatorId = CurrentUser.Id;
            }
            else if (targetObject is IMustHaveCreator mustHaveCreatorObject)
            {
                if (mustHaveCreatorObject.CreatorId != default)
                {
                    return;
                }

                mustHaveCreatorObject.CreatorId = CurrentUser.Id.Value;
            }
        }

        /// <summary>
        /// Sets the last modification time.
        /// </summary>
        /// <param name="targetObject">The target object.</param>
        private void SetLastModificationTime(object targetObject)
        {
            if (targetObject is IHasModificationTime objectWithModificationTime)
            {
                objectWithModificationTime.LastModificationTime = System.DateTime.Now;
            }
        }

        /// <summary>
        /// Sets the last modifier identifier.
        /// </summary>
        /// <param name="targetObject">The target object.</param>
        private void SetLastModifierId(object targetObject)
        {
            if (!(targetObject is IModificationAuditedObject modificationAuditedObject))
            {
                return;
            }

            if (!CurrentUser.Id.HasValue)
            {
                modificationAuditedObject.LastModifierId = null;
                return;
            }
            modificationAuditedObject.LastModifierId = CurrentUser.Id;
        }

        /// <summary>
        /// Sets the deletion time.
        /// </summary>
        /// <param name="targetObject">The target object.</param>
        private void SetDeletionTime(object targetObject)
        {
            if (targetObject is IHasDeletionTime objectWithDeletionTime)
            {
                if (objectWithDeletionTime.DeletionTime == null)
                {
                    objectWithDeletionTime.DeletionTime = System.DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Sets the deleter identifier.
        /// </summary>
        /// <param name="targetObject">The target object.</param>
        private void SetDeleterId(object targetObject)
        {
            if (!(targetObject is IDeletionAuditedObject deletionAuditedObject))
            {
                return;
            }

            if (deletionAuditedObject.DeleterId != null)
            {
                return;
            }

            if (!CurrentUser.Id.HasValue)
            {
                deletionAuditedObject.DeleterId = null;
                return;
            }
            deletionAuditedObject.DeleterId = CurrentUser.Id;
        }
    }
}
