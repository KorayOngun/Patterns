using FactoryAndVisitor.Domain.Orders;
using FactoryAndVisitor.Domain.Reports;
using FactoryAndVisitor.Reporting.Abstractions;

namespace FactoryAndVisitor.Reporting.Services.Detail;

public class OrderDetailReportService : IOrderReportService
{
    public IEnumerable<IReport> GetReports(IEnumerable<Order> orders)
    {
        var groups = orders.GroupBy(x => new { x.Product.Id, x.Product.Name, x.OrderDate });
        return groups.Select(x => new DetailReport()
        {
            ProductId = x.Key.Id,
            ProductName = x.Key.Name,
            OrderDate = x.Key.OrderDate,
            Count = x.Sum(x => x.Count)
        });
    }
}
