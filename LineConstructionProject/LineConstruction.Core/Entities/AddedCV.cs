namespace LineConstruction.Core.Entities
{
	public class AddedCV : BaseEntity
	{
		public Vacancy Vacancy { get ; set; }
		public int VacancyId { get; set; }
		public string CvPath { get; set; }
	}
}
