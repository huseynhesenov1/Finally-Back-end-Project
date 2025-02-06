using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace LineConstruction.BLa.DTOs
{
	public class OurTeamDTO
	{
		[Display(Prompt= "FullName")]
		public string FullName { get; set; }
        [Display(Prompt = "Title")]

		public string Title { get; set; }
		[Display(Prompt = "ExperineceYear")]

		public int ExperienceYear { get; set; }
        [Display(Prompt = "Image")]

        public IFormFile ImagePath { get; set; }
        [Display(Prompt = "OurServiceId")]

        public int OurServiceId { get; set; }
	}
}
