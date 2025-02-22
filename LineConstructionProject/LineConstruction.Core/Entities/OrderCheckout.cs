using LineConstruction.Core.Enums;

namespace LineConstruction.Core.Entities
{
    public class OrderCheckout : BaseEntity
    {
        public ICollection<BasketItem> BasketItems { get; set; }
        public OrderStatus OrderStatus { get; set; } 
        public string? Adress { get; set; }
    }
}
