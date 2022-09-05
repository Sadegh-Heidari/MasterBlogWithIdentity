using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Article;
using Application.ArticleCategory;
using Application.Comment;
using ApplicationServices.Article;
using ApplicationServices.ArticleCategory;
using ApplicationServices.Comment;
using DomainServices.Article;
using DomainServices.ArticleCategory;
using DomainServices.Base;
using DomainServices.Comment;
using DomainServices.UnitOfWork;
using Infrastructure.EFCORE.Article;
using Infrastructure.EFCORE.ArticleCategory;
using Infrastructure.EFCORE.Comment;
using Infrastructure.EFCORE.ContextDB;
using Infrastructure.EFCORE.UnitOfWork;
using Infrastructure.Query.EFCORE;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Utility.ServicePresentationLayyer
{
    public static class ServicIOC
    {
        public static void AddIoc(this IServiceCollection service,string Connection)
        {
            service.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            service.AddTransient<IArticleCategoryRepository,ArticleCategoryRepository>();

            service.AddTransient<IArticleRepository, ArticleRepository>();
            service.AddTransient<IArticleApplication, ArticleApplication>();

            service.AddTransient<ICommentRepository, CommentRepository>();
            service.AddTransient<ICommentApplication, CommentApplication>();

            service.AddTransient<IArticleList, ArticleList>();
            service.AddTransient<IUnitOfWork, UnitOfWork>();
            service.AddDbContext<MasterContext>(x => x.UseSqlServer(Connection));

        }

        public static void AutoCreatDataBase(this IServiceProvider service)
        {
            var type = service.GetService<IServiceScopeFactory>();
            type?.CreateScope()?.ServiceProvider.GetService<MasterContext>()?.Database.Migrate();
        }
    }
}
