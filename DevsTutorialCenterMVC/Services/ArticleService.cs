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
    }
}
