using System;
using App.Core;
using Xunit;

namespace App.UnitTests;

public class CalculatorTests
{
    private readonly Calculator _sut = new();

    [Fact]
    public void Add_Works()
    {
        var r = _sut.Add(2, 3);
        Assert.Equal(5, r);
    }

    [Fact]
    public void Subtract_Works()
    {
        var r = _sut.Subtract(10, 4);
        Assert.Equal(6, r);
    }

    [Fact]
    public void Multiply_Works()
    {
        var r = _sut.Multiply(6, 7);
        Assert.Equal(42, r);
    }

    [Fact]
    public void Divide_Works()
    {
        var r = _sut.Divide(9, 3);
        Assert.Equal(3, r);
    }

    [Fact]
    public void Divide_ByZero_Throws()
    {
        Assert.Throws<DivideByZeroException>(() => _sut.Divide(1, 0));
    }
}
