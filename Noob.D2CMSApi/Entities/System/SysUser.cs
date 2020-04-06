using System;
using System.Web;
using System.Data;
using Noob.Domain.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    [Serializable]
    public class SysUser:Entity<int>
    {
        /// <summary>
        /// 用户ID
        /// </summary>
    	public SysUser(int id) : base(id) {}
        
    	/// <summary>
        /// 登录账号
        /// </summary>
    	public virtual string LoginName { get;set;}
    	/// <summary>
        /// 用户昵称
        /// </summary>
    	public virtual string UserName { get;set;}
    	/// <summary>
        /// 用户类型（1系统用户）
        /// </summary>
    	public virtual byte? UserType { get;set;}
    	/// <summary>
        /// 用户邮箱
        /// </summary>
    	public virtual string Email { get;set;}
    	/// <summary>
        /// 手机号
        /// </summary>
    	public virtual string Phone { get;set;}
    	/// <summary>
        /// 手机号码
        /// </summary>
    	public virtual string Phonenumber { get;set;}
    	/// <summary>
        /// 用户性别（1男 2女 3未知）
        /// </summary>
    	public virtual byte? Sex { get;set;}
    	/// <summary>
        /// 头像路径
        /// </summary>
    	public virtual string Avatar { get;set;}
    	/// <summary>
        /// 密码
        /// </summary>
    	public virtual string Password { get;set;}
    	/// <summary>
        /// 盐加密
        /// </summary>
    	public virtual string Salt { get;set;}
    	/// <summary>
        /// 帐号状态（1正常 2禁用）
        /// </summary>
    	public virtual byte? Status { get;set;}
    	/// <summary>
        /// 删除标志（1代表存在 2代表删除）
        /// </summary>
    	public virtual byte? DelFlag { get;set;}
    	/// <summary>
        /// 最后登陆IP
        /// </summary>
    	public virtual string LoginIp { get;set;}
    	/// <summary>
        /// 最后登陆时间
        /// </summary>
    	public virtual int? LoginDate { get;set;}
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
