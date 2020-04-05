using System;
using System.Web;
using System.Data;
using Noob.Domain.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 字典数据表
    /// </summary>
    [Serializable]
    public class SysDictData:Entity<int>
    {
        /// <summary>
        /// 
        /// </summary>
    	public SysDictData(int id) : base(id) {}
        
    	/// <summary>
        /// ID
        /// </summary>
    	public virtual int DictCode { get;set;}
    	/// <summary>
        /// 字典排序
        /// </summary>
    	public virtual int? DictSort { get;set;}
    	/// <summary>
        /// 字典标签
        /// </summary>
    	public virtual string DictLabel { get;set;}
    	/// <summary>
        /// 字典键值
        /// </summary>
    	public virtual string DictValue { get;set;}
    	/// <summary>
        /// 字典类型
        /// </summary>
    	public virtual string DictType { get;set;}
    	/// <summary>
        /// 样式属性（其他样式扩展）
        /// </summary>
    	public virtual string CssClass { get;set;}
    	/// <summary>
        /// 表格回显样式
        /// </summary>
    	public virtual string ListClass { get;set;}
    	/// <summary>
        /// 是否默认（Y是 N否）
        /// </summary>
    	public virtual string IsDefault { get;set;}
    	/// <summary>
        /// 状态（0正常 1停用）
        /// </summary>
    	public virtual string Status { get;set;}
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
