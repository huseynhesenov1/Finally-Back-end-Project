using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace LineConstruction.BLa.DTOs
{
	public class AddedCVCreateDTO
	{
		[Required]
		[Display(Prompt = "Subject")]
		public int VacancyId { get; set; }
		[Required]
		[Display(Prompt = "CvPath")]
		public IFormFile CvPath { get; set; }
	}
}
 