namespace Cpsc370Final.Entities;

public class Wraith : Enemy
{
    private static Random rand = new Random();

    public Wraith(GameObject[,] worldGrid, int x, int y) : base(worldGrid, x, y) { }

    public override char GetAsciiCharacter() => 'W';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.Cyan;
    public override DetectionTag GetDetectionTag() => DetectionTag.Goblin;

    public override void Move(Player player)
    {
        if (player == null) return;

        Direction moveDirection = DetermineBestDirection(player);
        if (CanMoveInDirection(moveDirection))
        {
            MoveInDirection(moveDirection);
        }

        if (positionX == player.positionX && positionY == player.positionY)
        {
            TeleportPlayer(player);
        }
    }

    private Direction DetermineBestDirection(Player player)
    {
        int dx = player.positionX - positionX;
        int dy = player.positionY - positionY;
        return Math.Abs(dx) > Math.Abs(dy) ? (dx > 0 ? Direction.East : Direction.West) : (dy > 0 ? Direction.South : Direction.North);
    }

    private void TeleportPlayer(Player player)
    {
        player.positionX = rand.Next(1, worldGrid.GetLength(1) - 1);
        player.positionY = rand.Next(1, worldGrid.GetLength(0) - 1);
    }

    public override void PerformTurnAction()
    {
        Move(null);
    }
}