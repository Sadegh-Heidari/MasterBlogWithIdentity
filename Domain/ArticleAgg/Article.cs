using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ArticleCategoryAgg;
using Domain.BaseDomainAgg;

namespace Domain.ArticleAgg
{
    public class Article:DomainBase
    {
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Image { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }

        public string ArticleCategoryID { get; private set; }
        public ArticleCateogry ArticleCateogry { get; private set; }

        public Article(string title, string shortDescription, string image, string content)
        {
            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            IsDeleted = false;
        }

        public void Delete()
        {
            IsDeleted=true;
        }
    }
}
