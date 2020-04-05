using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noob.D2CMSApi.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 角色信息表
    /// </summary>
    [Serializable]
    public class SysRoleMapping: IEntityTypeConfiguration<SysRole>
    {
        /// <summary>
        /// 角色信息表
        /// </summary>
        public void Configure(EntityTypeBuilder<SysRole> builder)
        {
           builder.ToTable("sys_role");
    	   builder.HasKey(t => t.Id);
    	   builder.Property(t => t.Id).HasColumnName("id");;
       	   builder.Property(t => t.RoleName).HasColumnName("role_name").IsRequired().HasMaxLength(30);
       	   builder.Property(t => t.RoleKey).HasColumnName("role_key").IsRequired().HasMaxLength(100);
       	   builder.Property(t => t.RoleSort).HasColumnName("role_sort").IsRequired();
       	   builder.Property(t => t.DataScope).HasColumnName("data_scope").HasMaxLength(1);
       	   builder.Property(t => t.Status).HasColumnName("status").IsRequired().HasMaxLength(1);
       	   builder.Property(t => t.DelFlag).HasColumnName("del_flag").HasMaxLength(1);
       	   builder.Property(t => t.CreateBy).HasColumnName("create_by").HasMaxLength(64);
       	   builder.Property(t => t.CreatedAt).HasColumnName("created_at");
       	   builder.Property(t => t.UpdateBy).HasColumnName("update_by").HasMaxLength(64);
       	   builder.Property(t => t.UpdatedAt).HasColumnName("updated_at");
       	   builder.Property(t => t.Remark).HasColumnName("remark").HasMaxLength(500);
        }
    }	    
}
