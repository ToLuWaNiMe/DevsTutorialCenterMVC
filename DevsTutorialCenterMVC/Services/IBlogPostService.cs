using DevsTutorialCenterMVC.Models;

namespace DevsTutorialCenterMVC.Services
{
    public interface IBlogPostService
    {
        Task<IEnumerable<GetAllArticlesViewModel>> LatestPosts();
        Task<IEnumerable<GetAllArticlesViewModel>> TrendingPosts();
        Task<IEnumerable<GetAllArticlesViewModel>> Popular();


    }
}
