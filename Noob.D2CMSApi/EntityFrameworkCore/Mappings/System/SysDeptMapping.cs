// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysDeptMapping.cs" company="Noob.D2CMSApi">
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
    /// 部门表
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysDept}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysDept}" />
    [Serializable]
    public class SysDeptMapping : IEntityTypeConfiguration<SysDept>
    {
        /// <summary>
        /// 部门表
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(EntityTypeBuilder<SysDept> builder)
        {
            builder.ToTable("sys_dept");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id"); ;
            builder.Property(t => t.ParentId).HasColumnName("parent_id");
            builder.Property(t => t.Ancestors).HasColumnName("ancestors").HasMaxLength(50);
            builder.Property(t => t.DeptName).HasColumnName("dept_name").HasMaxLength(30);
            builder.Property(t => t.OrderNum).HasColumnName("order_num");
            builder.Property(t => t.Leader).HasColumnName("leader").HasMaxLength(20);
            builder.Property(t => t.Phone).HasColumnName("phone").HasMaxLength(11);
            builder.Property(t => t.Email).HasColumnName("email").HasMaxLength(50);
            builder.Property(t => t.Status).HasColumnName("status").HasMaxLength(1);
            builder.Property(t => t.DelFlag).HasColumnName("del_flag").HasMaxLength(1);
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasMaxLength(64);
            builder.Property(t => t.CreatedAt).HasColumnName("created_at");
            builder.Property(t => t.UpdateBy).HasColumnName("update_by").HasMaxLength(64);
            builder.Property(t => t.UpdatedAt).HasColumnName("updated_at");
            builder.Property(t => t.Remark).HasColumnName("remark").HasMaxLength(500);
        }
    }
}
