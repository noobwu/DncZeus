using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noob.D2CMSApi.Entities;
namespace Noob.D2CMSApi.Entities
{
    /// <summary>
    /// 文章表
    /// </summary>
    [Serializable]
    public class SysArticleMapping : IEntityTypeConfiguration<SysArticle>
    {
        /// <summary>
        /// 文章表
        /// </summary>
        public void Configure(EntityTypeBuilder<SysArticle> builder)
        {
            builder.ToTable("sys_article");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id"); ;
            builder.Property(t => t.CategoryId).HasColumnName("category_id").IsRequired();
            builder.Property(t => t.PostTitle).HasColumnName("post_title").IsRequired().HasMaxLength(100);
            builder.Property(t => t.Author).HasColumnName("author").IsRequired().HasMaxLength(255);
            builder.Property(t => t.PostStatus).HasColumnName("post_status").IsRequired();
            builder.Property(t => t.CommentStatus).HasColumnName("comment_status").IsRequired();
            builder.Property(t => t.Flag).HasColumnName("flag").IsRequired();
            builder.Property(t => t.PostHits).HasColumnName("post_hits").IsRequired();
            builder.Property(t => t.PostFavorites).HasColumnName("post_favorites").IsRequired();
            builder.Property(t => t.PostLike).HasColumnName("post_like").IsRequired();
            builder.Property(t => t.CommentCount).HasColumnName("comment_count").IsRequired();
            builder.Property(t => t.PostKeywords).HasColumnName("post_keywords").IsRequired().HasMaxLength(150);
            builder.Property(t => t.PostExcerpt).HasColumnName("post_excerpt").IsRequired().HasMaxLength(500);
            builder.Property(t => t.PostSource).HasColumnName("post_source").IsRequired().HasMaxLength(150);
            builder.Property(t => t.Image).HasColumnName("image").IsRequired().HasMaxLength(100);
            builder.Property(t => t.PostContent).HasColumnName("post_content");
            builder.Property(t => t.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(t => t.UpdatedAt).HasColumnName("updated_at").IsRequired();
        }
    }
}
