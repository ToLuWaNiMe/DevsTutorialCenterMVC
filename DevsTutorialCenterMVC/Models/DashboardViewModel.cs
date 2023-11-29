using DevsTutorialCenterMVC.Models.Api;
using DevsTutorialCenterMVC.Models.Components;

namespace DevsTutorialCenterMVC.Models;

public class DashboardViewModel
{
    public IEnumerable<BlogPostVM> TrendingPosts { get; set; }
    public IEnumerable<BlogPostVM> LatestBlogPosts { get; set; }
    public IEnumerable<BlogPostVM> PopularBlogPosts { get; set; }
    public IEnumerable<AuthorListItemViewModel> Authors { get; set; }
    public IEnumerable<TagViewModel> Tags { get; set; }
}