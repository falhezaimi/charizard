using Xunit;
using Cpsc370Final.Core;
using Cpsc370Final.Objects;
using Cpsc370Final.Entities;
using Cpsc370Final;
using System;

public class GameTests
{
    private LevelGrid CreateLevelGrid(int width, int height)
    {
        return new LevelGrid(width, height);
    }

    [Fact]
    public void Player_CanMoveToEmptySpace()
    {
        var levelGrid = CreateLevelGrid(5, 5);
        var player = new Player(levelGrid, new GridPosition(2, 2));

        player.Move(Direction.North);

        Assert.Equal(new GridPosition(2, 1), player.position);
    }

    [Fact]
    public void Player_CannotMoveThroughWalls()
    {
        var levelGrid = CreateLevelGrid(5, 5);
        var player = new Player(levelGrid, new GridPosition(0, 0));

        player.Move(Direction.West);

        Assert.Equal(new GridPosition(0, 0), player.position);
    }

    [Fact]
    public void Goblin_AttacksPlayer()
    {
        var levelGrid = CreateLevelGrid(5, 5);
        var player = new Player(levelGrid, new GridPosition(2, 2));
        var goblin = new Goblin(levelGrid, new GridPosition(2, 3));

        bool playerDied = false;
        player.OnDied += () => playerDied = true;

        goblin.PerformTurnAction();

        Assert.True(playerDied, "Expected Goblin to attack and kill the player.");
    }

    
    
    [Fact]
    public void Skeleton_MovesTwoSpacesAndThenAttacks()
    {
        var levelGrid = CreateLevelGrid(5, 5);
        var player = new Player(levelGrid, new GridPosition(2, 4));
        var skeleton = new Skeleton(levelGrid, new GridPosition(2, 2));

        bool playerDied = false;
        player.OnDied += () => playerDied = true;

        Console.WriteLine($"[Before Move] Skeleton: {skeleton.position}, Player: {player.position}");

        skeleton.PerformTurnAction(); // Move first step
        Console.WriteLine($"[After First Move] Skeleton: {skeleton.position}, Player: {player.position}");

        skeleton.PerformTurnAction(); // Move second step or attack
        Console.WriteLine($"[After Second Move & Attack] Skeleton: {skeleton.position}, Player Died: {playerDied}");

        Assert.True(playerDied, "Expected Skeleton to move two spaces and attack the player.");
    }





    [Fact]
    public void Wraith_TeleportsPlayer()
    {
        var levelGrid = CreateLevelGrid(5, 5);
        var player = new Player(levelGrid, new GridPosition(2, 2));
        var wraith = new Wraith(levelGrid, new GridPosition(2, 3), player);

        var originalPosition = player.position;
        wraith.PerformTurnAction();

        Assert.NotEqual(originalPosition, player.position);
    }

    [Theory]
    [InlineData(0, 0, Direction.West)]
    [InlineData(0, 0, Direction.North)]
    [InlineData(4, 4, Direction.East)]
    [InlineData(4, 4, Direction.South)]
    public void Player_CannotMoveOutOfBounds(int x, int y, Direction direction)
    {
        var levelGrid = CreateLevelGrid(5, 5);
        var player = new Player(levelGrid, new GridPosition(x, y));

        player.Move(direction);

        Assert.Equal(new GridPosition(x, y), player.position);
    }

    [Fact]
    public void Goblin_SwitchesDirectionWhenBlocked()
    {
        var levelGrid = CreateLevelGrid(5, 5);
        var goblin = new Goblin(levelGrid, new GridPosition(2, 2));
        var wall = new Door(levelGrid, new GridPosition(2, 1)); // Block North

        var initialPosition = goblin.position;
        goblin.PerformTurnAction();

        Assert.NotEqual(initialPosition, goblin.position);
    }
}

public class LevelGrid_Tests
{
    [Fact]
    public void TestIsPositionInBounds()
    {
        var levelGrid = new LevelGrid(5, 5);

        var insidePosition = new GridPosition(2, 2);
        var outsidePosition = new GridPosition(5, 5); // Should be out of bounds

        Console.WriteLine($"Testing inside position: {insidePosition}");
        Console.WriteLine($"Testing outside position: {outsidePosition}");

        Assert.True(levelGrid.IsPositionInBounds(insidePosition), $"Expected position {insidePosition} to be in bounds.");
        Assert.False(levelGrid.IsPositionInBounds(outsidePosition), $"Expected position {outsidePosition} to be out of bounds.");
    }

    [Fact]
    public void TestSetGameObjectPosition()
    {
        var levelGrid = new LevelGrid(5, 5);
        var gameObject = new TestGameObject(levelGrid, new GridPosition(2, 2));

        Assert.True(levelGrid.IsPositionOccupied(new GridPosition(2, 2)), "Expected position (2,2) to be occupied.");
    }
}

// Concrete class for testing abstract GameObject
// Concrete class for testing abstract GameObject
public class TestGameObject : GameObject
{
    public TestGameObject(LevelGrid levelGrid, GridPosition position) : base(levelGrid, position) { }

    public override char GetAsciiCharacter() => 'T';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.Gray;
    public override DetectionTag GetDetectionTag() => DetectionTag.Empty;
    
    public override void PerformTurnAction()
    {
        // No specific action for test object
        Console.WriteLine("TestGameObject PerformTurnAction called.");
    }
}


public class GameObject_Tests
{
    [Fact]
    public void TestGameObject_PositionInitialization()
    {
        var levelGrid = new LevelGrid(5, 5);
        var testObject = new TestGameObject(levelGrid, new GridPosition(2, 2));

        Assert.Equal(new GridPosition(2, 2), testObject.position);
    }
}
