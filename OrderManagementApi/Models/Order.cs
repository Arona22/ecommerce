namespace OrderManagementApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
