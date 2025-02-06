namespace LineConstruction.Core.Entities
{
    public class OurTeam: BaseEntity
    {
        public string FullName { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public int OurServiceId { get; set; }
        public int ExperienceYear { get; set; }
        public OurService OurService { get; set; }
    }
}
