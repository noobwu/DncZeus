// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-19
// ***********************************************************************
// <copyright file="D2CmsDbContext.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using Noob.D2CMSApi.Entities;
using Noob.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.EntityFrameworkCore
{
    /// <summary>
    /// Class D2CmsDbContext.
    /// Implements the <see cref="Noob.EntityFrameworkCore.EfCoreDbContext{Noob.D2CMSApi.EntityFrameworkCore.D2CmsDbContext}" />
    /// </summary>
    /// <seealso cref="Noob.EntityFrameworkCore.EfCoreDbContext{Noob.D2CMSApi.EntityFrameworkCore.D2CmsDbContext}" />
    public class D2CmsDbContext : EfCoreDbContext<D2CmsDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="D2CmsDbContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public D2CmsDbContext(DbContextOptions<D2CmsDbContext> options) : base(options, Assembly.GetExecutingAssembly())
        {
            
        }
        /// <summary>
        /// 用户
        /// </summary>
        /// <value>The system user.</value>
        public DbSet<SysUser> SysUser { get; set; }
        /// <summary>
        /// 菜单
        /// </summary>
        /// <value>The system menu.</value>
        public DbSet<SysMenu> SysMenu { get; set; }
        /// <summary>
        /// 部门管理
        /// </summary>
        /// <value>The system dept.</value>
        public DbSet<SysDept> SysDept { get; set; }
        /// <summary>
        /// 字典类型
        /// </summary>
        /// <value>The system dictionary data.</value>
        public DbSet<SysDictType> SysDictType { get; set; }
        /// <summary>
        /// 字典数据管理
        /// </summary>
        /// <value>The system dictionary data.</value>
        public DbSet<SysDictData> SysDictData { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        /// <value>The system role.</value>
        public DbSet<SysRole> SysRole { get; set; }

        /// <summary>
        /// 参数配置
        /// </summary>
        /// <value>The system configs.</value>
        public DbSet<SysConfigs> SysConfigs { get; set; }

        /// <summary>
        /// Gets or sets the system post.
        /// </summary>
        /// <value>The system post.</value>
        public DbSet<SysPost> SysPost { get; set; }

        /// <summary>
        /// Gets or sets the system user post.
        /// </summary>
        /// <value>The system user post.</value>
        public DbSet<SysUserPost> SysUserPost { get; set; }
        /// <summary>
        /// Gets or sets the system user role.
        /// </summary>
        /// <value>The system user role.</value>
        public DbSet<SysUserRole> SysUserRole { get; set; }
    }
}
