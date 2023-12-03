using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Api;
using DevsTutorialCenterMVC.Models.Components;
using DevsTutorialCenterMVC.Services.Interfaces;
using DevsTutorialCenterMVC.Utilities;

namespace DevsTutorialCenterMVC.Services
{
    public class LibraryPageService : BaseService
    {
        private readonly BlogPostService _blogPostService;

        public LibraryPageService(HttpClient client, IHttpContextAccessor httpContextAccessor, IConfiguration config, BlogPostService blogPostService) : base(client, httpContextAccessor, config)
        {
            _blogPostService = blogPostService;
        }

        public async Task<IEnumerable<BlogPostListItemVM>> ReadArticles()
        {
            return (await _blogPostService.GetAllArticles(new FilterArticleDto
            {
                Size = 4
            })).PageItems.Select(blog => new BlogPostListItemVM
            {
                Id = blog.Id,
                ImageUrl = blog.ImageUrl,
                Tag = new TagViewModel
                {
                    Id = blog.TagId,
                    Name = blog.TagName
                },
                Author = new Author
                {
                    Id = blog.AuthorId,
                    Name = blog.AuthorName,
                    Image = blog.AuthorImage,
                    Designation = "UI/UX Design Intern"
                },
                Title = blog.Title,
                Text = blog.Text,
                CreatedOn = blog.CreatedOn.FormatDate(),
            });
        }

        public async Task<IEnumerable<AuthorListItemViewModel>> AllAuthors()
        {
            return new List<AuthorListItemViewModel>
            {
                new()
                {
                    FirstName = "Ayomide Akin",
                    Stack = "UIUX Designer",
                    ImageUrl = "https://via.placeholder.com/280x204",
                    NoOfArticles = 50,
                },
                new()
                {
                    FirstName = "Ayomide Akin",
                    Stack = "UIUX Designer",
                    ImageUrl = "https://via.placeholder.com/280x204",
                    NoOfArticles = 50,
                },
                new()
                {
                    FirstName = "Ayomide Akin",
                    Stack = "UIUX Designer",
                    ImageUrl = "https://via.placeholder.com/280x204",
                    NoOfArticles = 50,
                },

            };
        }

        public async Task<IEnumerable<BlogPostVM>> GetRecentlyAddedArticles(FilterArticleDto filterArticleDto)
        {
            var address = "/api/articles/get-all-article";
            const string methodType = "GET";

            // Add a parameter to filter recently added articles
            if (filterArticleDto.IsRecentlyAdded.GetValueOrDefault())
                address = $"{address}?isRecentlyAdded=true";

            var result = await MakeRequest<ResponseObject<IEnumerable<BlogPostVM>>, string>(address, methodType, "");

            if (result is null)
                return new List<BlogPostVM>();

            return result.Data.Take(3);
        }

    }
}
