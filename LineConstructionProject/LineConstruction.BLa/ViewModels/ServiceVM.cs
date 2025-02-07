using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;

namespace LineConstruction.BLa.ViewModels
{
	public class ServiceVM
	{
		public OrderDTO? Order { get; set; }
		public ICollection<OurService>? OurServices { get; set; }
	}
}
