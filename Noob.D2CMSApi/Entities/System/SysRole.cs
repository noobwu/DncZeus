using System;
using System.Web;
using System.Data;
using Noob.Domain.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 角色信息表
    /// </summary>
    [Serializable]
    public class SysRole:Entity<int>
    {
        /// <summary>
        /// 角色ID
        /// </summary>
    	public SysRole(int id) : base(id) {}
        
    	/// <summary>
        /// 角色名称
        /// </summary>
    	public virtual string RoleName { get;set;}
    	/// <summary>
        /// 角色权限字符串
        /// </summary>
    	public virtual string RoleKey { get;set;}
    	/// <summary>
        /// 显示顺序
        /// </summary>
    	public virtual int RoleSort { get;set;}
    	/// <summary>
        /// 数据范围（1：全部数据权限 2：自定数据权限）
        /// </summary>
    	public virtual byte DataScope { get;set;}
    	/// <summary>
        /// 角色状态（0正常 1停用）
        /// </summary>
    	public virtual byte Status { get;set;}
    	/// <summary>
        /// 删除标志（0代表存在 2代表删除）
        /// </summary>
    	public virtual byte DelFlag { get;set;}
    	/// <summary>
        /// 创建者
        /// </summary>
    	public virtual string CreateBy { get;set;}
    	/// <summary>
        /// 创建时间
        /// </summary>
    	public virtual int? CreatedAt { get;set;}
    	/// <summary>
        /// 更新者
        /// </summary>
    	public virtual string UpdateBy { get;set;}
    	/// <summary>
        /// 更新时间
        /// </summary>
    	public virtual int? UpdatedAt { get;set;}
    	/// <summary>
        /// 备注
        /// </summary>
    	public virtual string Remark { get;set;}
        
         
       
        /// <summary>
        /// 获取主键的属性名称
        /// </summary>
        /// <returns></returns>
        public virtual string GetPKPropertyName()
        {
            return "Id";
        }
	  
    }	
   
}
