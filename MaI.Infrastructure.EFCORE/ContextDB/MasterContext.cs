using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ArticleCategoryAgg;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCORE.ContextDB
{
    public class MasterContext:IdentityDbContext
    {
        public DbSet<ArticleCateogry> ArticleCateogries { get; set; }
        public DbSet<Domain.ArticleAgg.Article> Articles { get; set; }
        public MasterContext(DbContextOptions<MasterContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var assembly = typeof(ArticleCateogry).Assembly;
            builder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(builder);
        }
    }
}
