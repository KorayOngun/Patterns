using FactoryAndVisitor.Domain.Orders;
using FactoryAndVisitor.ValueObject.Reports;

using FactoryAndVisitor.Reporting.Abstractions;

namespace FactoryAndVisitor.Reporting.Services.Detail;

public class OrderDetailReportService : IOrderReportService
{
    private DetailReport[] CreateData(IEnumerable<Order> orders)
    {
        var groups = orders.GroupBy(x => new { x.Product.Id, x.Product.Name, x.OrderDate });
        return groups.Select(x => new DetailReport()
        {
            ProductId = x.Key.Id,
            ProductName = x.Key.Name,
            OrderDate = x.Key.OrderDate,
            Count = x.Sum(x => x.Count)
        }).ToArray();
    }
    public IEnumerable<IReport> GetReports(IEnumerable<Order> orders)
    {
        return CreateData(orders);
    }

    public T Export<T>(IExportStrategy<T> strategy, IEnumerable<Order> orders)
    {
            
        
    }    



}

public interface IExportStrategy<T>
{
    T Export();
}

public interface CsvExport : IExportStrategy<byte[]>
{
    
}