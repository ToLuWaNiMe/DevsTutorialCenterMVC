namespace DevsTutorialCenterMVC.Models.Components;

public class BlogPostItemVM
{
    public string Id { get; set; }
    public string ImageUrl { get; set; }
    public TagComponentViewModel Tag { get; set; }
    public string Title { get; set; }
    public string ReadTime { get; set; }
    public string Text { get; set; }
    public AuthorListItemViewModel Author { get; set; }
    public string CreatedOn { get; set; }
}