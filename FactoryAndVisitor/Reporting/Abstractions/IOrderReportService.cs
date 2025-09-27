using FactoryAndVisitor.Domain.Orders;
using FactoryAndVisitor.Domain.Reports;

namespace FactoryAndVisitor.Reporting.Abstractions;

public interface IOrderReportService
{
    IEnumerable<IReport> GetReports(IEnumerable<Order> orders);
}
