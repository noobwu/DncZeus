// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysUserRoleMapping.cs" company="Noob.D2CMSApi">
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
    /// 用户和角色关联表
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysUserRole}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysUserRole}" />
    [Serializable]
    public class SysUserRoleMapping: IEntityTypeConfiguration<SysUserRole>
    {
        /// <summary>
        /// 用户和角色关联表
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(EntityTypeBuilder<SysUserRole> builder)
        {
           builder.ToTable("sys_user_role");
    	   builder.HasKey(t => t.Id);
    	   builder.Property(t => t.Id).HasColumnName("id");;
       	   builder.Property(t => t.UserId).HasColumnName("user_id").IsRequired();
       	   builder.Property(t => t.RoleId).HasColumnName("role_id").IsRequired();
        }
    }	    
}
