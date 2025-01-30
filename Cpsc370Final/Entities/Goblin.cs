namespace Cpsc370Final.Entities;
using Cpsc370Final.Core;
public class Goblin : GameObject
{
    private Direction moveDirection = Direction.North;
    private static Random rand = new Random();

    public Goblin(LevelGrid levelGrid, GridPosition position) : base(levelGrid, position) { }

    public override char GetAsciiCharacter() => 'G';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.Green;
    public override DetectionTag GetDetectionTag() => DetectionTag.Goblin;

    private void SwitchDirection()
    {
        moveDirection = moveDirection == Direction.North ? Direction.South : Direction.North;
    }

    public override void PerformTurnAction()
    {
        if (!DetectInDirection(DetectionTag.Empty, moveDirection))
        {
            SwitchDirection();
        }
        Move(moveDirection);
    }
}