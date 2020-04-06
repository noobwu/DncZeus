using System;
using System.Web;
using System.Data;
using Noob.Domain.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 用户和角色关联表
    /// </summary>
    [Serializable]
    public class SysUserRole:Entity<int>
    {
        /// <summary>
        /// 
        /// </summary>
    	public SysUserRole(int id) : base(id) {}
        
    	/// <summary>
        /// 用户ID
        /// </summary>
    	public virtual int UserId { get;set;}
    	/// <summary>
        /// 角色ID
        /// </summary>
    	public virtual int RoleId { get;set;}
        
         
       
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
