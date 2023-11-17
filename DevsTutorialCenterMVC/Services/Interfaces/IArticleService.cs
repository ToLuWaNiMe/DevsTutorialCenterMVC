using DevsTutorialCenterMVC.Models.Components;

namespace DevsTutorialCenterMVC.Services.Interfaces
{
    public interface IArticleService
    {
        Task<bool> Create(ViewArticleVM article);
    }
}
