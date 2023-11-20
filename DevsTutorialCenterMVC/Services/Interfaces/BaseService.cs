using System.Net;
using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Api;
using static System.GC;

namespace DevsTutorialCenterMVC.Services.Interfaces
{
    public class BaseService : IDisposable
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _baseUrl;
        private HttpClient client;
        private IConfiguration config;

        public BaseService(HttpClient client, IConfiguration config)
        {
            this.client = client;
            this.config = config;
        }

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

            var apiResult = new HttpResponseMessage();

            if (!string.IsNullOrEmpty(token))
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            switch (methodType)
            {
                case "POST":
                    apiResult = await _client.PostAsJsonAsync($"{_baseUrl}{address}", data);
                    break;

                case "PUT":
                    apiResult = await _client.PutAsJsonAsync($"{_baseUrl}{address}", data);
                    break;

                case "DELETE":
                    apiResult = await _client.DeleteAsync($"{_baseUrl}{address}");
                    break;

                default:
                    apiResult = await _client.GetAsync($"{_baseUrl}{address}");
                    break;
            }

            if (!apiResult.IsSuccessStatusCode) return default;

            var result = await apiResult.Content.ReadFromJsonAsync<TResult>();

            return result ?? default;
        }

        public async Task<Result<TResult>> MakeRequest<TResult>(string address) where TResult : class
        {
            if (string.IsNullOrEmpty(address)) throw new ArgumentNullException(nameof(address));

            var token = _httpContextAccessor.HttpContext?.User?.Claims.ToString();

            if (!string.IsNullOrEmpty(token))
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var apiResult = await _client.GetAsync($"{_baseUrl}{address}");

            if (!apiResult.IsSuccessStatusCode)
                return Result.Failure<TResult>(new[]
                    { new Error("Api.Error", await apiResult.Content.ReadAsStringAsync()) });

            if (apiResult.StatusCode == HttpStatusCode.BadRequest)
            {
                
            }

            var result = await apiResult.Content.ReadFromJsonAsync<TResult>();

            return Result.Success(result!);
        }
    }
}