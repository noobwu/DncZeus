using System;
using System.Web;
using System.Data;
using Noob.Domain.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 岗位信息表
    /// </summary>
    [Serializable]
    public class SysPost:Entity<int>
    {
        /// <summary>
        /// 岗位ID
        /// </summary>
    	public SysPost(int id) : base(id) {}
        
    	/// <summary>
        /// 岗位编码
        /// </summary>
    	public virtual string PostCode { get;set;}
    	/// <summary>
        /// 岗位名称
        /// </summary>
    	public virtual string PostName { get;set;}
    	/// <summary>
        /// 显示顺序
        /// </summary>
    	public virtual int PostSort { get;set;}
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
