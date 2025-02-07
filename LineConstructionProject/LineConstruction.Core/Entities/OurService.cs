namespace LineConstruction.Core.Entities
{
    public class OurService : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<OurTeam> Team { get; set; }
        public ICollection<Order> Order { get; set; }

    }
}
