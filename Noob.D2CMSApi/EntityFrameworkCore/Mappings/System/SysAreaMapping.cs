using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noob.D2CMSApi.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 地区信息
    /// </summary>
    [Serializable]
    public class SysAreaMapping : IEntityTypeConfiguration<SysArea>
    {
        /// <summary>
        /// 地区信息
        /// </summary>
        public void Configure(EntityTypeBuilder<SysArea> builder)
        {
            builder.ToTable("sys_area");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id"); ;
            builder.Property(t => t.Adcode).HasColumnName("adcode").HasMaxLength(20);
            builder.Property(t => t.Citycode).HasColumnName("citycode").IsRequired();
            builder.Property(t => t.Center).HasColumnName("center").HasMaxLength(500);
            builder.Property(t => t.Name).HasColumnName("name").HasMaxLength(100);
            builder.Property(t => t.ParentId).HasColumnName("parent_id").IsRequired();
            builder.Property(t => t.IsEnd).HasColumnName("is_end");
        }
    }
}
