namespace Cpsc370Final;

public class Player : GameObject
{
    public bool HasKey { get; private set; } = false; // ✅ Tracks if the player has picked up a key

    public Player(GameObject[,] worldGrid, int spawnPositionX, int spawnPositionY) 
        : base(worldGrid, spawnPositionX, spawnPositionY) { }

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