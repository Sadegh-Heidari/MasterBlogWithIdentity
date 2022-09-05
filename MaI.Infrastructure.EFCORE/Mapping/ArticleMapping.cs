using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EFCORE.Mapping
{
    public class ArticleMapping:IEntityTypeConfiguration<Domain.ArticleAgg.Article>
    {
        public void Configure(EntityTypeBuilder<Domain.ArticleAgg.Article> builder)
        {
            builder.ToTable("Article");
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Title);
            builder.Property(x => x.CreationDate);
            builder.Property(x => x.IsDeleted);
            builder.Property(x => x.Content);
            builder.Property(x => x.Image);
            builder.Property(x => x.ShortDescription);
            builder.Property(x => x.ArticleCategoryId).HasMaxLength(450);
            builder.HasOne(x => x.ArticleCategory).WithMany(x => x.Articles).HasForeignKey(x => x.ArticleCategoryId);
        }
    }
}
