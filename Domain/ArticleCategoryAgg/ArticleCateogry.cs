using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.BaseDomainAgg;

namespace Domain.ArticleCategoryAgg
{
    public class ArticleCateogry:DomainBase
    {
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }

        public ArticleCateogry(string title)
        {
            Title = title;
            IsDeleted = false;
        }

        public void DeleteArticleCategory()
        {
            IsDeleted = true;
        }
    }
}
