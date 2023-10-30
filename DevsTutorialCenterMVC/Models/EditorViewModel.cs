namespace DevsTutorialCenterMVC.Models
{
    public class EditorViewModel
    {
        public IEnumerable<GetAllArticlesViewModel> BlogPostEditorItemViewModels { get; set; } = new List<GetAllArticlesViewModel>();
    }
}
