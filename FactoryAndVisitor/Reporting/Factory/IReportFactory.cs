using FactoryAndVisitor.Reporting.Abstractions;

namespace FactoryAndVisitor.Reporting.Factory;

public interface IReportFactory
{
    IOrderReportService Resolve(ReportType reportType);
}
