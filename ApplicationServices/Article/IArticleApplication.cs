using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.Article.DTO;

namespace ApplicationServices.Article
{
    public interface IArticleApplication
    {
        List<ArticleListDto> getList();
        void AddArticle(string title, string shortDescription, string image, string content, string articleCategoryId);
        void EditArticle(string Id,string title, string shortDescription, string image, string content, string articleCategoryId);
        void DeleteArticle(string id);
        void ActiveArticle(string id);
        GetArticleDto getArticle(string id);

    }
}
