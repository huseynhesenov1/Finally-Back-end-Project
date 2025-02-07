namespace LineConstruction.Core.Entities
{
	public class Order : BaseEntity
	{
		public string ClientFullName { get; set; }
		public string ClientPhoneNumber { get; set; }
		public string ClientEmail { get; set; }
		public string Local { get; set; }
		public string Problem { get; set; }
		public int OurServiceId { get; set; }
		public OurService OurService { get; set; }
		public int OurTeamId { get; set; }
		public OurTeam OurTeam { get; set; }

	}
}
