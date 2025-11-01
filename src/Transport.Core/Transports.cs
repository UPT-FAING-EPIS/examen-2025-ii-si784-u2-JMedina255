namespace Transport.Core;

public interface ITransport
{
    double GetDeliveryCost(int distance);
}

public class Airbus : ITransport
{
    public double GetDeliveryCost(int distance)
    {
        return 3.00 * distance;
    }
}

public class Truck : ITransport
{
    public double GetDeliveryCost(int distance)
    {
        return 1.00 * distance;
    }
}

public class Ship : ITransport
{
    public double GetDeliveryCost(int distance)
    {
        return 0.50 * distance;
    }
}

public abstract class TransportFactory
{
    public abstract ITransport CreateTransport();
}

public class TruckFactory : TransportFactory
{
    public override ITransport CreateTransport()
    {
        return new Truck();
    }
}

public class ShipFactory : TransportFactory
{
    public override ITransport CreateTransport()
    {
        return new Ship();
    }
}

