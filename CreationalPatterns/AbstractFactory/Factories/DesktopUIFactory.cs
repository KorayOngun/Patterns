using CreationalPatterns.AbstractFactory.Abstractions;
using CreationalPatterns.AbstractFactory.Products;

namespace CreationalPatterns.AbstractFactory.Factories;

public class DesktopUIFactory : IUIFactory
{
    public IButton CreateButton()
    {
        return new DesktopButton();
    }
}
