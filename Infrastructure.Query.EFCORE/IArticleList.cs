using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Query.EFCORE.DTO;

namespace Infrastructure.Query.EFCORE
{
    public interface IArticleList
    {
        List<ArticleQueryDTO>? getAll();
        ArticleQueryDTO GetArticle(string id);
    }
}
