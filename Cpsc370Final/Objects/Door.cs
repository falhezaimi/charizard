using Cpsc370Final.Core;

namespace Cpsc370Final.Objects;

public class Door : GameObject
{
    public Door(LevelGrid levelGrid, GridPosition position) : base(levelGrid, position) { }

    public override char GetAsciiCharacter() => 'D';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.Magenta;
    public override DetectionTag GetDetectionTag() => DetectionTag.Door;
    
    public override void PerformTurnAction() { }
}