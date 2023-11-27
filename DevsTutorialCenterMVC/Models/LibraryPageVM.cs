using DevsTutorialCenterMVC.Models.Api;
using DevsTutorialCenterMVC.Models.Components;

namespace DevsTutorialCenterMVC.Models
{
    public class LibraryPageVM
    {
        public IEnumerable<BlogPostListItemVM> ReadArticles { get; set; } = new List<BlogPostListItemVM>();
        public IEnumerable<TagViewModel> AllTags { get; set; } = new List<TagViewModel>();
        public IEnumerable<AuthorListItemViewModel> TopAuthors { get; set; } = new List<AuthorListItemViewModel>();
        public IEnumerable<BlogPostRecommendationItemVM> RecentBlogPosts { get; set; } = new List<BlogPostRecommendationItemVM>();
    }
}
