namespace Cpsc370Final.Objects;

public class Key : GameObject
{
    public Key(GameObject[,] worldGrid, int x, int y) : base(worldGrid, x, y) { }

    public override char GetAsciiCharacter() => 'K';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.Yellow;
    public override DetectionTag GetDetectionTag() => DetectionTag.Empty;

    public override void PerformTurnAction() { }
}