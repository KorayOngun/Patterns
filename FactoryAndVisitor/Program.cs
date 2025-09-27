using System.Text.Json;
using FactoryAndVisitor.Domain.Orders;
using FactoryAndVisitor.Reporting.Abstractions;
using FactoryAndVisitor.Reporting.Factory;
using FactoryAndVisitor.Visitors;
using FactoryAndVisitor.Domain.Reports;

internal class Program
{
    private static void Main(string[] args)
    {
        var products = new List<Product>
                {
                    new Product { Id = 1, Name = "Laptop" },
                    new Product { Id = 2, Name = "Telefon" },
                };

        var orders = new List<Order>
                {
                    new Order { Id = 1, Product = products[0], Count = 2, OrderDate = new DateOnly(2025, 9, 25) },
                    new Order { Id = 2, Product = products[0], Count = 1, OrderDate = new DateOnly(2025, 9, 25) },
                    new Order { Id = 3, Product = products[0], Count = 5, OrderDate = new DateOnly(2025, 9, 25) },
                    new Order { Id = 4, Product = products[0], Count = 3, OrderDate = new DateOnly(2025, 9, 26) },
                    new Order { Id = 5, Product = products[1], Count = 2, OrderDate = new DateOnly(2025, 9, 26) },
                    new Order { Id = 6, Product = products[1], Count = 1, OrderDate = new DateOnly(2025, 9, 27) },
                    new Order { Id = 7, Product = products[1], Count = 4, OrderDate = new DateOnly(2025, 9, 27) },
                    new Order { Id = 8, Product = products[1], Count = 3, OrderDate = new DateOnly(2025, 9, 28) },
                    new Order { Id = 9, Product = products[0], Count = 2, OrderDate = new DateOnly(2025, 9, 28) },
                    new Order { Id = 10, Product = products[0], Count = 1, OrderDate = new DateOnly(2025, 9, 29) }
                };


        var visitor = new StringReportVisitor();

        {
            var service = new ReportFactory().Resolve(ReportType.Detail);
            var dtos = service.GetReports(orders);
            foreach (var dto in dtos)
                Console.WriteLine(dto.Accept(visitor));

        }


        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        {
            var service = new ReportFactory().Resolve(ReportType.Summary);
            var dtos = service.GetReports(orders);
            foreach (var dto in dtos)
                Console.WriteLine(dto.Accept(visitor));
        }
    }
}