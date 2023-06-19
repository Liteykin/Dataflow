namespace Dataflow.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        // Navigational properties
        public List<Product> Products { get; set; }
    }
}