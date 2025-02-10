using System.ComponentModel.DataAnnotations;

namespace LineConstruction.BLa.DTOs
{
    public class AppUserDTO
    {
        [Required]
        [Display(Prompt = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [Display(Prompt = "LastName")]
        public string LastName { get; set; }
        [Required]
        [Display(Prompt = "Username")]
        public string Username { get; set; }
        [Required]
        [Display(Prompt = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Prompt = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Prompt = "ConfirmPassword")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
         
    }
}
