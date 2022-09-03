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
            _unitOfWork.Dispose();
            return result;
        }

        public void Add(ArticleCategoryGetAndAddViewModel art)
        {
            var articleCategory = new ArticleCateogry(art.Title);
            _unitOfWork.ArticleCategoryRepository.Add(articleCategory);
            _unitOfWork.SaveChanges();
            _unitOfWork.Dispose();
        }
    }
}
