// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-06
// ***********************************************************************
// <copyright file="SysUserMapping.cs" company="Noob.D2CMSApi">
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
    /// 用户信息
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysUser}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysUser}" />
    [Serializable]
    public class SysUserMapping : IEntityTypeConfiguration<SysUser>
    {
        /// <summary>
        /// 用户信息表
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(EntityTypeBuilder<SysUser> builder)
        {
            builder.ToTable("sys_user");
            builder.HasKey(t => t.Id);
            //builder.Property(e => e.Id).ValueGeneratedOnAdd();
            //builder.Property(e => e.Id).UseIdentityColumn();
            //builder.Property(t => t.Id).UseHiLo();
            builder.Property(t => t.Id).HasColumnName("id");
            builder.Property(t => t.UserName).HasColumnName("user_name").IsRequired().HasMaxLength(30);
            builder.Property(t => t.Nickname).HasColumnName("nickname").IsRequired().HasMaxLength(30);
            builder.Property(t => t.UserType).HasColumnName("user_type");
            builder.Property(t => t.Email).HasColumnName("email").HasMaxLength(50);
            builder.Property(t => t.Phone).HasColumnName("phone").HasMaxLength(12);
            builder.Property(t => t.Phonenumber).HasColumnName("phonenumber").HasMaxLength(11);
            builder.Property(t => t.Sex).HasColumnName("sex");
            builder.Property(t => t.Avatar).HasColumnName("avatar").HasMaxLength(100);
            builder.Property(t => t.Password).HasColumnName("password").HasMaxLength(50);
            builder.Property(t => t.Salt).HasColumnName("salt").HasMaxLength(20);
            builder.Property(t => t.Status).HasColumnName("status");
            builder.Property(t => t.DelFlag).HasColumnName("del_flag");
            builder.Property(t => t.LoginIp).HasColumnName("login_ip").HasMaxLength(50);
            builder.Property(t => t.LoginDate).HasColumnName("login_date");
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasMaxLength(64);
            builder.Property(t => t.CreatedAt).HasColumnName("created_at");
            builder.Property(t => t.UpdateBy).HasColumnName("update_by").HasMaxLength(64);
            builder.Property(t => t.UpdatedAt).HasColumnName("updated_at");
            builder.Property(t => t.DeletedAt).HasColumnName("deleted_at");
            builder.Property(t => t.Remark).HasColumnName("remark").HasMaxLength(500);

            builder.Ignore(t => t.UserPost);
            builder.Ignore(t => t.UserRole);

            //builder.HasOne(a => a.UserPost).WithOne(b => b.User).HasForeignKey<SysUserPost>(c => c.UserId);

            //builder.HasOne(a => a.UserRole).WithOne(b => b.User).HasForeignKey<SysUserRole>(c => c.UserId);

            //builder.HasOne<SysUser>().WithOne().HasForeignKey<SysUserRole>(r => r.UserId);
            //针对“一对一”关系的设置
            //HasRequired(t => t.AdmRights).WithMany().HasForeignKey(t => t.RightsID);
        }
    }
}
