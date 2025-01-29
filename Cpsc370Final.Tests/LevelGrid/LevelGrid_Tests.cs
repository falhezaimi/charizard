namespace Cpsc370Final.Tests.LevelGrid_Tests;

public class LevelGrid_Tests
{
    [Fact]
    private void TestIsPositionInBounds()
    {
        LevelGrid levelGrid = new LevelGrid(20, 10);
        List<GridPosition> gridPositionsInBounds = new List<GridPosition>();
        gridPositionsInBounds.Add(new GridPosition(0, 0));
        gridPositionsInBounds.Add(new GridPosition(19, 0));
        gridPositionsInBounds.Add(new GridPosition(0, 9));
        gridPositionsInBounds.Add(new GridPosition(19, 9));

        List<GridPosition> gridPositionsNotInBounds = new List<GridPosition>();
        gridPositionsNotInBounds.Add(new GridPosition(-1, 0));
        gridPositionsNotInBounds.Add(new GridPosition(0, -1));
        gridPositionsNotInBounds.Add(new GridPosition(20, 0));
        gridPositionsNotInBounds.Add(new GridPosition(0, 10));

        foreach (GridPosition gridPosition in gridPositionsInBounds)
        {
            Assert.True(levelGrid.IsPositionInBounds(gridPosition));
        }

        foreach (GridPosition gridPosition in gridPositionsNotInBounds)
        {
            Assert.False(levelGrid.IsPositionInBounds(gridPosition));
        }
    }

    [Fact]
    private void TestIsPositionEmpty()
    {
        LevelGrid levelGrid = new LevelGrid(20, 10);
        GridPosition playerPosition = new GridPosition(0, 0);
        GridPosition emptyPosition = new GridPosition(1, 0);
        Player player = new Player(levelGrid, playerPosition);
        
        Assert.True(levelGrid.IsPositionEmpty(emptyPosition));
        Assert.False(levelGrid.IsPositionEmpty(playerPosition));
    }

    [Fact]
    private void TestIsPositionOccupied()
    {
        LevelGrid levelGrid = new LevelGrid(20, 10);
        GridPosition playerPosition = new GridPosition(0, 0);
        GridPosition emptyPosition = new GridPosition(1, 0);
        Player player = new Player(levelGrid, playerPosition);
        
        Assert.True(levelGrid.IsPositionOccupied(playerPosition));
        Assert.False(levelGrid.IsPositionOccupied(emptyPosition));
    }
}