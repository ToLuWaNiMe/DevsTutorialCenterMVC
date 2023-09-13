using System.ComponentModel.DataAnnotations;

namespace DevsTutorialCenterMVC.Models
{
    public class SignUpViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Stack { get; set; }
        public int SquadNumber { get; set; }
        public string Token { get; set; }

        [Required]
        [StringLength( 50, MinimumLength = 8)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
