using System;
using CreationalPatterns.AbstractFactory.Abstractions;
using CreationalPatterns.AbstractFactory.Factories;

internal class Program
{
    private static void Main(string[] args)
    {
        var platforms = new[] { "Desktop", "Mobile" };

        foreach (var platform in platforms)
        {
            Console.WriteLine($"--- Building UI for {platform}");
            IUIFactory factory = platform switch
            {
                "Desktop" => new DesktopUIFactory(),
                "Mobile" => new MobileUIFactory(),
                _ => throw new NotSupportedException()
            };

            var button = factory.CreateButton();
            button.Render();
            Console.WriteLine();
        }
    }
}
