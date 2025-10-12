using CreationalPatterns.AbstractFactory.Abstractions;

namespace CreationalPatterns.AbstractFactory.Products;

public abstract class Button : IButton
{
    private readonly string _platform;

    protected Button(string platform)
    {
        _platform = platform;
    }

    public virtual void Render()
    {
        System.Console.WriteLine($"platform: {_platform}");
    }
}
