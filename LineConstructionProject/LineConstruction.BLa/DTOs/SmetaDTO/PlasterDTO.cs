using System.ComponentModel.DataAnnotations;

namespace LineConstruction.BLa.DTOs.SmetaDTO
{
    public class PlasterDTO
    {
        [Required]
        [Display(Prompt = " Divarın sahəsi (m2)")]
        public decimal Sahe { get; set; } = 1;
        [Required]
        [Display(Prompt = " Suvaqin qalinliqi (mm)")]
        public decimal Qalinliq { get; set; } = 1;
    }
}
