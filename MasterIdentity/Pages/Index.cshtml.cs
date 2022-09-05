using Infrastructure.Query.EFCORE;
using Infrastructure.Query.EFCORE.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Pages
{
    public class IndexModel : PageModel
    {
      private IArticleList _articleList { get; }
      public List<ArticleQueryDTO>? ArticleList { get; set; }

      public IndexModel(IArticleList articleList)
      {
          _articleList = articleList;
      }

      public void OnGet()
      {
          ArticleList = _articleList.getAll();
      }
    }
}