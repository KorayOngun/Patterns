using CreationalPatterns.AbstractFactory.Abstractions;

namespace CreationalPatterns.AbstractFactory.Abstractions;

public interface IUIFactory
{
    IButton CreateButton();
}
