using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noob.D2CMSApi.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 用户与岗位关联表
    /// </summary>
    [Serializable]
    public class SysUserPostMapping: IEntityTypeConfiguration<SysUserPost>
    {
        /// <summary>
        /// 用户与岗位关联表
        /// </summary>
        public void Configure(EntityTypeBuilder<SysUserPost> builder)
        {
           builder.ToTable("sys_user_post");
    	   builder.HasKey(t => t.Id);
    	   builder.Property(t => t.Id).HasColumnName("id");;
       	   builder.Property(t => t.UserId).HasColumnName("user_id").IsRequired();
       	   builder.Property(t => t.PostId).HasColumnName("post_id").IsRequired();
        }
    }	    
}
