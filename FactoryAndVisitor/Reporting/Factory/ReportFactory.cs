using FactoryAndVisitor.Reporting.Abstractions;
using FactoryAndVisitor.Reporting.Services.Detail;
using FactoryAndVisitor.Reporting.Services.Summary;

namespace FactoryAndVisitor.Reporting.Factory;

public class ReportFactory : IReportFactory
{
    public IOrderReportService Resolve(ReportType reportType) =>
        reportType switch
        {
            ReportType.Detail => new OrderDetailReportService(),
            ReportType.Summary => new OrderSummaryReportService(),
            _ => throw new NotSupportedException($"Unknown report type: {reportType}")
        };
}
