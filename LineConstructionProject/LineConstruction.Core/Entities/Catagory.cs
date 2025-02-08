namespace LineConstruction.Core.Entities
{
    public class Catagory:BaseEntity
    {
        public string Title { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
