using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace LineConstruction.BLa.DTOs
{
	public class OurTeamUpdateDTO
	{

		public int Id { get; set; }
		[Display(Prompt = "ExperineceYear")]

		public int ExperienceYear { get; set; }
		[Display(Prompt = "FullName")]

		public string FullName { get; set; }
		[Display(Prompt = "Title")]

		public string Title { get; set; }
		
		public IFormFile? ImagePath { get; set; }
		[Display(Prompt = "OurServiceId")]

		public int OurServiceId { get; set; }
	}
}
