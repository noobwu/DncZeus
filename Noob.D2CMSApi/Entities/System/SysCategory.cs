using System;
using System.Web;
using System.Data;
using Noob.Domain.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 分类表
    /// </summary>
    [Serializable]
    public class SysCategory:Entity<int>
    {
        /// <summary>
        /// 
        /// </summary>
    	public SysCategory(int id) : base(id) {}
        
    	/// <summary>
        /// 父ID
        /// </summary>
    	public virtual int Pid { get;set;}
    	/// <summary>
        /// 栏目类型
        /// </summary>
    	public virtual byte Type { get;set;}
    	/// <summary>
        /// 栏目名称
        /// </summary>
    	public virtual string Name { get;set;}
    	/// <summary>
        /// 别名
        /// </summary>
    	public virtual string Nickname { get;set;}
    	/// <summary>
        /// 0,1火,2首页,3推荐
        /// </summary>
    	public virtual byte Flag { get;set;}
    	/// <summary>
        /// 外链
        /// </summary>
    	public virtual string Href { get;set;}
    	/// <summary>
        /// 是否是导航
        /// </summary>
    	public virtual byte IsNav { get;set;}
    	/// <summary>
        /// 图片
        /// </summary>
    	public virtual string Image { get;set;}
    	/// <summary>
        /// 关键字
        /// </summary>
    	public virtual string Keywords { get;set;}
    	/// <summary>
        /// 描述
        /// </summary>
    	public virtual string Description { get;set;}
    	/// <summary>
        /// 内容
        /// </summary>
    	public virtual string Content { get;set;}
    	/// <summary>
        /// 创建时间
        /// </summary>
    	public virtual int CreatedAt { get;set;}
    	/// <summary>
        /// 更新时间
        /// </summary>
    	public virtual int UpdatedAt { get;set;}
    	/// <summary>
        /// 删除时间
        /// </summary>
    	public virtual byte[] DeletedAt { get;set;}
    	/// <summary>
        /// 权重
        /// </summary>
    	public virtual int Weigh { get;set;}
    	/// <summary>
        /// 状态
        /// </summary>
    	public virtual byte Status { get;set;}
    	/// <summary>
        /// 模板文件
        /// </summary>
    	public virtual string Tpl { get;set;}
        
         
       
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
