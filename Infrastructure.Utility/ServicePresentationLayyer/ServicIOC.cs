using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Article;
using Application.ArticleCategory;
using ApplicationServices.Article;
using ApplicationServices.ArticleCategory;
using DomainServices.Article;
using DomainServices.ArticleCategory;
using DomainServices.Base;
using DomainServices.UnitOfWork;
using Infrastructure.EFCORE.Article;
using Infrastructure.EFCORE.ArticleCategory;
using Infrastructure.EFCORE.ContextDB;
using Infrastructure.EFCORE.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Utility.ServicePresentationLayyer
{
    public static class ServicIOC
    {
        public static void AddIoc(this IServiceCollection service,string Connection)
        {
            service.AddTransient<IArticleCategoryApplicationServices, ArticleCategoryApplicationServices>();
            service.AddTransient<IArticleCategoryRepository,ArticleCategoryRepository>();

            service.AddTransient<IArticleRepository, ArticleRepository>();
            service.AddTransient<IArticleApplication, ArticleApplication>();
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
