using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noob.D2CMSApi.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 字典类型表
    /// </summary>
    [Serializable]
    public class SysDictTypeMapping: IEntityTypeConfiguration<SysDictType>
    {
        /// <summary>
        /// 字典类型表
        /// </summary>
        public void Configure(EntityTypeBuilder<SysDictType> builder)
        {
           builder.ToTable("sys_dict_type");
    	   builder.HasKey(t => t.Id);
    	   builder.Property(t => t.Id).HasColumnName("id");;
       	   builder.Property(t => t.DictId).HasColumnName("dict_id").IsRequired();
       	   builder.Property(t => t.DictName).HasColumnName("dict_name").HasMaxLength(100);
       	   builder.Property(t => t.DictType).HasColumnName("dict_type").HasMaxLength(100);
       	   builder.Property(t => t.Status).HasColumnName("status").HasMaxLength(1);
       	   builder.Property(t => t.CreateBy).HasColumnName("create_by").HasMaxLength(64);
       	   builder.Property(t => t.CreatedAt).HasColumnName("created_at");
       	   builder.Property(t => t.UpdateBy).HasColumnName("update_by").HasMaxLength(64);
       	   builder.Property(t => t.UpdatedAt).HasColumnName("updated_at");
       	   builder.Property(t => t.Remark).HasColumnName("remark").HasMaxLength(500);
        }
    }	    
}
