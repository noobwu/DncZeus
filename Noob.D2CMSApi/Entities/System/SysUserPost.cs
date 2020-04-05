using System;
using System.Web;
using System.Data;
using Noob.Domain.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 用户与岗位关联表
    /// </summary>
    [Serializable]
    public class SysUserPost:Entity<int>
    {
        /// <summary>
        /// 
        /// </summary>
    	public SysUserPost(int id) : base(id) {}
        
    	/// <summary>
        /// 用户ID
        /// </summary>
    	public virtual int UserId { get;set;}
    	/// <summary>
        /// 岗位ID
        /// </summary>
    	public virtual int PostId { get;set;}
        
         
       
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
