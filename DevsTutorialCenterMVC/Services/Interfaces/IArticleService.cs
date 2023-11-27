using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Api;

namespace DevsTutorialCenterMVC.Services.Interfaces
{
    public interface IArticleService
    {
        Task<bool> Create(CreateArticleDto article);

        Task<UpdateArticleDto> GetArticleById(int id);

        Task<bool> UpdateArticle(int articleId, UpdateArticleDto updatedArticle);
    }
}
