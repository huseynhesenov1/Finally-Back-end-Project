using LineConstruction.BLa.DTOs.SmetaDTO;
using System.ComponentModel.DataAnnotations;

namespace LineConstruction.BLa.DTOs.SmetaDTO
{
    public class RoofDTO
    {
        [Required]
        public decimal RoofHeight { get; set; }
        [Required]

        public decimal LengthHouse { get; set; }
        [Required]
        
        public decimal WidthHouse { get; set; }
    }
}