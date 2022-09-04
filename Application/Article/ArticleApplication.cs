using ApplicationServices.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.Article.ViewModels;
using DomainServices.Article;

namespace Application.Article
{
    public class ArticleApplication: IArticleApplication
    {
        private IArticleRepository _articleRepository { get; }

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public List<ArticleListViewModel> getList()
        {
            var result = _articleRepository.GetListWithFilter<ArticleListViewModel>();
            return result;
        }
    }
}
