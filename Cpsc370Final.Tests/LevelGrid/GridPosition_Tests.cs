namespace Cpsc370Final.Tests.LevelGrid_Tests;

public class GridPosition_Tests
{
    [Fact]
    private void TestAdditionOperator()
    {
        GridPosition a;
        GridPosition b;
        GridPosition sum;
        GridPosition expected;
        
        a = new GridPosition(1, 2);
        b = new GridPosition(1, 2);
        sum = a + b;
        expected = new GridPosition(2, 4);
        Assert.Equal(expected, sum);
        
        a = new GridPosition(1, 2);
        b = new GridPosition(-1, -2);
        sum = a + b;
        expected = new GridPosition(0, 0);
        Assert.Equal(expected, sum);
    }
    
    [Fact]
    private void TestSubtractionOperator()
    {
        GridPosition a;
        GridPosition b;
        GridPosition difference;
        GridPosition expected;
        
        a = new GridPosition(1, 2);
        b = new GridPosition(1, 2);
        difference = a - b;
        expected = new GridPosition(0, 0);
        Assert.Equal(expected, difference);
        
        a = new GridPosition(1, 2);
        b = new GridPosition(-1, -2);
        difference = a - b;
        expected = new GridPosition(2, 4);
        Assert.Equal(expected, difference);
    }
    
    [Fact]
    private void TestMultiplicationOperator()
    {
        int a;
        GridPosition b;
        GridPosition product;
        GridPosition expected;

        a = 3;
        b = new GridPosition(1, 2);
        product = a * b;
        expected = new GridPosition(3, 6);
        Assert.Equal(expected, product);

        a = -4;
        product = a * b;
        expected = new GridPosition(-4, -8);
        Assert.Equal(expected, product);
    }
    
    [Fact]
    private void TestDivisionOperator()
    {
        int a;
        GridPosition b;
        GridPosition quotient;
        GridPosition expected;

        a = 4;
        b = new GridPosition(4, 8);
        quotient = b / a;
        expected = new GridPosition(1, 2);
        Assert.Equal(expected, quotient);

        a = -3;
        b = new GridPosition(6, 3);
        quotient = b / a;
        expected = new GridPosition(-2, -1);
        Assert.Equal(expected, quotient);
    }

    [Fact]
    private void TestEqualsOperator()
    {
        GridPosition a = new GridPosition(1, 2);
        GridPosition b = new GridPosition(1, 2);
        GridPosition c = new GridPosition(5, 5);
        Assert.True(a == b);
        Assert.False(a == c);
    }

    [Fact]
    private void TestNotEqualsOperator()
    {
        GridPosition a = new GridPosition(1, 2);
        GridPosition b = new GridPosition(1, 2);
        GridPosition c = new GridPosition(5, 5);
        Assert.True(a != c);
        Assert.False(a != b);
    }
}