using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noob.D2CMSApi.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 角色和部门关联表
    /// </summary>
    [Serializable]
    public class SysRoleDeptMapping: IEntityTypeConfiguration<SysRoleDept>
    {
        /// <summary>
        /// 角色和部门关联表
        /// </summary>
        public void Configure(EntityTypeBuilder<SysRoleDept> builder)
        {
           builder.ToTable("sys_role_dept");
    	   builder.HasKey(t => t.Id);
    	   builder.Property(t => t.Id).HasColumnName("id");;
       	   builder.Property(t => t.RoleId).HasColumnName("role_id").IsRequired();
       	   builder.Property(t => t.DeptId).HasColumnName("dept_id").IsRequired();
        }
    }	    
}
