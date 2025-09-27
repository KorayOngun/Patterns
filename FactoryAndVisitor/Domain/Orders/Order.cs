namespace FactoryAndVisitor.Domain.Orders;

public class Order
{
    public int Id { get; set; }
    public required Product Product { get; set; }
    public int Count { get; set; }
    public DateOnly OrderDate { get; set; }
}
