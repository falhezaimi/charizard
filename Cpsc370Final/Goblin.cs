namespace Cpsc370Final;

public class Goblin : GameObject
{
    private Direction moveDirection = Direction.North;
    
    public Goblin(LevelGrid levelGrid, int spawnPositionX, int spawnPositionY) : base(levelGrid, spawnPositionX, spawnPositionY)
    {
    }

    public override char GetAsciiCharacter() => 'G';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.Green;
    public override DetectionTag GetDetectionTag() => DetectionTag.Goblin;
    
    public override void PerformTurnAction()
    {
        if (!DetectInDirection(DetectionTag.Empty, moveDirection))
        {
            SwitchDirection();
        }
        
        Move(moveDirection);
    }

    private void SwitchDirection()
    {
        switch (moveDirection)
        {
            case Direction.North:
                moveDirection = Direction.South;
                return;
            case Direction.South:
                moveDirection = Direction.North;
                return;
        }
    }
}