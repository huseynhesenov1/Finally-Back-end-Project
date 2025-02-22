namespace LineConstruction.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public Catagory Catagory {  get; set; }
        public int CatagoryId { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public int? Quantity { get; set; }
    }
}