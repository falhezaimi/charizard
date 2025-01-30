namespace Cpsc370Final.Entities;

public class Goblin : Enemy
{
    private Direction moveDirection = Direction.North;
    private static Random rand = new Random();

    public Goblin(GameObject[,] worldGrid, int x, int y) : base(worldGrid, x, y) { }

    public override char GetAsciiCharacter() => 'G';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.Green;
    public override DetectionTag GetDetectionTag() => DetectionTag.Goblin;

    public override void Move(Player player)
    {
        if (!DetectInDirection(DetectionTag.Empty, moveDirection))
        {
            SwitchDirection();
        }
        MoveInDirection(moveDirection);
    }

    private void SwitchDirection()
    {
        moveDirection = moveDirection == Direction.North ? Direction.South : Direction.North;
    }

    public override void PerformTurnAction()
    {
        Move(null);
    }
}