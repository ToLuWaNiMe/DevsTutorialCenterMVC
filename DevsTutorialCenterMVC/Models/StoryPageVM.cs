using DevsTutorialCenterMVC.Models.Components;

namespace DevsTutorialCenterMVC.Models
{
    public class StoryPageVM
    {
        public IEnumerable<StoryArticlesVM> PendingArticles { get; set; } = Enumerable.Empty<StoryArticlesVM>();
        public IEnumerable<StoryArticlesVM> PublishedArticles { get; set; } = Enumerable.Empty<StoryArticlesVM>();
        public IEnumerable<StoryArticlesVM> DraftArticles { get; set; } = Enumerable.Empty<StoryArticlesVM>();
        public IEnumerable<TagViewModel> AllTags { get; set; } = Enumerable.Empty<TagViewModel>();
        public IEnumerable<AuthorListItemViewModel> TopAuthors { get; set; } = Enumerable.Empty<AuthorListItemViewModel>();
    }
}
