using Transport.Core;
using Xunit;

namespace Transport.UnitTests;

public class TransportTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(10, 30)]
    [InlineData(50, 150)]
    public void Airbus_Cost_Is_Three_Dollars_Per_Mile(int distance, double expected)
    {
        ITransport t = new Airbus();
        Assert.Equal(expected, t.GetDeliveryCost(distance));
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(10, 10)]
    [InlineData(50, 50)]
    public void Truck_Cost_Is_One_Dollar_Per_Mile(int distance, double expected)
    {
        ITransport t = new Truck();
        Assert.Equal(expected, t.GetDeliveryCost(distance));
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(10, 5)]
    [InlineData(50, 25)]
    public void Ship_Cost_Is_Half_Dollar_Per_Mile(int distance, double expected)
    {
        ITransport t = new Ship();
        Assert.Equal(expected, t.GetDeliveryCost(distance));
    }

    [Fact]
    public void TruckFactory_Creates_Truck()
    {
        TransportFactory factory = new TruckFactory();
        var transport = factory.CreateTransport();
        Assert.IsType<Truck>(transport);
        Assert.Equal(20, transport.GetDeliveryCost(20));
    }

    [Fact]
    public void ShipFactory_Creates_Ship()
    {
        TransportFactory factory = new ShipFactory();
        var transport = factory.CreateTransport();
        Assert.IsType<Ship>(transport);
        Assert.Equal(10, transport.GetDeliveryCost(20));
    }
}

