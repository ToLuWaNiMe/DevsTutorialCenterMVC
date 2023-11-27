using DevsTutorialCenterAPI.Models.DTOs;
using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Api;
using DevsTutorialCenterMVC.Services.Interfaces;

namespace DevsTutorialCenterMVC.Services
{
    public class ArticleService : BaseService, IArticleService
    {

        public ArticleService(HttpClient client, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(client, httpContextAccessor, config)
        {

        }

        public async Task<bool> Create(CreateArticleDto article)
        {
            string apiUrl = "api/articles/create-article";

            try
            {
                var result = await MakeRequest<CreateArticleDtoReturn, CreateArticleDto>(apiUrl, "POST", article);


                return result != null;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error during HTTP request: {ex.Message}");
                return false;
            }
        }

        public async Task<UpdateArticleDto> GetArticleById(int id)
        {
            try
            {
                string apiUrl = $"get-single-article/{id}";

                var article = await MakeRequest<UpdateArticleDto, object>(apiUrl, "GET", data: null);

                return article;
            }
            catch (HttpRequestException)
            {

                return null;
            }
        }


        public async Task<bool> UpdateArticle(int articleId, UpdateArticleDto updatedArticle)
        {
            try
            {
                string apiUrl = $"api/articles/update-article/{articleId}";
                const string methodType = "PATCH";


                var result = await MakeRequest<bool, UpdateArticleDto>(apiUrl, methodType, updatedArticle);

                return result;
            }
            catch (Exception ex)
            {

                return false;
            }
        }



    }
}
