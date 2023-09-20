using System.ComponentModel.DataAnnotations;

namespace DevsTutorialCenterMVC.Models
{
    public class DecadevInviteViewModel
    {
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@(decagon|decagonhq)\\.[a-zA-Z]{2,}$",
        ErrorMessage = "Invalid Email format. Email must be in the format'example@decagon(hq).(com|dev)'")]
        public string Email { get; set; }

        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(30, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string Stack { get; set; }

        [Required]
        public string SquadNumber { get; set; }
    }
}
