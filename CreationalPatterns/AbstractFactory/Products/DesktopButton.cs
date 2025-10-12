using CreationalPatterns.AbstractFactory.Abstractions;

namespace CreationalPatterns.AbstractFactory.Products;

public class DesktopButton : Button
{
    public DesktopButton() : base("desktop") { }
}
