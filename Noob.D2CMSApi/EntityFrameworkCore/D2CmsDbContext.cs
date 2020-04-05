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
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.</remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var sysUserEntity = modelBuilder.Entity<SysUser>();
            sysUserEntity.ToTable("sys_user");
            sysUserEntity.HasKey(t => t.Id);
            sysUserEntity.Property(t => t.Id).HasColumnName("id"); ;
            sysUserEntity.Property(t => t.LoginName).HasColumnName("login_name").IsRequired().HasMaxLength(30);
            sysUserEntity.Property(t => t.UserName).HasColumnName("user_name").IsRequired().HasMaxLength(30);
            sysUserEntity.Property(t => t.UserType).HasColumnName("user_type");
            sysUserEntity.Property(t => t.Email).HasColumnName("email").HasMaxLength(50);
            sysUserEntity.Property(t => t.Phone).HasColumnName("phone").HasMaxLength(12);
            sysUserEntity.Property(t => t.Phonenumber).HasColumnName("phonenumber").HasMaxLength(11);
            sysUserEntity.Property(t => t.Sex).HasColumnName("sex");
            sysUserEntity.Property(t => t.Avatar).HasColumnName("avatar").HasMaxLength(100);
            sysUserEntity.Property(t => t.Password).HasColumnName("password").HasMaxLength(50);
            sysUserEntity.Property(t => t.Salt).HasColumnName("salt").HasMaxLength(20);
            sysUserEntity.Property(t => t.Status).HasColumnName("status");
            sysUserEntity.Property(t => t.DelFlag).HasColumnName("del_flag");
            sysUserEntity.Property(t => t.LoginIp).HasColumnName("login_ip").HasMaxLength(50);
            sysUserEntity.Property(t => t.LoginDate).HasColumnName("login_date");
            sysUserEntity.Property(t => t.CreateBy).HasColumnName("create_by").HasMaxLength(64);
            sysUserEntity.Property(t => t.CreatedAt).HasColumnName("created_at");
            sysUserEntity.Property(t => t.UpdateBy).HasColumnName("update_by").HasMaxLength(64);
            sysUserEntity.Property(t => t.UpdatedAt).HasColumnName("updated_at");
            sysUserEntity.Property(t => t.DeletedAt).HasColumnName("deleted_at");
            sysUserEntity.Property(t => t.Remark).HasColumnName("remark").HasMaxLength(500);
            base.OnModelCreating(modelBuilder);
        }
        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<SysUser> SysUser { get; set; }
    }
}
