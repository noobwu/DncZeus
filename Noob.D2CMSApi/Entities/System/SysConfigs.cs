using System;
using System.Web;
using System.Data;
using Noob.Domain.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 参数配置表
    /// </summary>
    [Serializable]
    public class SysConfigs:Entity<int>
    {
        /// <summary>
        /// 参数主键
        /// </summary>
    	public SysConfigs(int id) : base(id) {}
        
    	/// <summary>
        /// 参数名称
        /// </summary>
    	public virtual string ConfigName { get;set;}
    	/// <summary>
        /// 参数键名
        /// </summary>
    	public virtual string ConfigKey { get;set;}
    	/// <summary>
        /// 参数键值
        /// </summary>
    	public virtual string ConfigValue { get;set;}
    	/// <summary>
        /// 系统内置（1是 2否）
        /// </summary>
    	public virtual byte? ConfigType { get;set;}
    	/// <summary>
        /// 创建者
        /// </summary>
    	public virtual int? CreatedBy { get;set;}
    	/// <summary>
        /// 更新着
        /// </summary>
    	public virtual int? UpdatedBy { get;set;}
    	/// <summary>
        /// 创建时间
        /// </summary>
    	public virtual int? CreatedAt { get;set;}
    	/// <summary>
        /// 更新时间
        /// </summary>
    	public virtual int? UpdatedAt { get;set;}
    	/// <summary>
        /// 删除时间
        /// </summary>
    	public virtual DateTime? DeletedAt { get;set;}
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
