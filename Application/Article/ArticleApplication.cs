using ApplicationServices.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.Article.DTO;
using DomainServices.Article;
using DomainServices.UnitOfWork;

namespace Application.Article
{
    public class ArticleApplication: IArticleApplication
    {
        private IUnitOfWork _UnitOfWork { get; }

        public ArticleApplication(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public List<ArticleListDto> getList()
        {
            var result = _UnitOfWork.ArticleRepository.GetListWithSelect<ArticleListDto>();
            return result;
        }

        public void AddArticle(string title, string shortDescription, string image, string content, string articleCategoryId)
        {
            var article = new Domain.ArticleAgg.Article(title, shortDescription, image, content, articleCategoryId);
            _UnitOfWork.ArticleRepository.Add(article);
            SaveAndDispose();
        }

        public void EditArticle(string Id, string title, string shortDescription, string image, string content,
            string articleCategoryId)
        {
            var article = Get(Id);
            if (article == null) throw new ArgumentNullException();
            article.Edit(title,shortDescription,image,content,articleCategoryId);
            Update(article);
        }

        public void DeleteArticle(string id)
        {
            var article = Get(id);
            if (article == null)
            {
                throw new ArgumentNullException();
            }
            article.Delete();
            Update(article);
        }

        public void ActiveArticle(string id)
        {
            var article = Get(id);
            if (article == null)
            {
                throw new ArgumentNullException();
            }
            article.Active();
            Update(article);
        }

        public GetArticleDto getArticle(string id)
        {
            var result = _UnitOfWork.ArticleRepository.GetById<GetArticleDto>(id);
            return result;
        }

        private void SaveAndDispose()
        {
            _UnitOfWork.SaveChanges();
            _UnitOfWork.Dispose();
        }

        private Domain.ArticleAgg.Article? Get(string Id)
        {
            var result = _UnitOfWork.ArticleRepository.GetById(Id);
            return result;
        }

        private void Update(Domain.ArticleAgg.Article article)
        {
            _UnitOfWork.ArticleRepository.Update(article);
            SaveAndDispose();
        }
    }
}
