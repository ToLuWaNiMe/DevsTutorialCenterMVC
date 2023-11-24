namespace DevsTutorialCenterMVC.Models.Api;

public class FilterArticleDto
{
    public string? AuthorId { get; set; }
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 20;
    public bool IsDeleted { get; set; }
    public bool? IsRecentlyAdded { get; set; }
    public bool? IsTopRead { get; set; }
    public string? TagId { get; set; }
}