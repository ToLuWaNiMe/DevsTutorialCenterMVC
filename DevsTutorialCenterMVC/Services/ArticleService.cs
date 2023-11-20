using DevsTutorialCenterMVC.Models.Components;
using DevsTutorialCenterMVC.Services.Interfaces;

namespace DevsTutorialCenterMVC.Services
{
    public class ArticleService : BaseService, IArticleService
    {

        public ArticleService(HttpClient client, IConfiguration config) : base(client, config)
        {

        }

        public async Task<bool> Create(ViewArticleVM article)
        {
            string apiUrl = "/api/articles/create-article";

            try
            {

                bool result = await MakeRequest<bool, ViewArticleVM>(apiUrl, "POST", article);


                return result;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }

        public async Task<ViewArticleVM> GetArticleById(int id)
        {
            try
            {
                string apiUrl = $"get-single-article/{id}";

                var article = await MakeRequest<ViewArticleVM, object>(apiUrl, "GET", data: null);

                return article;
            }
            catch (HttpRequestException)
            {

                return null;
            }
        }


        public async Task<bool> UpdateArticle(int articleId, ViewArticleVM updatedArticle)
        {
            try
            {
                string apiUrl = $"/api/articles/update-article/{articleId}";
                const string methodType = "PATCH";


                var result = await MakeRequest<bool, ViewArticleVM>(apiUrl, methodType, updatedArticle);

                return result;
            }
            catch (Exception ex)
            {

                return false;
            }
        }



    }
}
