namespace Cpsc370Final.Entities;

public class Skeleton : Enemy
{
    private static Random rand = new Random();

    public Skeleton(GameObject[,] worldGrid, int x, int y) : base(worldGrid, x, y) { }

    public override char GetAsciiCharacter() => 'S';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.Red;
    public override DetectionTag GetDetectionTag() => DetectionTag.Goblin;

    public override void Move(Player player)
    {
        Direction moveDirection = rand.Next(2) == 0 ? Direction.East : Direction.West;

        if (CanMoveInDirection(moveDirection))
        {
            MoveInDirection(moveDirection);
            if (CanMoveInDirection(moveDirection))
            {
                MoveInDirection(moveDirection);
            }
        }
    }

    public override void PerformTurnAction()
    {
        Move(null);
    }
}