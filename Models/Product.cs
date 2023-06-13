namespace Dataflow.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int InStock { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; } // Updated to decimal

        // Navigational properties
        public List<OrderProduct> OrderProducts { get; set; }
    }
}