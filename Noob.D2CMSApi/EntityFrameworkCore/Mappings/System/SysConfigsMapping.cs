using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noob.D2CMSApi.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 参数配置表
    /// </summary>
    [Serializable]
    public class SysConfigsMapping: IEntityTypeConfiguration<SysConfigs>
    {
        /// <summary>
        /// 参数配置表
        /// </summary>
        public void Configure(EntityTypeBuilder<SysConfigs> builder)
        {
           builder.ToTable("sys_configs");
    	   builder.HasKey(t => t.Id);
    	   builder.Property(t => t.Id).HasColumnName("id");;
       	   builder.Property(t => t.ConfigName).HasColumnName("config_name").HasMaxLength(100);
       	   builder.Property(t => t.ConfigKey).HasColumnName("config_key").HasMaxLength(100);
       	   builder.Property(t => t.ConfigValue).HasColumnName("config_value").HasMaxLength(100);
       	   builder.Property(t => t.ConfigType).HasColumnName("config_type");
       	   builder.Property(t => t.CreatedBy).HasColumnName("created_by");
       	   builder.Property(t => t.UpdatedBy).HasColumnName("updated_by");
       	   builder.Property(t => t.CreatedAt).HasColumnName("created_at");
       	   builder.Property(t => t.UpdatedAt).HasColumnName("updated_at");
       	   builder.Property(t => t.DeletedAt).HasColumnName("deleted_at");
       	   builder.Property(t => t.Remark).HasColumnName("remark").HasMaxLength(500);
        }
    }	    
}
