using System;
using System.Web;
using System.Data;
using Noob.Domain.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 部门表
    /// </summary>
    [Serializable]
    public class SysDept:Entity<int>
    {
        /// <summary>
        /// 部门id
        /// </summary>
    	public SysDept(int id) : base(id) {}
        
    	/// <summary>
        /// 父部门id
        /// </summary>
    	public virtual int? ParentId { get;set;}
    	/// <summary>
        /// 祖级列表
        /// </summary>
    	public virtual string Ancestors { get;set;}
    	/// <summary>
        /// 部门名称
        /// </summary>
    	public virtual string DeptName { get;set;}
    	/// <summary>
        /// 显示顺序
        /// </summary>
    	public virtual int? OrderNum { get;set;}
    	/// <summary>
        /// 负责人
        /// </summary>
    	public virtual string Leader { get;set;}
    	/// <summary>
        /// 联系电话
        /// </summary>
    	public virtual string Phone { get;set;}
    	/// <summary>
        /// 邮箱
        /// </summary>
    	public virtual string Email { get;set;}
    	/// <summary>
        /// 部门状态（0正常 1停用）
        /// </summary>
    	public virtual string Status { get;set;}
    	/// <summary>
        /// 删除标志（0代表存在 2代表删除）
        /// </summary>
    	public virtual string DelFlag { get;set;}
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
