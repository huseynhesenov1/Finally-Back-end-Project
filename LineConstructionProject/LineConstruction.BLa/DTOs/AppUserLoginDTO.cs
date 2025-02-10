using System.ComponentModel.DataAnnotations;

namespace LineConstruction.BLa.DTOs
{
    public class AppUserLoginDTO
    {
        [Required]
        [Display(Prompt = "UserName")]
        public string UserName { get; set; }
        [Required]
        [Display(Prompt = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
