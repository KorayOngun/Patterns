using FactoryAndVisitor.ValueObject.Reports;


namespace FactoryAndVisitor.Visitors;

public class CsvExportVisitor : ICsvRowVisitor
{
    public string Visit(DetailReport detailReport)
    => $"{detailReport.ProductId},{detailReport.ProductName},{detailReport.OrderDate},{detailReport.Count}";

    public string Visit(SummaryReport summaryReport)
    => $"{summaryReport.ProductId},{summaryReport.ProductName},{summaryReport.Count}";
}