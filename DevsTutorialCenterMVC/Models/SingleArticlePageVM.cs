using DevsTutorialCenterMVC.Models.Api;
using DevsTutorialCenterMVC.Models.Components;

namespace DevsTutorialCenterMVC.Models;

public class SingleArticlePageVM
{
    public SingleArticleVM Article { get; set; }
    public IEnumerable<AuthorListItemViewModel> Authors { get; set; }
    public IEnumerable<TagViewModel> Tags { get; set; }
    public IEnumerable<BlogPostVM> MoreArticles { get; set; }
}