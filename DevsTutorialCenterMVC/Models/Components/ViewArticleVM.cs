namespace DevsTutorialCenterMVC.Models.Components;

public class ViewArticleVM
{
    public string ArticleId { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public string CreatedOn { get; set; }
    public TagViewModel Tag { get; set; }
}