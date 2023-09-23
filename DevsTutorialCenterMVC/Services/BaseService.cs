﻿namespace DevsTutorialCenterMVC.Services
{

    public class BaseService : IDisposable
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;

        public BaseService(HttpClient client, IConfiguration config)
        {
            _client = client;
            _baseUrl = config.GetSection("ApiUrls:BaseUrl").Value;
        }

        public void Dispose() { System.GC.SuppressFinalize(true); }


        public async Task<TResult?> MakeRequest<TResult, TData>(string address, string methodType, TData data, string token)
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

            if (apiResult != null)
            {
                if (apiResult.IsSuccessStatusCode)
                {
                    if (apiResult.Content != null)
                    {
                        var result = await apiResult.Content.ReadFromJsonAsync<TResult>();
                        if (result != null)
                            return result;
                    }
                }
            }

            return default;
        }
    }
}
