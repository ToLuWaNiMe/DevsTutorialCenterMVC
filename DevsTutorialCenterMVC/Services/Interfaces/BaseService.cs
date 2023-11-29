using System.Net;
using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Api;
using static System.GC;

namespace DevsTutorialCenterMVC.Services.Interfaces;

public class BaseService : IDisposable
{
    private readonly HttpClient _client;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly string _baseUrl;

    public BaseService(HttpClient client, IHttpContextAccessor httpContextAccessor, IConfiguration config)
    {
        _client = client;
        _httpContextAccessor = httpContextAccessor;
        _baseUrl = config.GetSection("ApiUrls:BaseUrl").Value;
    }

    public void Dispose() => SuppressFinalize(true);


    public async Task<TResult?> MakeRequest<TResult, TData>(string address, string methodType, TData data,
        string token = "")
    {
        if (string.IsNullOrEmpty(address)) throw new ArgumentNullException("address");
        if (string.IsNullOrEmpty(methodType)) throw new ArgumentNullException("method type");

        if (!string.IsNullOrEmpty(token))
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        var apiResult = methodType.ToUpper() switch
        {
            "POST" => await _client.PostAsJsonAsync($"{_baseUrl}{address}", data),
            "PUT" => await _client.PutAsJsonAsync($"{_baseUrl}{address}", data),
            "DELETE" => await _client.DeleteAsync($"{_baseUrl}{address}"),
            _ => await _client.GetAsync($"{_baseUrl}{address}")
        };

        if (apiResult.StatusCode == HttpStatusCode.BadRequest)
        {
            var res = await apiResult.Content.ReadFromJsonAsync<TResult>();
            return res;
        }

        if (!apiResult.IsSuccessStatusCode)
            return default;

        var result = await apiResult.Content.ReadFromJsonAsync<TResult>();

        return result ?? default;
    }

    public async Task<TResult> MakeRequest<TResult>(string address) where TResult : class
    {
        if (string.IsNullOrEmpty(address)) throw new ArgumentNullException(nameof(address));

        var token = string.Empty;
        var claim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(claim => claim.Type == "JwtToken");

        if (claim is not null)
            token = claim.Value;

        if (!string.IsNullOrEmpty(token))
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        var apiResult = await _client.GetAsync($"{_baseUrl}{address}");

        if (apiResult.StatusCode != HttpStatusCode.BadRequest && !apiResult.IsSuccessStatusCode)
            throw new HttpRequestException(await apiResult.Content.ReadAsStringAsync());

        var result = await apiResult.Content.ReadFromJsonAsync<TResult>();
            
        return result!;
    }
}