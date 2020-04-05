using System;
using System.Web;
using System.Data;
using Noob.Domain.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 文章表
    /// </summary>
    [Serializable]
    public class SysArticle:Entity<long>
    {
        /// <summary>
        /// ID
        /// </summary>
    	public SysArticle(long id) : base(id) {}
        
    	/// <summary>
        /// 栏目id
        /// </summary>
    	public virtual int CategoryId { get;set;}
    	/// <summary>
        /// post标题
        /// </summary>
    	public virtual string PostTitle { get;set;}
    	/// <summary>
        /// 发表者用户id
        /// </summary>
    	public virtual string Author { get;set;}
    	/// <summary>
        /// 状态;1:已发布;0:未发布;
        /// </summary>
    	public virtual byte PostStatus { get;set;}
    	/// <summary>
        /// 评论状态;1:允许;0:不允许
        /// </summary>
    	public virtual byte CommentStatus { get;set;}
    	/// <summary>
        /// 1热门，2首页，3推荐
        /// </summary>
    	public virtual byte Flag { get;set;}
    	/// <summary>
        /// 查看数
        /// </summary>
    	public virtual long PostHits { get;set;}
    	/// <summary>
        /// 收藏数
        /// </summary>
    	public virtual int PostFavorites { get;set;}
    	/// <summary>
        /// 点赞数
        /// </summary>
    	public virtual long PostLike { get;set;}
    	/// <summary>
        /// 评论数
        /// </summary>
    	public virtual long CommentCount { get;set;}
    	/// <summary>
        /// seo keywords
        /// </summary>
    	public virtual string PostKeywords { get;set;}
    	/// <summary>
        /// post摘要
        /// </summary>
    	public virtual string PostExcerpt { get;set;}
    	/// <summary>
        /// 转载文章的来源
        /// </summary>
    	public virtual string PostSource { get;set;}
    	/// <summary>
        /// 缩略图
        /// </summary>
    	public virtual string Image { get;set;}
    	/// <summary>
        /// 文章内容
        /// </summary>
    	public virtual string PostContent { get;set;}
    	/// <summary>
        /// 创建时间
        /// </summary>
    	public virtual int CreatedAt { get;set;}
    	/// <summary>
        /// 更新时间
        /// </summary>
    	public virtual int UpdatedAt { get;set;}
        
         
       
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
