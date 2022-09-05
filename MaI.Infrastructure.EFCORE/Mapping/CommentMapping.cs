using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EFCORE.Mapping
{
    public class CommentMapping:IEntityTypeConfiguration<Domain.CommentAgg.Comment>
    {
        public void Configure(EntityTypeBuilder<Domain.CommentAgg.Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Article).WithMany(x => x.Comments).HasForeignKey(x => x.ArticleId);
        }
    }
}
