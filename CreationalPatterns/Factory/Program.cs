internal class Program
{
    private static void Main(string[] args)
    {
        ILogistic logistic1 = new SeaLogistic();
        ILogistic logistic2 = new RoadLogistic();
        ILogistic logistic3 = new RailwayLogistic();

        ITransport transport1 = logistic1.CreateTransport();
        ITransport transport2 = logistic2.CreateTransport();
        ITransport transport3 = logistic3.CreateTransport();

        transport1.Deliver();
        transport2.Deliver();
        transport3.Deliver();
    }
}


public interface ITransport
{
    void Deliver();
}
public class Truck : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("Deliver by land in a truck");
    }
}
public class Ship : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("Deliver by sea in a ship");
    }
}

public class Train : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("deliver by train");

    }
}


public interface ILogistic
{
    ITransport CreateTransport();
}


public class SeaLogistic : ILogistic
{
    public ITransport CreateTransport()
    {
       return new Ship();
    }
}

public class RoadLogistic : ILogistic
{
    public ITransport CreateTransport()
    {
        return new Truck();
    }
}

public class RailwayLogistic : ILogistic
{
    public ITransport CreateTransport()
    {
        return new Train();
    }
}

