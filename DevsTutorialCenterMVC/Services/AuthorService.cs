using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Components;
using DevsTutorialCenterMVC.Services.Interfaces;

namespace DevsTutorialCenterMVC.Services
{
    public class AuthorService : BaseService
    {
        public AuthorService(HttpClient client, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(
            client, httpContextAccessor, config)
        {
        }

        public async Task<AuthorListItemViewModel?> GetAuthorById(int authorId)
        {
            try
            {
                var address = $"/api/authors/{authorId}";
                var methodType = "GET";

                var result =
                    await MakeRequest<ResponseObject<AuthorListItemViewModel>, string>(address, methodType, "", "");

                if (result != null)
                {
                    return result.Data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AuthorService.GetAuthorById: {ex.Message}");
            }

            return null;
        }

        public async Task<IEnumerable<AuthorListItemViewModel>> GetAllAuthorsAsync()
        {
            var address = "/api/authors";
            var methodType = "GET";

            var result =
                await MakeRequest<ResponseObject<IEnumerable<AuthorListItemViewModel>>, object>(address, methodType,
                    default(object));

            if (result?.Data == null) return Enumerable.Empty<AuthorListItemViewModel>();
            
            var authors = result.Data.Select(author => new AuthorListItemViewModel
            {
                Image = author.Image,
                Name = author.Name,
                Designation = author.Designation,
                NumberOfArticles = author.NumberOfArticles
            });

            return authors;
        }
    }
}