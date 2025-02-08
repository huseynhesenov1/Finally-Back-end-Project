namespace LineConstruction.BLa.DTOs
{
    public class BasketItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int CatagoryId { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
    }
}
