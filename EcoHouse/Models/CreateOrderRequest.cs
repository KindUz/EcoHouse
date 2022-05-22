namespace EcoHouse.Models
{
    public class CreateOrderRequest
    {
        public int Price { get; set; }
        public int Count { get; set; }
        public int DishID { get; set; }
        public string Description { get; set; }
        public int Delivery_ID { get; set; }
    }
}
