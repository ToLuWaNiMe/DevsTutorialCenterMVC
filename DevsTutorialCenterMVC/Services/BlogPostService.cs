using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Api;
using DevsTutorialCenterMVC.Services.Interfaces;
using DevsTutorialCenterMVC.Models.Components;

namespace DevsTutorialCenterMVC.Services;

public class BlogPostService : BaseService
{
    private readonly HttpClientService _httpClientService;

    public BlogPostService(HttpClient client, IHttpContextAccessor httpContextAccessor, IConfiguration config,
        HttpClientService httpClientService) : base(
        client, httpContextAccessor, config)
    {
        _httpClientService = httpClientService;
    }

    public async Task<PaginatorResponseDto<IEnumerable<BlogPostVM>>> GetAllArticles(
        FilterArticleDto? filterArticleDto = null)
    {
        var address = "/api/articles/get-all-articles";

        if (filterArticleDto is null)
        {
            var res = await
                _httpClientService.GetAsync<ResponseObject<PaginatorResponseDto<IEnumerable<BlogPostVM>>>>(address);

            return res.Data;
        }
        
        address = $"{address}?";

        if (filterArticleDto?.Page is not null)
            address = $"{address}&page={filterArticleDto.Page}";

        if (filterArticleDto?.Size is not null)
            address = $"{address}&size={filterArticleDto.Size}";

        if (!string.IsNullOrEmpty(filterArticleDto?.AuthorId))
            address = $"{address}&authorId={filterArticleDto.AuthorId}";

        if (!string.IsNullOrEmpty(filterArticleDto?.TagId))
            address = $"{address}&tagId={filterArticleDto.TagId}";

        if (filterArticleDto.IsRecentlyAdded.GetValueOrDefault())
            address = $"{address}&isRecentlyAdded={filterArticleDto.IsRecentlyAdded}";

        if (filterArticleDto.IsTopRead.GetValueOrDefault())
            address = $"{address}&isTopRead={filterArticleDto.IsTopRead}";

        var result = await
            _httpClientService.GetAsync<ResponseObject<PaginatorResponseDto<IEnumerable<BlogPostVM>>>>(address);

        return result.Data;
    }

    public async Task<IEnumerable<BlogPostVM>> GetRecommendedArticles()
    {
        
        var filter = new FilterArticleDto
        {
            Page = 1,
            Size = 15,
            IsRecentlyAdded = true
        };
        return (await GetAllArticles(filter)).PageItems;
    }

    public async Task<IEnumerable<BlogPostVM>> InterestingTopics()
    {
        var filter = new FilterArticleDto
        {
            Page = 1,
            Size = 3,
            IsTopRead = true
        };
        return (await GetAllArticles(filter)).PageItems;
    }

    public async Task<IEnumerable<BlogPostVM>> RecentPosts()
    {
        var filter = new FilterArticleDto
        {
            Page = 1,
            Size = 15,
            IsRecentlyAdded = true
        };
        return (await GetAllArticles(filter)).PageItems;
    }

    public async Task<IEnumerable<BlogPostVM>> LatestPosts()
    {
        var filter = new FilterArticleDto
        {
            Page = 1,
            Size = 3,
            IsRecentlyAdded = true
        };
        return (await GetAllArticles(filter)).PageItems;
    }

    public async Task<IEnumerable<BlogPostVM>> PopularPosts()
    {
        var filter = new FilterArticleDto
        {
            Page = 1,
            Size = 3,
            IsTopRead = true
        };
        return (await GetAllArticles(filter)).PageItems;
    }

    public async Task<IEnumerable<BlogPostVM>> TrendingPosts()
    {
        var filter = new FilterArticleDto
        {
            Page = 1,
            Size = 2,
            IsTopRead = true
        };
        return (await GetAllArticles(filter)).PageItems;
    }

    public async Task<SingleArticleVM> GetArticleById(string id)
    {
        var address = $"/api/articles/get-single-article/{id}";
        
        var res = await _httpClientService.GetAsync<ResponseObject<SingleArticleVM>>(address);
        
        return res.Data;
    }
}