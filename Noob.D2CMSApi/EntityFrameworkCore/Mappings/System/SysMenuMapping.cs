using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noob.D2CMSApi.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 菜单权限表
    /// </summary>
    [Serializable]
    public class SysMenuMapping : IEntityTypeConfiguration<SysMenu>
    {
        /// <summary>
        /// 菜单权限表
        /// </summary>
        public void Configure(EntityTypeBuilder<SysMenu> builder)
        {
            builder.ToTable("sys_menu");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id"); ;
            builder.Property(t => t.MenuName).HasColumnName("menu_name").IsRequired().HasMaxLength(50);
            builder.Property(t => t.ParentId).HasColumnName("parent_id");
            builder.Property(t => t.OrderNum).HasColumnName("order_num");
            builder.Property(t => t.Url).HasColumnName("url").HasMaxLength(200);
            builder.Property(t => t.MenuType).HasColumnName("menu_type");
            builder.Property(t => t.Visible).HasColumnName("visible").HasMaxLength(1);
            builder.Property(t => t.Perms).HasColumnName("perms").HasMaxLength(100);
            builder.Property(t => t.Icon).HasColumnName("icon").HasMaxLength(100);
            builder.Property(t => t.CreateBy).HasColumnName("create_by").HasMaxLength(64);
            builder.Property(t => t.CreatedAt).HasColumnName("created_at");
            builder.Property(t => t.UpdateBy).HasColumnName("update_by").HasMaxLength(64);
            builder.Property(t => t.UpdatedAt).HasColumnName("updated_at");
            builder.Property(t => t.Remark).HasColumnName("remark").HasMaxLength(500);
        }
    }
}
