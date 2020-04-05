using System;
using System.Web;
using System.Data;
using Noob.Domain.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 菜单权限表
    /// </summary>
    [Serializable]
    public class SysMenu:Entity<int>
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
    	public SysMenu(int id) : base(id) {}
        
    	/// <summary>
        /// 菜单名称
        /// </summary>
    	public virtual string MenuName { get;set;}
    	/// <summary>
        /// 父菜单ID
        /// </summary>
    	public virtual int? ParentId { get;set;}
    	/// <summary>
        /// 显示顺序
        /// </summary>
    	public virtual int? OrderNum { get;set;}
    	/// <summary>
        /// 请求地址
        /// </summary>
    	public virtual string Url { get;set;}
    	/// <summary>
        /// 菜单类型（1,目录 2,菜单 3,按钮）
        /// </summary>
    	public virtual byte? MenuType { get;set;}
    	/// <summary>
        /// 菜单状态（0显示 1隐藏）
        /// </summary>
    	public virtual string Visible { get;set;}
    	/// <summary>
        /// 权限标识
        /// </summary>
    	public virtual string Perms { get;set;}
    	/// <summary>
        /// 菜单图标
        /// </summary>
    	public virtual string Icon { get;set;}
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
