using System;
using System.Web;
using System.Data;
using Noob.Domain.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 地区信息
    /// </summary>
    [Serializable]
    public class SysArea:Entity<long>
    {
        /// <summary>
        /// 
        /// </summary>
    	public SysArea(long id) : base(id) {}
        
    	/// <summary>
        /// 
        /// </summary>
    	public virtual string Adcode { get;set;}
    	/// <summary>
        /// 
        /// </summary>
    	public virtual int Citycode { get;set;}
    	/// <summary>
        /// 
        /// </summary>
    	public virtual string Center { get;set;}
    	/// <summary>
        /// 
        /// </summary>
    	public virtual string Name { get;set;}
    	/// <summary>
        /// 
        /// </summary>
    	public virtual int ParentId { get;set;}
    	/// <summary>
        /// 
        /// </summary>
    	public virtual byte? IsEnd { get;set;}
        
         
       
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
