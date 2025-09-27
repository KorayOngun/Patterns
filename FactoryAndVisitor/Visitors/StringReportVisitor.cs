using System.Text.Json;
using FactoryAndVisitor.Domain.Reports;

namespace FactoryAndVisitor.Visitors;

public class StringReportVisitor : IStringReportBuildVisitor
{
    public string Visit(DetailReport detailReport) => JsonSerializer.Serialize(detailReport);

    public string Visit(SummaryReport summaryReport) => JsonSerializer.Serialize(summaryReport);
}
