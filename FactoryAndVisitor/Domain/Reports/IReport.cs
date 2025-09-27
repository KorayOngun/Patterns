namespace FactoryAndVisitor.Domain.Reports;

public interface IReport
{
    string Accept(IStringReportBuildVisitor reportVisitor);
}

public interface IStringReportBuildVisitor
{
    string Visit(DetailReport detailReport);
    string Visit(SummaryReport summaryReport);
}
