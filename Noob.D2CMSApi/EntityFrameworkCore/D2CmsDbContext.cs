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
    /// Class EfCoreDbContext.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class D2CmsDbContext : EfCoreDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="D2CmsDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public D2CmsDbContext(DbContextOptions<D2CmsDbContext> options) : base(options, Assembly.GetExecutingAssembly())
        {
            
        }
        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<SysUser> SysUser { get; set; }
        /// <summary>
        /// 菜单
        /// </summary>
        public DbSet<SysMenu> SysMenu { get; set; }
        /// <summary>
        ///  部门管理
        /// </summary>
        public DbSet<SysDept> SysDept { get; set; }
        /// <summary>
        ///  字典数据管理
        /// </summary>
        public DbSet<SysDictData> SysDictData { get; set; }
    }
}
