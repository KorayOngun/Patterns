using CreationalPatterns.AbstractFactory.Abstractions;
using CreationalPatterns.AbstractFactory.Products;

namespace CreationalPatterns.AbstractFactory.Factories;

public class MobileUIFactory : IUIFactory
{
    public IButton CreateButton()
    {
        return new MobileButton();
    }
}
