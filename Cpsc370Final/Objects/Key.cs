using Cpsc370Final.Core;

namespace Cpsc370Final.Objects;

public class Key : GameObject
{
    public Key(LevelGrid levelGrid, GridPosition position) : base(levelGrid, position) { }

    public override char GetAsciiCharacter() => 'K';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.Yellow;
    public override DetectionTag GetDetectionTag() => DetectionTag.Key;
    
    public override void PlayerInteraction(Player player)
    {
        player.AddKey();
        levelGrid.RemoveGameObjectFromGrid(this);
    }

    public override void PerformTurnAction() { }
}