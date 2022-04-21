using System.Collections.Generic;

namespace Shop.Application.Articles.Queries.GetArticleList
{
    public class ArticleListVm
    {
        public IList<ArticleLookUpDto> Articles { get; set; }
    }
}
