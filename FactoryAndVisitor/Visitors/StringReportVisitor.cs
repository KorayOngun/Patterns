using System.Text.Json;
using FactoryAndVisitor.ValueObject.Reports;


namespace FactoryAndVisitor.Visitors;

public class StringReportVisitor : IStringVisitor
{
    public string Visit(DetailReport detailReport) => JsonSerializer.Serialize(detailReport);
    public string Visit(SummaryReport summaryReport) => JsonSerializer.Serialize(summaryReport);
}
