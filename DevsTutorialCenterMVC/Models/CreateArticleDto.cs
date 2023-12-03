using DevsTutorialCenterMVC.Models.Components;

namespace DevsTutorialCenterMVC.Models
{
    public class CreateArticleDto
    {
        public string Title { get; set; } = string.Empty;

        public string Text { get; set; } = string.Empty;

        public IEnumerable<TagViewModel> Tags { get; set; } = new List<TagViewModel>();

        public string ImageUrl { get; set; } = string.Empty;
        public string PublicId { get; set; } = string.Empty;
    }
}
