namespace TestTask.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Material { get; set; }
        public decimal Quantity { get; set; }
    }
}
