using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noob.D2CMSApi.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 岗位信息表
    /// </summary>
    [Serializable]
    public class SysPostMapping: IEntityTypeConfiguration<SysPost>
    {
        /// <summary>
        /// 岗位信息表
        /// </summary>
        public void Configure(EntityTypeBuilder<SysPost> builder)
        {
           builder.ToTable("sys_post");
    	   builder.HasKey(t => t.Id);
    	   builder.Property(t => t.Id).HasColumnName("id");;
       	   builder.Property(t => t.PostCode).HasColumnName("post_code").IsRequired().HasMaxLength(64);
       	   builder.Property(t => t.PostName).HasColumnName("post_name").IsRequired().HasMaxLength(50);
       	   builder.Property(t => t.PostSort).HasColumnName("post_sort").IsRequired();
       	   builder.Property(t => t.Status).HasColumnName("status").IsRequired().HasMaxLength(1);
       	   builder.Property(t => t.CreateBy).HasColumnName("create_by").HasMaxLength(64);
       	   builder.Property(t => t.CreatedAt).HasColumnName("created_at");
       	   builder.Property(t => t.UpdateBy).HasColumnName("update_by").HasMaxLength(64);
       	   builder.Property(t => t.UpdatedAt).HasColumnName("updated_at");
       	   builder.Property(t => t.Remark).HasColumnName("remark").HasMaxLength(500);
        }
    }	    
}
