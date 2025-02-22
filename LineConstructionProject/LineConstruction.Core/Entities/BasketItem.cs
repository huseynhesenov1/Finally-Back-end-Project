
namespace LineConstruction.Core.Entities
{
    public class BasketItem : BaseEntity
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public decimal Price { get; set; }
        public int? OrderCheckoutId { get; set; }
        public OrderCheckout OrderCheckout { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int Count { get; set; }

    }
}
