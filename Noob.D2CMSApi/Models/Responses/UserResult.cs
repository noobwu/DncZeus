using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models.Responses
{
    /// <summary>
    /// Class UserResult.
    /// Implements the <see cref="Noob.D2CMSApi.Models.Responses.ResultBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.Responses.ResultBase" />
    public class UserResult : ResultBase
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [JsonProperty("id")]
        public virtual int Id { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        [JsonProperty("login_name")]
        public virtual string LoginName { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        [JsonProperty("user_name")]
        public virtual string UserName { get; set; }
        /// <summary>
        /// 用户类型（1系统用户）
        /// </summary>
        [JsonProperty("user_type")]
        public virtual byte? UserType { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        [JsonProperty("email")]
        public virtual string Email { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [JsonProperty("phone")]
        public virtual string Phone { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [JsonProperty("phonenumber")]
        public virtual string Phonenumber { get; set; }
        /// <summary>
        /// 用户性别（1男 2女 3未知）
        /// </summary>
        [JsonProperty("sex")]
        public virtual byte? Sex { get; set; }
        /// <summary>
        /// 头像路径
        /// </summary>
        [JsonProperty("avatar")]
        public virtual string Avatar { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [JsonProperty("password")]
        public virtual string Password { get; set; }
        /// <summary>
        /// 盐加密
        /// </summary>
        [JsonProperty("salt")]
        public virtual string Salt { get; set; }
        /// <summary>
        /// 帐号状态（1正常 2禁用）
        /// </summary>
        [JsonProperty("status")]
        public virtual byte? Status { get; set; }
        /// <summary>
        /// 删除标志（1代表存在 2代表删除）
        /// </summary>
        [JsonProperty("del_flag")]
        public virtual byte? DelFlag { get; set; }
        /// <summary>
        /// 最后登陆IP
        /// </summary>
        [JsonProperty("login_ip")]
        public virtual string LoginIp { get; set; }
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        [JsonProperty("login_date")]
        public virtual string LoginDate { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [JsonProperty("create_by")]
        public virtual string CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("created_at")]
        public virtual string CreatedAt { get; set; }
        /// <summary>
        /// 更新者
        /// </summary>
        [JsonProperty("update_by")]
        public virtual string UpdateBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonProperty("updated_at")]
        public virtual string UpdatedAt { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        [JsonProperty("deleted_at")]
        public virtual string DeletedAt { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("remark")]
        public virtual string Remark { get; set; }
        /// <summary>
        /// Gets or sets the user post.
        /// </summary>
        /// <value>The user post.</value>
        [JsonProperty("user_post")]
        public virtual string UserPost { get; set; }
        /// <summary>
        /// Gets or sets the user role.
        /// </summary>
        /// <value>The user role.</value>
        [JsonProperty("user_role")]
        public virtual string UserRole { get; set; }
        /// <summary>
        /// Creates new password.
        /// </summary>
        /// <value>The new password.</value>
        [JsonProperty("new_password")]
        public virtual string NewPassword { get; set; }
    }
}
