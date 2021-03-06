// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysCategoryMapping.cs" company="Noob.D2CMSApi">
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
    /// 分类表
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysCategory}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysCategory}" />
    [Serializable]
    public class SysCategoryMapping : IEntityTypeConfiguration<SysCategory>
    {
        /// <summary>
        /// 分类表
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(EntityTypeBuilder<SysCategory> builder)
        {
            builder.ToTable("sys_category");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id"); ;
            builder.Property(t => t.Pid).HasColumnName("pid").IsRequired();
            builder.Property(t => t.Type).HasColumnName("type").IsRequired();
            builder.Property(t => t.Name).HasColumnName("name").IsRequired().HasMaxLength(30);
            builder.Property(t => t.Nickname).HasColumnName("nickname").IsRequired().HasMaxLength(50);
            builder.Property(t => t.Flag).HasColumnName("flag").IsRequired();
            builder.Property(t => t.Href).HasColumnName("href").IsRequired().HasMaxLength(255);
            builder.Property(t => t.IsNav).HasColumnName("is_nav").IsRequired();
            builder.Property(t => t.Image).HasColumnName("image").IsRequired().HasMaxLength(100);
            builder.Property(t => t.Keywords).HasColumnName("keywords").IsRequired().HasMaxLength(255);
            builder.Property(t => t.Description).HasColumnName("description").IsRequired().HasMaxLength(255);
            builder.Property(t => t.Content).HasColumnName("content").IsRequired();
            builder.Property(t => t.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(t => t.UpdatedAt).HasColumnName("updated_at").IsRequired();
            builder.Property(t => t.DeletedAt).HasColumnName("deleted_at").IsRequired();
            builder.Property(t => t.Weigh).HasColumnName("weigh").IsRequired();
            builder.Property(t => t.Status).HasColumnName("status").IsRequired();
            builder.Property(t => t.Tpl).HasColumnName("tpl").IsRequired().HasMaxLength(255);
        }
    }
}
