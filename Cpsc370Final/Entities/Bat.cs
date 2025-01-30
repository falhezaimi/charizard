using Cpsc370Final.Core;

namespace Cpsc370Final.Entities;

public class Bat : GameObject
{
    private Direction moveDirection = Direction.East;
    private static Random rand = new Random();

    public Bat(LevelGrid levelGrid, GridPosition position) : base(levelGrid, position)
    {
    }

    public override char GetAsciiCharacter() => 'B';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.DarkBlue;
    public override DetectionTag GetDetectionTag() => DetectionTag.Bat;

    public override void PlayerInteraction(Player player)
    {
        player.Kill();
    }

    private void SwitchDirection()
    {
        moveDirection = moveDirection == Direction.East ? Direction.West : Direction.East;
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