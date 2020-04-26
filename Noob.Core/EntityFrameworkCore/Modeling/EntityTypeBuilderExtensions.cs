// ***********************************************************************
// Assembly         : Noob.Core
// Author           : Administrator
// Created          : 2020-04-26
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-26
// ***********************************************************************
// <copyright file="EntityTypeBuilderExtensions.cs" company="Noob.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noob.Auditing;
using Noob.Data;
using Noob.Domain.Entities;
using Noob.EntityFrameworkCore.ValueComparers;
using Noob.EntityFrameworkCore.ValueConverters;
using Noob.ObjectExtending;

namespace Noob.EntityFrameworkCore.Modeling
{
    /// <summary>
    /// Class EntityTypeBuilderExtensions.
    /// </summary>
    public static class EntityTypeBuilderExtensions
    {
        /// <summary>
        /// Configures the by convention.
        /// </summary>
        /// <param name="b">The b.</param>
        public static void ConfigureByConvention(this EntityTypeBuilder b)
        {
            b.TryConfigureConcurrencyStamp();
            b.TryConfigureExtraProperties();
            b.TryConfigureObjectExtensions();
            b.TryConfigureMayHaveCreator();
            b.TryConfigureMustHaveCreator();
            b.TryConfigureSoftDelete();
            b.TryConfigureDeletionTime();
            b.TryConfigureDeletionAudited();
            b.TryConfigureCreationTime();
            b.TryConfigureLastModificationTime();
            b.TryConfigureModificationAudited();
        }

        /// <summary>
        /// Configures the concurrency stamp.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b">The b.</param>
        public static void ConfigureConcurrencyStamp<T>(this EntityTypeBuilder<T> b)
            where T : class, IHasConcurrencyStamp
        {
            b.As<EntityTypeBuilder>().TryConfigureConcurrencyStamp();
        }

        /// <summary>
        /// Tries the configure concurrency stamp.
        /// </summary>
        /// <param name="b">The b.</param>
        public static void TryConfigureConcurrencyStamp(this EntityTypeBuilder b)
        {
            if (b.Metadata.ClrType.IsAssignableTo<IHasConcurrencyStamp>())
            {
                //TODO: Max length?
                b.Property(nameof(IHasConcurrencyStamp.ConcurrencyStamp))
                    .IsConcurrencyToken()
                    .HasColumnName(nameof(IHasConcurrencyStamp.ConcurrencyStamp));
            }
        }

        /// <summary>
        /// Configures the extra properties.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b">The b.</param>
        public static void ConfigureExtraProperties<T>(this EntityTypeBuilder<T> b)
            where T : class, IHasExtraProperties
        {
            b.As<EntityTypeBuilder>().TryConfigureExtraProperties();
        }

        /// <summary>
        /// Tries the configure extra properties.
        /// </summary>
        /// <param name="b">The b.</param>
        public static void TryConfigureExtraProperties(this EntityTypeBuilder b)
        {
            if (!b.Metadata.ClrType.IsAssignableTo<IHasExtraProperties>())
            {
                return;
            }

            b.Property<Dictionary<string, object>>(nameof(IHasExtraProperties.ExtraProperties))
                .HasColumnName(nameof(IHasExtraProperties.ExtraProperties))
                .HasConversion(new ExtraPropertiesValueConverter(b.Metadata.ClrType))
                .Metadata.SetValueComparer(new DictionaryValueComparer<string, object>());

            b.TryConfigureObjectExtensions();
        }

        /// <summary>
        /// Configures the object extensions.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b">The b.</param>
        public static void ConfigureObjectExtensions<T>(this EntityTypeBuilder<T> b)
            where T : class, IHasExtraProperties
        {
            b.As<EntityTypeBuilder>().TryConfigureObjectExtensions();
        }

        /// <summary>
        /// Tries the configure object extensions.
        /// </summary>
        /// <param name="b">The b.</param>
        public static void TryConfigureObjectExtensions(this EntityTypeBuilder b)
        {
            if (b.Metadata.ClrType.IsAssignableTo<IHasExtraProperties>())
            {
                ObjectExtensionManager.Instance.ConfigureEfCoreEntity(b);
            }
        }

        /// <summary>
        /// Configures the soft delete.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b">The b.</param>
        public static void ConfigureSoftDelete<T>(this EntityTypeBuilder<T> b)
            where T : class, ISoftDelete
        {
            b.As<EntityTypeBuilder>().TryConfigureSoftDelete();
        }

        /// <summary>
        /// Tries the configure soft delete.
        /// </summary>
        /// <param name="b">The b.</param>
        public static void TryConfigureSoftDelete(this EntityTypeBuilder b)
        {
            if (b.Metadata.ClrType.IsAssignableTo<ISoftDelete>())
            {
                b.Property(nameof(ISoftDelete.IsDeleted))
                    .IsRequired()
                    .HasDefaultValue(false)
                    .HasColumnName(nameof(ISoftDelete.IsDeleted));
            }
        }

        /// <summary>
        /// Configures the deletion time.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b">The b.</param>
        public static void ConfigureDeletionTime<T>(this EntityTypeBuilder<T> b)
            where T : class, IHasDeletionTime
        {
            b.As<EntityTypeBuilder>().TryConfigureDeletionTime();
        }

        /// <summary>
        /// Tries the configure deletion time.
        /// </summary>
        /// <param name="b">The b.</param>
        public static void TryConfigureDeletionTime(this EntityTypeBuilder b)
        {
            if (b.Metadata.ClrType.IsAssignableTo<IHasDeletionTime>())
            {
                b.TryConfigureSoftDelete();

                b.Property(nameof(IHasDeletionTime.DeletionTime))
                    .IsRequired(false)
                    .HasColumnName(nameof(IHasDeletionTime.DeletionTime));
            }
        }

        /// <summary>
        /// Configures the may have creator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b">The b.</param>
        public static void ConfigureMayHaveCreator<T>(this EntityTypeBuilder<T> b)
            where T : class, IMayHaveCreator
        {
            b.As<EntityTypeBuilder>().TryConfigureMayHaveCreator();
        }

        /// <summary>
        /// Tries the configure may have creator.
        /// </summary>
        /// <param name="b">The b.</param>
        public static void TryConfigureMayHaveCreator(this EntityTypeBuilder b)
        {
            if (b.Metadata.ClrType.IsAssignableTo<IMayHaveCreator>())
            {
                b.Property(nameof(IMayHaveCreator.CreatorId))
                    .IsRequired(false)
                    .HasColumnName(nameof(IMayHaveCreator.CreatorId));
            }
        }

        /// <summary>
        /// Configures the must have creator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b">The b.</param>
        public static void ConfigureMustHaveCreator<T>(this EntityTypeBuilder<T> b)
            where T : class, IMustHaveCreator
        {
            b.As<EntityTypeBuilder>().TryConfigureMustHaveCreator();
        }

        /// <summary>
        /// Tries the configure must have creator.
        /// </summary>
        /// <param name="b">The b.</param>
        public static void TryConfigureMustHaveCreator(this EntityTypeBuilder b)
        {
            if (b.Metadata.ClrType.IsAssignableTo<IMustHaveCreator>())
            {
                b.Property(nameof(IMustHaveCreator.CreatorId))
                    .IsRequired()
                    .HasColumnName(nameof(IMustHaveCreator.CreatorId));
            }
        }

        /// <summary>
        /// Configures the deletion audited.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b">The b.</param>
        public static void ConfigureDeletionAudited<T>(this EntityTypeBuilder<T> b)
            where T : class, IDeletionAuditedObject
        {
            b.As<EntityTypeBuilder>().TryConfigureDeletionAudited();
        }

        /// <summary>
        /// Tries the configure deletion audited.
        /// </summary>
        /// <param name="b">The b.</param>
        public static void TryConfigureDeletionAudited(this EntityTypeBuilder b)
        {
            if (b.Metadata.ClrType.IsAssignableTo<IDeletionAuditedObject>())
            {
                b.TryConfigureDeletionTime();

                b.Property(nameof(IDeletionAuditedObject.DeleterId))
                    .IsRequired(false)
                    .HasColumnName(nameof(IDeletionAuditedObject.DeleterId));
            }
        }

        /// <summary>
        /// Configures the creation time.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b">The b.</param>
        public static void ConfigureCreationTime<T>(this EntityTypeBuilder<T> b)
            where T : class, IHasCreationTime
        {
            b.As<EntityTypeBuilder>().TryConfigureCreationTime();
        }

        /// <summary>
        /// Tries the configure creation time.
        /// </summary>
        /// <param name="b">The b.</param>
        public static void TryConfigureCreationTime(this EntityTypeBuilder b)
        {
            if (b.Metadata.ClrType.IsAssignableTo<IHasCreationTime>())
            {
                b.Property(nameof(IHasCreationTime.CreationTime))
                    .IsRequired()
                    .HasColumnName(nameof(IHasCreationTime.CreationTime));
            }
        }

        /// <summary>
        /// Configures the creation audited.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b">The b.</param>
        public static void ConfigureCreationAudited<T>(this EntityTypeBuilder<T> b)
            where T : class, ICreationAuditedObject
        {
            b.As<EntityTypeBuilder>().TryConfigureCreationAudited();
        }

        /// <summary>
        /// Tries the configure creation audited.
        /// </summary>
        /// <param name="b">The b.</param>
        public static void TryConfigureCreationAudited(this EntityTypeBuilder b)
        {
            if (b.Metadata.ClrType.IsAssignableTo<ICreationAuditedObject>())
            {
                b.As<EntityTypeBuilder>().TryConfigureCreationTime();
                b.As<EntityTypeBuilder>().TryConfigureMayHaveCreator();
            }
        }

        /// <summary>
        /// Configures the last modification time.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b">The b.</param>
        public static void ConfigureLastModificationTime<T>(this EntityTypeBuilder<T> b)
            where T : class, IHasModificationTime
        {
            b.As<EntityTypeBuilder>().TryConfigureLastModificationTime();
        }

        /// <summary>
        /// Tries the configure last modification time.
        /// </summary>
        /// <param name="b">The b.</param>
        public static void TryConfigureLastModificationTime(this EntityTypeBuilder b)
        {
            if (b.Metadata.ClrType.IsAssignableTo<IHasModificationTime>())
            {
                b.Property(nameof(IHasModificationTime.LastModificationTime))
                    .IsRequired(false)
                    .HasColumnName(nameof(IHasModificationTime.LastModificationTime));
            }
        }

        /// <summary>
        /// Configures the modification audited.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b">The b.</param>
        public static void ConfigureModificationAudited<T>(this EntityTypeBuilder<T> b)
            where T : class, IModificationAuditedObject
        {
            b.As<EntityTypeBuilder>().TryConfigureModificationAudited();
        }

        /// <summary>
        /// Tries the configure modification audited.
        /// </summary>
        /// <param name="b">The b.</param>
        public static void TryConfigureModificationAudited(this EntityTypeBuilder b)
        {
            if (b.Metadata.ClrType.IsAssignableTo<IModificationAuditedObject>())
            {
                b.TryConfigureLastModificationTime();

                b.Property(nameof(IModificationAuditedObject.LastModifierId))
                    .IsRequired(false)
                    .HasColumnName(nameof(IModificationAuditedObject.LastModifierId));
            }
        }

        /// <summary>
        /// Configures the audited.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b">The b.</param>
        public static void ConfigureAudited<T>(this EntityTypeBuilder<T> b)
            where T : class, IAuditedObject
        {
            b.As<EntityTypeBuilder>().TryConfigureAudited();
        }

        /// <summary>
        /// Tries the configure audited.
        /// </summary>
        /// <param name="b">The b.</param>
        public static void TryConfigureAudited(this EntityTypeBuilder b)
        {
            if (b.Metadata.ClrType.IsAssignableTo<IAuditedObject>())
            {
                b.As<EntityTypeBuilder>().TryConfigureCreationAudited();
                b.As<EntityTypeBuilder>().TryConfigureModificationAudited();
            }
        }

        /// <summary>
        /// Configures the full audited.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b">The b.</param>
        public static void ConfigureFullAudited<T>(this EntityTypeBuilder<T> b)
            where T : class, IFullAuditedObject
        {
            b.As<EntityTypeBuilder>().TryConfigureFullAudited();
        }

        /// <summary>
        /// Tries the configure full audited.
        /// </summary>
        /// <param name="b">The b.</param>
        public static void TryConfigureFullAudited(this EntityTypeBuilder b)
        {
            if (b.Metadata.ClrType.IsAssignableTo<IFullAuditedObject>())
            {
                b.As<EntityTypeBuilder>().TryConfigureAudited();
                b.As<EntityTypeBuilder>().TryConfigureDeletionAudited();
            }
        }

        /// <summary>
        /// Configures the creation audited aggregate root.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b">The b.</param>
        public static void ConfigureCreationAuditedAggregateRoot<T>(this EntityTypeBuilder<T> b)
            where T : class
        {
            b.As<EntityTypeBuilder>().TryConfigureCreationAudited();
            b.As<EntityTypeBuilder>().TryConfigureExtraProperties();
            b.As<EntityTypeBuilder>().TryConfigureConcurrencyStamp();
        }

        /// <summary>
        /// Configures the audited aggregate root.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b">The b.</param>
        public static void ConfigureAuditedAggregateRoot<T>(this EntityTypeBuilder<T> b)
            where T : class
        {
            b.As<EntityTypeBuilder>().TryConfigureAudited();
            b.As<EntityTypeBuilder>().TryConfigureExtraProperties();
            b.As<EntityTypeBuilder>().TryConfigureConcurrencyStamp();
        }

        /// <summary>
        /// Configures the full audited aggregate root.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="b">The b.</param>
        public static void ConfigureFullAuditedAggregateRoot<T>(this EntityTypeBuilder<T> b)
            where T : class
        {
            b.As<EntityTypeBuilder>().TryConfigureFullAudited();
            b.As<EntityTypeBuilder>().TryConfigureExtraProperties();
            b.As<EntityTypeBuilder>().TryConfigureConcurrencyStamp();
        }

        //TODO: Add other interfaces (IAuditedObject<TUser>...)
    }
}
