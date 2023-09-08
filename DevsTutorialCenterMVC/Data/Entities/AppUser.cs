using Microsoft.AspNetCore.Identity;

namespace DevsTutorialCenterMVC.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;
        public string? ImageUrl { get; set; }
        public string? PublicId { get; set; }
        public bool IsReported { get; set; }
    }
}
