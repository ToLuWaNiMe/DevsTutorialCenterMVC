using System.ComponentModel.DataAnnotations;

namespace DevsTutorialCenterMVC.Models
{
    public class SignUpViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Stack { get; set; }
        [Required]
        public string SquadNumber { get; set; }
        [Required] 
        public string PhoneNumber { get; set; } = "08012345678";
        public string Token { get; set; }
        [Required]
        [StringLength( 50, MinimumLength = 8)]
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
