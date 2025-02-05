namespace LineConstruction.Core.Entities
{
    public abstract class BaseEntity : BaseAuditable
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

    }
}
