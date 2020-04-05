using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noob.D2CMSApi.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 角色和菜单关联表
    /// </summary>
    [Serializable]
    public class SysRoleMenuMapping: IEntityTypeConfiguration<SysRoleMenu>
    {
        /// <summary>
        /// 角色和菜单关联表
        /// </summary>
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
