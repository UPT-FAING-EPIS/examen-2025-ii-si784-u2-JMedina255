using System;
using App.Core;
using TechTalk.SpecFlow;
using Xunit;

namespace App.BDD.StepDefinitions;

[Binding]
public class CalculatorSteps
{
    private int _a;
    private int _b;
    private int _result;
    private Exception? _error;

    [Given(@"que ingreso (.*) y (.*)")]
    public void GivenQueIngreso(int a, int b)
    {
        _a = a;
        _b = b;
    }

    [When(@"realizo la suma")]
    public void WhenRealizoLaSuma()
    {
        _result = new Calculator().Add(_a, _b);
    }

    [When(@"realizo la división")]
    public void WhenRealizoLaDivision()
    {
        try
        {
            _result = new Calculator().Divide(_a, _b);
        }
        catch (Exception ex)
        {
            _error = ex;
        }
    }

    [Then(@"el resultado debe ser (.*)")]
    public void ThenElResultadoDebeSer(int esperado)
    {
        Assert.Equal(esperado, _result);
    }

    [Then(@"debería ocurrir un error de división por cero")]
    public void ThenDeberiaOcurrirErrorDivisionPorCero()
    {
        Assert.NotNull(_error);
        Assert.IsType<DivideByZeroException>(_error);
    }
}
