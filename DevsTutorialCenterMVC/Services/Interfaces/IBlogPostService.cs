using DevsTutorialCenterMVC.Models;

namespace DevsTutorialCenterMVC.Services.Interfaces;

public interface IBlogPostService
{
    Task<IEnumerable<GetAllArticlesViewModel>> LatestPosts();
    Task<IEnumerable<GetAllArticlesViewModel>> TrendingPosts();
    Task<IEnumerable<GetAllArticlesViewModel>> Popular();
    Task<IEnumerable<GetAllTagsViewModel>> InterestingTopics();


}