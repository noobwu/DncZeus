// ***********************************************************************
// Assembly         : Noob.D2CMSApi
// Author           : Administrator
// Created          : 2020-04-05
//
// Last Modified By : Administrator
// Last Modified On : 2020-04-05
// ***********************************************************************
// <copyright file="SysArticle.cs" company="Noob.D2CMSApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web;
using System.Data;
using Noob.Domain.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 文章表
    /// Implements the <see cref="Noob.Domain.Entities.Entity" />
    /// </summary>
    /// <seealso cref="Noob.Domain.Entities.Entity" />
    [Serializable]
    public class SysArticle:Entity<long>
    {
        /// <summary>
        /// ID
        /// </summary>
        /// <param name="id">The identifier.</param>
    	public SysArticle(long id) : base(id) {}

        /// <summary>
        /// 栏目id
        /// </summary>
        /// <value>The category identifier.</value>
        public virtual int CategoryId { get;set;}
        /// <summary>
        /// post标题
        /// </summary>
        /// <value>The post title.</value>
        public virtual string PostTitle { get;set;}
        /// <summary>
        /// 发表者用户id
        /// </summary>
        /// <value>The author.</value>
        public virtual string Author { get;set;}
        /// <summary>
        /// 状态;1:已发布;0:未发布;
        /// </summary>
        /// <value>The post status.</value>
        public virtual byte PostStatus { get;set;}
        /// <summary>
        /// 评论状态;1:允许;0:不允许
        /// </summary>
        /// <value>The comment status.</value>
        public virtual byte CommentStatus { get;set;}
        /// <summary>
        /// 1热门，2首页，3推荐
        /// </summary>
        /// <value>The flag.</value>
        public virtual byte Flag { get;set;}
        /// <summary>
        /// 查看数
        /// </summary>
        /// <value>The post hits.</value>
        public virtual long PostHits { get;set;}
        /// <summary>
        /// 收藏数
        /// </summary>
        /// <value>The post favorites.</value>
        public virtual int PostFavorites { get;set;}
        /// <summary>
        /// 点赞数
        /// </summary>
        /// <value>The post like.</value>
        public virtual long PostLike { get;set;}
        /// <summary>
        /// 评论数
        /// </summary>
        /// <value>The comment count.</value>
        public virtual long CommentCount { get;set;}
        /// <summary>
        /// seo keywords
        /// </summary>
        /// <value>The post keywords.</value>
        public virtual string PostKeywords { get;set;}
        /// <summary>
        /// post摘要
        /// </summary>
        /// <value>The post excerpt.</value>
        public virtual string PostExcerpt { get;set;}
        /// <summary>
        /// 转载文章的来源
        /// </summary>
        /// <value>The post source.</value>
        public virtual string PostSource { get;set;}
        /// <summary>
        /// 缩略图
        /// </summary>
        /// <value>The image.</value>
        public virtual string Image { get;set;}
        /// <summary>
        /// 文章内容
        /// </summary>
        /// <value>The content of the post.</value>
        public virtual string PostContent { get;set;}
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value>The created at.</value>
        public virtual int CreatedAt { get;set;}
        /// <summary>
        /// 更新时间
        /// </summary>
        /// <value>The updated at.</value>
        public virtual int UpdatedAt { get;set;}



        /// <summary>
        /// 获取主键的属性名称
        /// </summary>
        /// <returns>System.String.</returns>
        public virtual string GetPKPropertyName()
        {
            return "Id";
        }
	  
    }	
   
}
