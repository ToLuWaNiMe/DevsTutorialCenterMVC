namespace DevsTutorialCenterMVC.Models.Components;

public class BlogPostListItemVM
{
    public string Id { get; set; }
    public string ImageUrl { get; set; }
    public TagViewModel Tag { get; set; }
    public string Title { get; set; }
    public string ReadTime { get; set; }
    public string Text { get; set; }
    public Author Author { get; set; }
    public string CreatedOn { get; set; }
    public bool ShowBookmark { get; set; } = false;
}

public class Author
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Designation { get; set; }
    public string Image { get; set; }
}