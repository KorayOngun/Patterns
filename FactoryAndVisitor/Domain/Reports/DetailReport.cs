namespace FactoryAndVisitor.Domain.Reports;

public class DetailReport : IReport
{
    public int ProductId { get; set; }
    public required string ProductName { get; set; }
    public DateOnly OrderDate { get; set; }
    public int Count { get; set; }

    public string Accept(IStringReportBuildVisitor reportVisitor) => reportVisitor.Visit(this);
}
