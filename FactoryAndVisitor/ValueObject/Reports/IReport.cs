namespace FactoryAndVisitor.ValueObject.Reports;


public interface IReport
{
    T Accept<T>(IVisitor<T> reportVisitor);
}

public interface IVisitor<T>
{
    T Visit(DetailReport detailReport);
    T Visit(SummaryReport summaryReport);
}


public interface IStringVisitor : IVisitor<string> { }

public interface ICsvRowVisitor : IVisitor<string> { }

