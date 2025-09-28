namespace FactoryAndVisitor.ValueObject.Reports;


public class SummaryReport : IReport
{
    public int ProductId { get; set; }
    public required string ProductName { get; set; }
    public int Count { get; set; }

    public T Accept<T>(IVisitor<T> reportVisitor)
    {
        return reportVisitor.Visit(this);
    }
}
