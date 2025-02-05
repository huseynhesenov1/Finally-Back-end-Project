using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineConstruction.BLa.DTOs
{
	public class OurServiceDTO
	{
		[Required]
		[Display(Prompt ="Title")]
		public string Title { get; set; }
        [Display(Prompt = "Description")]
        [Required]
        public string Description { get; set; }
	}
}
