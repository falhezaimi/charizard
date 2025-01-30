namespace Cpsc370Final.Entities;
using Cpsc370Final.Core;
public class Skeleton : GameObject
{
    private static Random rand = new Random();

    public Skeleton(LevelGrid levelGrid, GridPosition position) : base(levelGrid, position) { }

    public override char GetAsciiCharacter() => 'S';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.Red;
    public override DetectionTag GetDetectionTag() => DetectionTag.Goblin;

    public override void PerformTurnAction()
    {
        Direction moveDirection = rand.Next(2) == 0 ? Direction.East : Direction.West;

        if (CanMoveInDirection(moveDirection))
        {
            Move(moveDirection);
            if (CanMoveInDirection(moveDirection))
            {
                Move(moveDirection);
            }
        }
    }
}