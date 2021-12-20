using System.ComponentModel.DataAnnotations;

namespace TicketBookingServer.Models
{
    public class AddUserViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[^@\s]+@[^@\s\.]+\.[^@\.\s]+$",
            ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
