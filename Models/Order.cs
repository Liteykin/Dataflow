namespace Dataflow.Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsShipped { get; set; }

    // Navigational properties
    public List<OrderProduct> OrderProducts { get; set; }
}