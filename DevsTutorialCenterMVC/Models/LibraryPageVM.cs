using DevsTutorialCenterMVC.Models.Components;

namespace DevsTutorialCenterMVC.Models
{
    public class LibraryPageVM
    {
        public IEnumerable<BlogPostListItemVM> ReadArticles { get; set; } = new List<BlogPostListItemVM>();
        public IEnumerable<TagComponentViewModel> AllTags { get; set; } = new List<TagComponentViewModel>();
        public IEnumerable<AuthorListItemViewModel> TopAuthors { get; set; } = new List<AuthorListItemViewModel>();
    }
}
