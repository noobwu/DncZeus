using System;
using System.Web;
using System.Data;
using Noob.Domain.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 角色和部门关联表
    /// </summary>
    [Serializable]
    public class SysRoleDept:Entity<int>
    {
        /// <summary>
        /// 
        /// </summary>
    	public SysRoleDept(int id) : base(id) {}
        
    	/// <summary>
        /// 角色ID
        /// </summary>
    	public virtual int RoleId { get;set;}
    	/// <summary>
        /// 部门ID
        /// </summary>
    	public virtual int DeptId { get;set;}
        
         
       
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
