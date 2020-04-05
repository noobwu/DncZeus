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
        public D2CmsDbContext() : base(Assembly.GetExecutingAssembly())
        {
            
        }
        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<SysUser> SysUser { get; set; }
    }
}
