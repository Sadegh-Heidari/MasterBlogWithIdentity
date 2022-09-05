using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.ArticleCategory.DTO;

namespace ApplicationServices.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryGetAndAddDto> GetAll();
        void Add(string Title);
        void Delete(string Id);
        void Active(string Id);
        void Update(string Title,string Id);
        List<GetArticleCategoryTitle> GetTitle();
    }
}
