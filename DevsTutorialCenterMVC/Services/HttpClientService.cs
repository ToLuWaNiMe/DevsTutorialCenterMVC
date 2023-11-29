using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace DevsTutorialCenterMVC.Services;

public class HttpClientService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly string _baseUrl;

    public HttpClientService(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor,
        IConfiguration config)
    {
        _clientFactory = clientFactory;
        _httpContextAccessor = httpContextAccessor;
        _baseUrl = config.GetSection("ApiUrls:BaseUrl").Value;
    }

    public async Task<TRes> GetAsync<TRes>(string url)
        where TRes : class
    {
        var client = CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        var result = await GetResponseResultAsync<TRes>(client, request);
        return result;
    }

    public async Task<TRes> PostAsync<TReq, TRes>(string url, TReq requestModel)
        where TRes : class
        where TReq : class
    {
        var client = CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = new StringContent(JsonConvert.SerializeObject(requestModel), null, "application/json")
        };
        return await GetResponseResultAsync<TRes>(client, request);
    }

    public async Task<TRes> PutAsync<TReq, TRes>(string url, TReq requestModel)
        where TRes : class
        where TReq : class
    {
        var client = CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Put, url)
        {
            Content = new StringContent(JsonConvert.SerializeObject(requestModel), null, "application/json")
        };
        return await GetResponseResultAsync<TRes>(client, request);
    }
    
    public async Task<TRes> PatchAsync<TReq, TRes>(string url, TReq requestModel)
        where TRes : class
        where TReq : class
    {
        var client = CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Patch, url)
        {
            Content = new StringContent(JsonConvert.SerializeObject(requestModel), null, "application/json")
        };
        return await GetResponseResultAsync<TRes>(client, request);
    }
    
    public async Task<TRes> DeleteAsync<TRes>(string url)
        where TRes : class
    {
        var client = CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Delete, url);
        return await GetResponseResultAsync<TRes>(client, request);
    }

    private static async Task<TRes> GetResponseResultAsync<TRes>(HttpClient client, HttpRequestMessage request)
        where TRes : class
    {
        var response = await client.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();


        var result = JsonConvert.DeserializeObject<TRes>(responseString);
        return result!;
    }

    private HttpClient CreateClient()
    {
        var token = "";
        if (_httpContextAccessor.HttpContext?.User?.Claims != null)
            token = (_httpContextAccessor.HttpContext?.User?.Claims)!.FirstOrDefault(c => c.Type == "jwt")?.Value;

        var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.BaseAddress = new Uri(_baseUrl);
        if (!string.IsNullOrEmpty(token))
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return client;
    }
}