namespace Cpsc370Final.Tests;
using Cpsc370Final.Core;
using Cpsc370Final.Entities;
using Cpsc370Final.Objects;

public class GameObject_Tests
{
    [Fact]
    private void TestInteractionTriggeredByPlayer()
    {
        LevelGrid levelGrid = new LevelGrid(5, 5);
        Player player = new Player(levelGrid, new GridPosition(0, 0));
        Key key =  new Key(levelGrid, new GridPosition(1, 0));
        Goblin goblin = new Goblin(levelGrid, new GridPosition(2, 0));
        
        player.Move(Direction.East);
        Assert.True(player.position == new GridPosition(1, 0));
        Assert.True(player.HeldKeys == 1);
        Assert.DoesNotContain(key, levelGrid.GetGameObjects());
    }

    [Fact]
    private void TestInteractionTriggeredByEnemy()
    {
        LevelGrid levelGrid = new LevelGrid(5, 5);
        Player player = new Player(levelGrid, new GridPosition(0, 0));
        Goblin goblin = new Goblin(levelGrid, new GridPosition(1, 0));
        goblin.Move(Direction.West);
        
        Assert.True(goblin.position == new GridPosition(0, 0));
        Assert.DoesNotContain(player, levelGrid.GetGameObjects());
    }

    [Fact]
    private void TestDetectInDirectionRaycastWhenLineOfSightUnblocked()
    {
        LevelGrid levelGrid = new LevelGrid(5, 5);
        Player player = new Player(levelGrid, new GridPosition(0, 0));
        Goblin goblin = new Goblin(levelGrid, new GridPosition(4, 0));
        
        Assert.True(goblin.DetectInDirectionRaycast(DetectionTag.Player, Direction.West));
    }
    
    [Fact]
    private void TestDetectInDirectionRaycastWhenLineOfSightBlocked()
    {
        LevelGrid levelGrid = new LevelGrid(5, 5);
        Player player = new Player(levelGrid, new GridPosition(0, 0));
        Key key =  new Key(levelGrid, new GridPosition(2, 0));
        Goblin goblin = new Goblin(levelGrid, new GridPosition(4, 0));
        
        Assert.False(goblin.DetectInDirectionRaycast(DetectionTag.Player, Direction.West));
    }
}