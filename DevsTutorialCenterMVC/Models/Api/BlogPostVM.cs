namespace DevsTutorialCenterMVC.Models.Api;

public class BlogPostVM
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public string AuthorId { get; set; }
    public string AuthorName { get; set; }
    public string? AuthorImage { get; set; } = "/images/profile.svg";
    public string TagId { get; set; }
    public string TagName { get; set; }
    public int ReadCount { get; set; }
    public string ImageUrl { get; set; }
    public string PublicId { get; set; }
    public string ReadTime { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsRecentlyAdded { get; set; }
    public bool IsTopRead { get; set; }
}