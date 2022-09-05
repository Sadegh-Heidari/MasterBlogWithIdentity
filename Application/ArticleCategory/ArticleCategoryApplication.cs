using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.ArticleCategory;
using ApplicationServices.ArticleCategory.DTO;
using Domain.ArticleCategoryAgg;
using DomainServices.ArticleCategory;
using DomainServices.UnitOfWork;

namespace Application.ArticleCategory
{
    public class ArticleCategoryApplication: IArticleCategoryApplication
    {
        private IUnitOfWork _unitOfWork { get; }

        public ArticleCategoryApplication(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ArticleCategoryGetAndAddDto> GetAll()
        {
            var result = _unitOfWork.ArticleCategoryRepository.getAll().Select(x =>
                new ArticleCategoryGetAndAddDto
                {
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Id = x.Id,
                    Title = x.Title,
                    IsDeleted = x.IsDeleted,
                }).ToList();
            return result;
        }

        public void Add(string Title)
        {
            var articleCategory = new Domain.ArticleCategoryAgg.ArticleCategory(Title);
            _unitOfWork.ArticleCategoryRepository.Add(articleCategory);
            SaveAndDispose();
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

        public void Update(string Title, string Id)
        {
            var article = _unitOfWork.ArticleCategoryRepository.GetById(Id!)!;
            article.EditTitle(Title);
            _unitOfWork.ArticleCategoryRepository.Update(article);
            SaveAndDispose();
        }

        public List<GetArticleCategoryTitle> GetTitle()
        {
            var result = _unitOfWork.ArticleCategoryRepository.GetTitleCategory<GetArticleCategoryTitle>();
            return result;
        }


        private void SaveAndDispose()
        {
            _unitOfWork.SaveChanges();
            _unitOfWork.Dispose();
        }
    }
}
