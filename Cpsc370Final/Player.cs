namespace Cpsc370Final;
using Cpsc370Final.Core;

public class Player : GameObject
{
    public event Action OnDied;
    public event Action OnEnteredDoor;
    public Player(LevelGrid levelGrid, GridPosition spawnPosition) : base(levelGrid, spawnPosition)
    {
    }
    public int HeldKeys { get; private set; } = 0; // ✅ Tracks if the player has picked up a key

    public override char GetAsciiCharacter() => 'P';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.White;
    public override DetectionTag GetDetectionTag() => DetectionTag.Player;
    
    public void Move(Direction moveDirection)
    {
        GridPosition desiredPosition = position + GetDirectionOffset(moveDirection);

        if (DetectInDirection(DetectionTag.Key, moveDirection))
        {
            GameObject key = GetGameObjectInDirection(moveDirection);
            levelGrid.RemoveGameObjectFromGrid(key);
            HeldKeys++;
        }
        
        if (DetectInDirection(DetectionTag.Door, moveDirection))
        {
            OnEnteredDoor?.Invoke();
        }

        if (DetectInDirection(DetectionTag.Goblin, moveDirection))
        {
            Kill();
        }
        
        if (DetectInDirection(DetectionTag.Skeleton, moveDirection))
        {
            Kill();
        }
        
        if (DetectInDirection(DetectionTag.Wraith, moveDirection))
        {
            GridPosition randomPosition = levelGrid.GetRandomEmptyPosition();
            levelGrid.SetGameObjectPosition(this, randomPosition);
        }

        if (CanMoveInDirection(moveDirection))
        {
            levelGrid.SetGameObjectPosition(this, desiredPosition);
        }
    }

    public void ProcessCommand(string command)
    {
        command = command.ToLower();
        command = command.Trim();

        if (command == "w") Move(Direction.North);
        else if (command == "a") Move(Direction.West);
        else if (command == "s") Move(Direction.South);
        else if (command == "d") Move(Direction.East);
    }

    public override void PerformTurnAction()
    {
        // Players don't act automatically, so no need for an AI action.
    }

    public void Kill()
    {
        OnDied?.Invoke();
    }
}