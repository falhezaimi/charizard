namespace Cpsc370Final.Entities;
using Cpsc370Final.Core;
public class Wraith : GameObject
{
    private static Random rand = new Random();
    private LevelGrid levelGrid;
    private Player player;

    public Wraith(LevelGrid levelGrid, GridPosition position, Player player) : base(levelGrid, position)
    {
        this.levelGrid = levelGrid;
        this.player = player;
    }

    public override char GetAsciiCharacter() => 'W';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.Cyan;
    public override DetectionTag GetDetectionTag() => DetectionTag.Wraith;
    
    public override void PlayerInteraction(Player player)
    {
        TeleportPlayer(player);
    }
    
    private void TeleportPlayer(Player player)
    {
        GridPosition randomPosition = levelGrid.GetRandomEmptyPosition();
        levelGrid.SetGameObjectPosition(player, randomPosition);
    }
    
    public override void PerformTurnAction()
    {
        if (player == null) return;

        Direction moveDirection = CalculateDirectionToPlayer(player);
        Move(moveDirection);
    }
    
    private Direction CalculateDirectionToPlayer(Player player)
    {
        int dx = player.position.x - position.x;
        int dy = player.position.y - position.y;
        return Math.Abs(dx) > Math.Abs(dy) ? (dx > 0 ? Direction.East : Direction.West) : (dy > 0 ? Direction.South : Direction.North);
    }
}