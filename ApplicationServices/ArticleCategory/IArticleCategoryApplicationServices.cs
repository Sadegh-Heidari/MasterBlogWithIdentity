using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.ArticleCategory.ViewModel;

namespace ApplicationServices.ArticleCategory
{
    public interface IArticleCategoryApplicationServices
    {
        List<ArticleCategoryGetAndAddViewModel> GetAll();
        void Add(ArticleCategoryGetAndAddViewModel art);
        void Delete(string Id);
        void Active(string Id);
        void Update(ArticleCategoryGetAndAddViewModel art);
    }
}
