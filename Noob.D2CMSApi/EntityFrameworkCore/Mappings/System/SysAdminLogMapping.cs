// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysAdminLogMapping.cs" company="Noob.D2CMSApi">
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
    /// 后台用户日志
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysAdminLog}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysAdminLog}" />
    [Serializable]
    public class SysAdminLogMapping : IEntityTypeConfiguration<SysAdminLog>
    {
        /// <summary>
        /// 后台用户日志
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(EntityTypeBuilder<SysAdminLog> builder)
        {
            builder.ToTable("sys_admin_log");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id"); ;
            builder.Property(t => t.Route).HasColumnName("route").IsRequired().HasMaxLength(255);
            builder.Property(t => t.Method).HasColumnName("method").IsRequired().HasMaxLength(255);
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.UserId).HasColumnName("user_id").IsRequired();
            builder.Property(t => t.Ip).HasColumnName("ip").IsRequired().HasMaxLength(20);
            builder.Property(t => t.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(t => t.UpdatedAt).HasColumnName("updated_at").IsRequired();
            builder.Property(t => t.DeletedAt).HasColumnName("deleted_at").IsRequired();
        }
    }
}
