using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        var rectangle1 = new Rectangle(4, 2, "red");
        var rectangle2 = rectangle1.Clone();
        rectangle2.Color = "yellow";
        var rectangle3 = rectangle2.Clone();


        Console.WriteLine(JsonSerializer.Serialize(rectangle1));
        Console.WriteLine(JsonSerializer.Serialize(rectangle2));
        Console.WriteLine(JsonSerializer.Serialize(rectangle3));
    }
}

public class Rectangle
{
    public Rectangle(int width, int height, string color)
    {
        Width = width;
        Height = height;
        Color = color;
    }
    public int Width { get; set; }
    public int Height { get; set; }
    public string Color { get; set; }

    public Rectangle Clone()
    {
        return (Rectangle)MemberwiseClone();
    }
}