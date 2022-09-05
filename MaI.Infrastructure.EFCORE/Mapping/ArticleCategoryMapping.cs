using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EFCORE.Mapping
{
    public class ArticleCategoryMapping:IEntityTypeConfiguration<Domain.ArticleCategoryAgg.ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<Domain.ArticleCategoryAgg.ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.Property(x=>x.Id).IsRequired();
            builder.Property(x => x.Title);
            builder.Property(x => x.CreationDate);
            builder.Property(x => x.IsDeleted);
            builder.HasMany(x => x.Articles).WithOne(x => x.ArticleCategory).HasForeignKey(x => x.ArticleCategoryId);
        }
    }
}
