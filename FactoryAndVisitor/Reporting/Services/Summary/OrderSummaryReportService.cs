using FactoryAndVisitor.Domain.Orders;
using FactoryAndVisitor.ValueObject.Reports;
using FactoryAndVisitor.Reporting.Abstractions;

namespace FactoryAndVisitor.Reporting.Services.Summary;

public class OrderSummaryReportService : IOrderReportService
{
    public IEnumerable<IReport> GetReports(IEnumerable<Order> orders)
    {
        var groups = orders.GroupBy(x => new { x.Product.Id, x.Product.Name });
        return groups.Select(x => new SummaryReport()
        {
            ProductId = x.Key.Id,
            ProductName = x.Key.Name,
            Count = x.Sum(x => x.Count)
        });
    }
}
