using System.Security.Cryptography.X509Certificates;
using FactoryAndVisitor.Domain.Orders;
using FactoryAndVisitor.ValueObject.Reports;


namespace FactoryAndVisitor.Reporting.Abstractions;

public interface IOrderReportService
{
    IEnumerable<IReport> GetReports(IEnumerable<Order> orders);
}



