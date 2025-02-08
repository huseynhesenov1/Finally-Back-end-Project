using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace LineConstruction.BLa.DTOs
{
	public class ProductUpdateDTO
	{
		public int Id { get; set; }
		[Required]
		[Display(Prompt = "Title")]
		public string Title { get; set; }
		[Required]
		[Display(Prompt = "Description")]
		public string Description { get; set; }
	
		[Display(Prompt = "ImagePath")]
		public IFormFile? ImagePath { get; set; }
		[Required]
		[Display(Prompt = "CatagoryId")]
		public int CatagoryId { get; set; }
		[Required]
		[Display(Prompt = "NewPrice")]
		public decimal NewPrice { get; set; }
		[Required]
		[Display(Prompt = "OldPrice")]
		public decimal OldPrice { get; set; }
	}
}
