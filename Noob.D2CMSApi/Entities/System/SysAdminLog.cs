using System;
using System.Web;
using System.Data;
using Noob.Domain.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 后台用户日志
    /// </summary>
    [Serializable]
    public class SysAdminLog:Entity<long>
    {
        /// <summary>
        /// 
        /// </summary>
    	public SysAdminLog(long id) : base(id) {}
        
    	/// <summary>
        /// 
        /// </summary>
    	public virtual string Route { get;set;}
    	/// <summary>
        /// 
        /// </summary>
    	public virtual string Method { get;set;}
    	/// <summary>
        /// 
        /// </summary>
    	public virtual string Description { get;set;}
    	/// <summary>
        /// 
        /// </summary>
    	public virtual int UserId { get;set;}
    	/// <summary>
        /// 
        /// </summary>
    	public virtual string Ip { get;set;}
    	/// <summary>
        /// 
        /// </summary>
    	public virtual int CreatedAt { get;set;}
    	/// <summary>
        /// 
        /// </summary>
    	public virtual int UpdatedAt { get;set;}
    	/// <summary>
        /// 
        /// </summary>
    	public virtual byte[] DeletedAt { get;set;}
        
         
       
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
