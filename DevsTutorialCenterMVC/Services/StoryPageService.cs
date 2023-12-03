using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Api;
using DevsTutorialCenterMVC.Models.Components;
using DevsTutorialCenterMVC.Services.Interfaces;
using DevsTutorialCenterMVC.Utilities;

namespace DevsTutorialCenterMVC.Services
{
    public class StoryPageService : BaseService
    {
        private readonly BlogPostService _blogPostService;

        public StoryPageService(HttpClient client, IHttpContextAccessor httpContextAccessor, IConfiguration config,
            BlogPostService blogPostService) : base(client, httpContextAccessor, config)
        {
            _blogPostService = blogPostService;
        }

        public async Task<IEnumerable<StoryArticlesVM>> PendingArticlesAsync()
        {
            return (await _blogPostService.GetAllArticles(new FilterArticleDto
            {
                Size = 4
            })).PageItems.Select(blog => new StoryArticlesVM
            {
                Id = blog.Id,
                ImageUrl = blog.ImageUrl,
                Tag = new TagViewModel
                {
                    Id = blog.TagId,
                    Name = blog.TagName
                },
                Title = blog.Title,
                Text = blog.Text,
                CreatedOn = blog.CreatedOn.FormatDate(),
            });
        }
    }
}