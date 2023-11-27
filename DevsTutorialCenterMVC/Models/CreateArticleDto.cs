namespace DevsTutorialCenterMVC.Models
{
    public class CreateArticleDto
    {
        public string Title { get; set; } = string.Empty;

        public string Text { get; set; } = "Defsult Value";

        public IEnumerable<GetAllTagsViewModel> TagId { get; set; } = new List<GetAllTagsViewModel>();

        public string ImageUrl { get; set; } = "Defsult Value";
        public string PublicId { get; set; } = "Defsult Value";
    }
}
