using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Api;

namespace DevsTutorialCenterMVC.Services;

public class EditorService
{
    private readonly HttpClientService _httpClientService;
    public EditorService(HttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    public async Task<IEnumerable<BlogPostVM>> GetPendingArticles()
    {
        const string address = $"api/articles/fetch-articles-by-approval-status/1";
        var response = await _httpClientService.GetAsync<ResponseObject<IEnumerable<BlogPostVM>>>(address);
        return response.Data;
    }
    
    public async Task<bool> ApproveArticle(string articleId)
    {
        var address = $"api/articles/publish-article/{articleId}";
        var response = await _httpClientService.PostAsync<ResponseObject>(address);
        return response.IsSuccessful;
    }
    
    public async Task<bool> RejectArticle(string articleId)
    {
        var address = $"api/articles/reject-article/{articleId}";
        var response = await _httpClientService.PostAsync<ResponseObject>(address);
        return response.IsSuccessful;
    }
}