using System.ComponentModel.DataAnnotations;

namespace LineConstruction.BLa.DTOs
{
	public class VacancyDTO
    {
		[Required]
		[Display(Prompt = "Title")]
		public string Title { get; set; }
		[Required]
		[Display(Prompt = "Obligation")]
		public string Obligation { get; set; }
		[Required]
		[Display(Prompt = "Requirments")]
		public string Requirments { get; set; }
		[Required]
		[Display(Prompt = "Deadline")]
		public DateTime Deadline { get; set; }
		public bool IsActive { get; set; }

	}
}
