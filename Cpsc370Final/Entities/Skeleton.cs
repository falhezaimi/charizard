namespace Cpsc370Final.Entities;
using Cpsc370Final.Core;
public class Skeleton : GameObject
{
    private static Random rand = new Random();
    private Player player;

    public Skeleton(LevelGrid levelGrid, GridPosition position, Player player) : base(levelGrid, position)
    {
        this.player = player;
    }

    public override char GetAsciiCharacter() => 'S';
    public override ConsoleColor GetAsciiColor() => (WillMoveNextTurn()) ? ConsoleColor.DarkRed : ConsoleColor.Red;
    public override DetectionTag GetDetectionTag() => DetectionTag.Skeleton;
    
    public override void PlayerInteraction(Player player)
    {
        player.Kill();
    }

    private int moveCooldown = 2;
    public override void PerformTurnAction()
    {
        moveCooldown--;
        if (moveCooldown == 0)
        {
            Direction moveDirection = PathfindToPosition(player.position);
            Move(moveDirection);
            moveCooldown = 2;
        }
    }

    public bool WillMoveNextTurn()
    {
        return moveCooldown <= 1;
    }
}