using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.ArticleCategory;
using ApplicationServices.ArticleCategory.ViewModel;
using Domain.ArticleCategoryAgg;
using DomainServices.ArticleCategory;
using DomainServices.UnitOfWork;

namespace Application.ArticleCategory
{
    public class ArticleCategoryApplicationServices: IArticleCategoryApplicationServices
    {
        private IUnitOfWork _unitOfWork { get; }

        public ArticleCategoryApplicationServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ArticleCategoryGetAndAddViewModel> GetAll()
        {
            var result = _unitOfWork.ArticleCategoryRepository.getAll().Select(x =>
                new ArticleCategoryGetAndAddViewModel
                {
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Id = x.Id,
                    Title = x.Title,
                    IsDeleted = x.IsDeleted,
                }).ToList();
            return result;
        }

        public void Add(ArticleCategoryGetAndAddViewModel art)
        {
            var articleCategory = new ArticleCateogry(art.Title);
            _unitOfWork.ArticleCategoryRepository.Add(articleCategory);
          
        }

        public void Delete(string Id)
        {
            var art = _unitOfWork.ArticleCategoryRepository.GetById(Id);
            art!.DeleteArticleCategory();
            _unitOfWork.ArticleCategoryRepository.Update(art);
            SaveAndDispose();
        }

        public void Active(string Id)
        {
            var art = _unitOfWork.ArticleCategoryRepository.GetById(Id);
            art!.ActiveArticleCategory();
            _unitOfWork.ArticleCategoryRepository.Update(art);
            SaveAndDispose();
        }

        public void Update(ArticleCategoryGetAndAddViewModel art)
        {
            var article = _unitOfWork.ArticleCategoryRepository.GetById(art.Id!)!;
            article.EditTitle(art.Title);
            _unitOfWork.ArticleCategoryRepository.Update(article);
            SaveAndDispose();
        }

        private void SaveAndDispose()
        {
            _unitOfWork.SaveChanges();
            _unitOfWork.Dispose();
        }
    }
}
