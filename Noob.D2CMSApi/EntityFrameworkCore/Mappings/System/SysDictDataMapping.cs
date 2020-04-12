// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysDictDataMapping.cs" company="Noob.D2CMSApi">
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
    /// 字典数据表
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysDictData}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysDictData}" />
    [Serializable]
    public class SysDictDataMapping : IEntityTypeConfiguration<SysDictData>
    {
        /// <summary>
        /// 字典数据表
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(EntityTypeBuilder<SysDictData> builder)
        {
            builder.ToTable("sys_dict_data");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id"); ;
            builder.Property(t => t.DictCode).HasColumnName("dict_code").IsRequired();
            builder.Property(t => t.DictSort).HasColumnName("dict_sort");
            builder.Property(t => t.DictLabel).HasColumnName("dict_label").HasMaxLength(100);
            builder.Property(t => t.DictValue).HasColumnName("dict_value").HasMaxLength(100);
            builder.Property(t => t.DictType).HasColumnName("dict_type").HasMaxLength(100);
            builder.Property(t => t.CssClass).HasColumnName("css_class").HasMaxLength(100);
            builder.Property(t => t.ListClass).HasColumnName("list_class").HasMaxLength(100);
            builder.Property(t => t.IsDefault).HasColumnName("is_default").HasMaxLength(1);
            builder.Property(t => t.Status).HasColumnName("status").HasMaxLength(1);
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasMaxLength(64);
            builder.Property(t => t.CreatedAt).HasColumnName("created_at");
            builder.Property(t => t.UpdateBy).HasColumnName("update_by").HasMaxLength(64);
            builder.Property(t => t.UpdatedAt).HasColumnName("updated_at");
            builder.Property(t => t.Remark).HasColumnName("remark").HasMaxLength(500);
        }
    }
}
