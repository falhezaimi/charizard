namespace Cpsc370Final;
using Cpsc370Final.Core;

public class Player : GameObject
{
    public Player(LevelGrid levelGrid, GridPosition spawnPosition) : base(levelGrid, spawnPosition)
    {
    }
    public bool HasKey { get; private set; } = false; // ✅ Tracks if the player has picked up a key

    public override char GetAsciiCharacter() => 'P';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.White;
    public override DetectionTag GetDetectionTag() => DetectionTag.Player;

    public override void PerformTurnAction()
    {
        // Players don't act automatically, so no need for an AI action.
    }

    // Method to collect a key
    public void CollectKey()
    {
        HasKey = true;
    }
}