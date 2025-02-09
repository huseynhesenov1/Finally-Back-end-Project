namespace LineConstruction.Core.Entities
{
	public class Vacancy : BaseEntity
	{
		public string Title { get; set; }
		public string Obligation { get; set; }
		public string Requirments { get; set; }
		public DateTime Deadline { get; set; }
		public bool IsActive { get; set; }
	}
}
