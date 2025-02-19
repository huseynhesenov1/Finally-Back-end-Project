using System.ComponentModel.DataAnnotations;

namespace LineConstruction.BLa.DTOs
{
    public class ChangePasswordDTO
    {
        [Required]
        [Display(Prompt = "UserName")]
        public string UserName { get; set; }
        [Required]
        [Display(Prompt = "Current Password")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Prompt = "New Password")]
        [Required]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Prompt = "Confirm Password")]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
