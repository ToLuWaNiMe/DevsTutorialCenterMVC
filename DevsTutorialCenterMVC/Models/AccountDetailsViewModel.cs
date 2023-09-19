namespace DevsTutorialCenterMVC.Models
{
    public class AccountDetailsViewModel
    {

        public string Id { get; set; } = "";

        public string Email { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;
        public string? ImageUrl { get; set; }
        public string? PublicId { get; set; }
        public bool IsReported { get; set; }

        public int ? Page { get; set; }
        public int? Size { get; set; }
    }
}
