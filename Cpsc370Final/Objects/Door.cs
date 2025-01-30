namespace Cpsc370Final.Objects;

public class Door : GameObject
{
    public Door(GameObject[,] worldGrid, int x, int y) : base(worldGrid, x, y) { }

    public override char GetAsciiCharacter() => 'D';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.Magenta;
    public override DetectionTag GetDetectionTag() => DetectionTag.Wall;
    
    public override void PerformTurnAction() { }
}