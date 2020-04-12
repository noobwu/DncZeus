// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysRoleMenuMapping.cs" company="Noob.D2CMSApi">
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
    /// 角色和菜单关联表
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysRoleMenu}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysRoleMenu}" />
    [Serializable]
    public class SysRoleMenuMapping: IEntityTypeConfiguration<SysRoleMenu>
    {
        /// <summary>
        /// 角色和菜单关联表
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(EntityTypeBuilder<SysRoleMenu> builder)
        {
           builder.ToTable("sys_role_menu");
    	   builder.HasKey(t => t.Id);
    	   builder.Property(t => t.Id).HasColumnName("id");;
       	   builder.Property(t => t.RoleId).HasColumnName("role_id").IsRequired();
       	   builder.Property(t => t.MenuId).HasColumnName("menu_id").IsRequired();
        }
    }	    
}
