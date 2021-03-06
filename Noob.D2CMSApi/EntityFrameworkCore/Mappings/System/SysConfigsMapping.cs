// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysConfigsMapping.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noob.D2CMSApi.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 参数配置表
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysConfigs}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysConfigs}" />
    [Serializable]
    public class SysConfigsMapping : IEntityTypeConfiguration<SysConfigs>
    {
        /// <summary>
        /// 参数配置表
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(EntityTypeBuilder<SysConfigs> builder)
        {
            builder.ToTable("sys_configs");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id"); ;
            builder.Property(t => t.ConfigName).HasColumnName("config_name").HasMaxLength(100);
            builder.Property(t => t.ConfigKey).HasColumnName("config_key").HasMaxLength(100);
            builder.Property(t => t.ConfigValue).HasColumnName("config_value").HasMaxLength(100);
            builder.Property(t => t.ConfigType).HasColumnName("config_type");
            builder.Property(t => t.CreatedBy).HasColumnName("created_by");
            builder.Property(t => t.UpdatedBy).HasColumnName("updated_by");
            builder.Property(t => t.CreatedAt).HasColumnName("created_at");
            builder.Property(t => t.UpdatedAt).HasColumnName("updated_at");
            builder.Property(t => t.DeletedAt).HasColumnName("deleted_at");
            builder.Property(t => t.Remark).HasColumnName("remark").HasMaxLength(500);
        }
    }
}
