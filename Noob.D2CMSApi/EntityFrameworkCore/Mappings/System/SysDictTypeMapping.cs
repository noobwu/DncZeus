// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysDictTypeMapping.cs" company="Noob.D2CMSApi">
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
    /// 字典类型表
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysDictType}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysDictType}" />
    [Serializable]
    public class SysDictTypeMapping : IEntityTypeConfiguration<SysDictType>
    {
        /// <summary>
        /// 字典类型表
        /// </summary>
        public void Configure(EntityTypeBuilder<SysDictType> builder)
        {
            builder.ToTable("sys_dict_type");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id"); ;
            builder.Property(t => t.DictName).HasColumnName("dict_name").IsRequired().HasMaxLength(100);
            builder.Property(t => t.DictType).HasColumnName("dict_type").IsRequired().HasMaxLength(100);
            builder.Property(t => t.DictValueType).HasColumnName("dict_value_type").IsRequired();
            builder.Property(t => t.Status).HasColumnName("status").IsRequired();
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasMaxLength(64);
            builder.Property(t => t.CreatedAt).HasColumnName("created_at");
            builder.Property(t => t.UpdateBy).HasColumnName("update_by").HasMaxLength(64);
            builder.Property(t => t.UpdatedAt).HasColumnName("updated_at");
            builder.Property(t => t.Remark).HasColumnName("remark").HasMaxLength(500);
        }
    }
}
