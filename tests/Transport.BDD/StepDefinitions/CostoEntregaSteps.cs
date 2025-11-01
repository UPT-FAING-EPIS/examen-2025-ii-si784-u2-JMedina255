using System;
using TechTalk.SpecFlow;
using Transport.Core;
using Xunit;

namespace Transport.BDD.StepDefinitions;

[Binding]
public class CostoEntregaSteps
{
    private ITransport? _transport;
    private TransportFactory? _factory;
    private double _costo;

    [Given(@"un transporte ""(.*)""")]
    public void DadoUnTransporte(string tipo)
    {
        _transport = tipo switch
        {
            "Airbus" => new Airbus(),
            "Truck" => new Truck(),
            "Ship" => new Ship(),
            _ => throw new ArgumentException($"Tipo de transporte desconocido: {tipo}")
        };
    }

    [Given(@"una fábrica de transporte ""(.*)""")]
    public void DadoUnaFabrica(string factory)
    {
        _factory = factory switch
        {
            "TruckFactory" => new TruckFactory(),
            "ShipFactory" => new ShipFactory(),
            _ => throw new ArgumentException($"Fábrica desconocida: {factory}")
        };
    }

    [When(@"calculo el costo para (.*) millas")]
    public void CuandoCalculoCosto(int distancia)
    {
        _costo = _transport!.GetDeliveryCost(distancia);
    }

    [When(@"creo el transporte y calculo el costo para (.*) millas")]
    public void CuandoCreoTransporteYCalculo(int distancia)
    {
        _transport = _factory!.CreateTransport();
        _costo = _transport.GetDeliveryCost(distancia);
    }

    [Then(@"el costo debe ser (.*)")]
    public void EntoncesCostoDebeSer(double esperado)
    {
        Assert.Equal(esperado, _costo);
    }
}

