namespace Cpsc370Final;

public class Player : GameObject
{
    public Player(LevelGrid levelGrid, GridPosition spawnPosition) : base(levelGrid, spawnPosition)
    {
    }

    public override char GetAsciiCharacter() => 'P';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.White;
    public override DetectionTag GetDetectionTag() => DetectionTag.Player;

    public override void PerformTurnAction()
    {
        // Player doesn't actually do anything on turn action, their actions are treated differently as a special case
    }
}