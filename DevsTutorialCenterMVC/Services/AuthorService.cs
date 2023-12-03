using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Api;
using DevsTutorialCenterMVC.Models.Components;
using DevsTutorialCenterMVC.Services.Interfaces;

namespace DevsTutorialCenterMVC.Services
{
    public class AuthorService : BaseService
    {
        private readonly HttpClientService _httpClientService;

        public AuthorService(HttpClient client, IHttpContextAccessor httpContextAccessor,
            HttpClientService httpClientService, IConfiguration config) : base(
            client, httpContextAccessor, config)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IEnumerable<BlogPostVM>> GetAuthorById(string authorId)
        {
            var address = $"/api/authors/{authorId}/articles";
            var result = await _httpClientService.GetAsync<ResponseObject<IEnumerable<BlogPostVM>>>(address);
            return result.Data.Take(3);
        }

        public async Task<IEnumerable<AuthorListItemViewModel>> GetAllAuthorsAsync()
        {
            const string address = "/api/authors/author-stats";

            var result =
                await _httpClientService.GetAsync<ResponseObject<IEnumerable<AuthorListItemViewModel>>>(address);

            if (result?.Data == null) return Enumerable.Empty<AuthorListItemViewModel>();

            var authors = result.Data;

            return authors;
        }
    }
}