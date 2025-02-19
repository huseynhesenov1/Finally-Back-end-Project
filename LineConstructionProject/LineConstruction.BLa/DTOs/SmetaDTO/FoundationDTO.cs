using System.ComponentModel.DataAnnotations;

namespace LineConstruction.BLa.DTOs.SmetaDTO
{
	public class FoundationDTO
	{
		[Required]
		public decimal OuterPerimetr {  get; set; }
		[Required]
		public decimal OuterTrenchWidth {  get; set; }
		[Required]
		public decimal OuterTrenchDepth {  get; set; }
		[Required]
		public decimal InternalTrenchWidth {  get; set; }
		[Required]
		public decimal InternalTrenchDepth {  get; set; }
		[Required]
		public decimal InternalPerimetr {  get; set; }
	}
}