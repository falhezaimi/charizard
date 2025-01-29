namespace Cpsc370Final;

public class Goblin : GameObject
{
    private Direction moveDirection = Direction.North;
    
    public Goblin(GameObject[,] worldGrid, int spawnPositionX, int spawnPositionY) : base(worldGrid, spawnPositionX, spawnPositionY)
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