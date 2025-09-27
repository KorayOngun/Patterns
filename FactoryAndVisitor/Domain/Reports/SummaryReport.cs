namespace FactoryAndVisitor.Domain.Reports;

public class SummaryReport : IReport
{
    public int ProductId { get; set; }
    public required string ProductName { get; set; }
    public int Count { get; set; }

    public string Accept(IStringReportBuildVisitor reportVisitor) => reportVisitor.Visit(this);
}
