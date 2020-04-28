// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-29
// ***********************************************************************
// <copyright file="EntityChangeInfo.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using Noob.Data;

namespace Noob.Auditing
{
    /// <summary>
    /// Class EntityChangeInfo.
    /// Implements the <see cref="Noob.Data.IHasExtraProperties" />
    /// </summary>
    /// <seealso cref="Noob.Data.IHasExtraProperties" />
    [Serializable]
    public class EntityChangeInfo : IHasExtraProperties
    {
        /// <summary>
        /// Gets or sets the change time.
        /// </summary>
        /// <value>The change time.</value>
        public DateTime ChangeTime { get; set; }

        /// <summary>
        /// Gets or sets the type of the change.
        /// </summary>
        /// <value>The type of the change.</value>
        public EntityChangeType ChangeType { get; set; }

        /// <summary>
        /// TenantId of the related entity.
        /// This is not the TenantId of the audit log entry.
        /// There can be multiple tenant data changes in a single audit log entry.
        /// </summary>
        /// <value>The entity tenant identifier.</value>
        public Guid? EntityTenantId { get; set; }

        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>The entity identifier.</value>
        public string EntityId { get; set; }

        /// <summary>
        /// Gets or sets the full name of the entity type.
        /// </summary>
        /// <value>The full name of the entity type.</value>
        public string EntityTypeFullName { get; set; }

        /// <summary>
        /// Gets or sets the property changes.
        /// </summary>
        /// <value>The property changes.</value>
        public List<EntityPropertyChangeInfo> PropertyChanges { get; set; }

        /// <summary>
        /// Gets the extra properties.
        /// </summary>
        /// <value>The extra properties.</value>
        public Dictionary<string, object> ExtraProperties { get; }

        /// <summary>
        /// Gets or sets the entity entry.
        /// </summary>
        /// <value>The entity entry.</value>
        public virtual object EntityEntry { get; set; } //TODO: Try to remove since it breaks serializability

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityChangeInfo"/> class.
        /// </summary>
        public EntityChangeInfo()
        {
            ExtraProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Merges the specified change information.
        /// </summary>
        /// <param name="changeInfo">The change information.</param>
        public virtual void Merge(EntityChangeInfo changeInfo)
        {
            foreach (var propertyChange in changeInfo.PropertyChanges)
            {
                var existingChange = PropertyChanges.FirstOrDefault(p => p.PropertyName == propertyChange.PropertyName);
                if (existingChange == null)
                {
                    PropertyChanges.Add(propertyChange);
                }
                else
                {
                    existingChange.NewValue = propertyChange.NewValue;
                }
            }

            foreach (var extraProperty in changeInfo.ExtraProperties)
            {
                var key = extraProperty.Key;
                if (ExtraProperties.ContainsKey(key))
                {
                    key = InternalUtils.AddCounter(key);
                }

                ExtraProperties[key] = extraProperty.Value;
            }
        }
    }
}
