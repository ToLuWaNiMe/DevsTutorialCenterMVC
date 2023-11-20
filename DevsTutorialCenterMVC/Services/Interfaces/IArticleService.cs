using DevsTutorialCenterMVC.Models.Components;

namespace DevsTutorialCenterMVC.Services.Interfaces
{
    public interface IArticleService
    {
        Task<bool> Create(ViewArticleVM article);
        Task<ViewArticleVM> GetArticleById(int id);

        Task<bool> UpdateArticle(int articleId, ViewArticleVM updatedArticle);
    }
}
