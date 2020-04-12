// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysRoleDeptMapping.cs" company="Noob.D2CMSApi">
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
    /// 角色和部门关联表
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysRoleDept}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Noob.D2CMSApi.Entities.SysRoleDept}" />
    [Serializable]
    public class SysRoleDeptMapping: IEntityTypeConfiguration<SysRoleDept>
    {
        /// <summary>
        /// 角色和部门关联表
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(EntityTypeBuilder<SysRoleDept> builder)
        {
           builder.ToTable("sys_role_dept");
    	   builder.HasKey(t => t.Id);
    	   builder.Property(t => t.Id).HasColumnName("id");;
       	   builder.Property(t => t.RoleId).HasColumnName("role_id").IsRequired();
       	   builder.Property(t => t.DeptId).HasColumnName("dept_id").IsRequired();
        }
    }	    
}
