using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noob.D2CMSApi.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 用户和角色关联表
    /// </summary>
    [Serializable]
    public class SysUserRoleMapping: IEntityTypeConfiguration<SysUserRole>
    {
        /// <summary>
        /// 用户和角色关联表
        /// </summary>
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
