using LineConstruction.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineConstruction.BLa.DTOs
{
	public class OrderDTO
	{
		public string ClientFullName { get; set; }
		public string ClientPhoneNumber { get; set; }
		public string ClientEmail { get; set; }
		public string Local { get; set; }
		public string Problem { get; set; }
		public int OurServiceId { get; set; }
		public int OurTeamId { get; set; }
	}
}
