using DevsTutorialCenterMVC.Models.Components;

namespace DevsTutorialCenterMVC.Models
{
    public class LibraryPageVM
    {
        public IEnumerable<BlogPostListItemVM> ReadArticles { get; set; } = new List<BlogPostListItemVM>();
        public IEnumerable<TagViewModel> AllTags { get; set; } = new List<TagViewModel>();
        public IEnumerable<AuthorListItemViewModel> TopAuthors { get; set; } = new List<AuthorListItemViewModel>();
    }
}
