namespace EcoHouse.Models
{
    public class CreateOrderRequest
    {
        public int Price { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
    }
}
