using System;
using System.Web;
using System.Data;
using Noob.Domain.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 角色和菜单关联表
    /// </summary>
    [Serializable]
    public class SysRoleMenu:Entity<int>
    {
        /// <summary>
        /// 
        /// </summary>
    	public SysRoleMenu(int id) : base(id) {}
        
    	/// <summary>
        /// 角色ID
        /// </summary>
    	public virtual int RoleId { get;set;}
    	/// <summary>
        /// 菜单ID
        /// </summary>
    	public virtual int MenuId { get;set;}
        
         
       
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
