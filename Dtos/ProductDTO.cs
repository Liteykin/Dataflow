namespace Dataflow.Dtos
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public decimal InStockPrice { get; set; }
        public double Rating { get; set; }
    }

    public class GetProductDTO : ProductDTO
    {
        public int Id { get; set; }
    }

    public class CreateProductDTO
    {
        public string ProductName { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public decimal InStockPrice { get; set; }
        public double Rating { get; set; }
    }

    public class UpdateProductDTO
    {
        public string ProductName { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int InStock { get; set; }
        public decimal InStockPrice { get; set; }
        public double Rating { get; set; }
    }
}