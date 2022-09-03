using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ArticleCategoryAgg;
using DomainServices.ArticleCategory;
using Infrastructure.EFCORE.Base;
using Infrastructure.EFCORE.ContextDB;

namespace Infrastructure.EFCORE.ArticleCategory
{
    public class ArticleCategoryRepository:BaseRepository<ArticleCateogry>,IArticleCategoryRepository
    {
        public ArticleCategoryRepository(MasterContext context) : base(context)
        {
        }
    }
}
