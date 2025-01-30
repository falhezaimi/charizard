using Cpsc370Final.Core;

namespace Cpsc370Final.Objects;

public class Door : GameObject
{
    private Player player;
    private int keysToUnlock;

    public Door(LevelGrid levelGrid, GridPosition position, Player player, int keysToUnlock) : base(levelGrid, position)
    {
        this.player = player;
        this.keysToUnlock = keysToUnlock;
    }

    public override char GetAsciiCharacter() => 'D';
    public override ConsoleColor GetAsciiColor() => (IsLocked()) ? ConsoleColor.Gray: ConsoleColor.Magenta;
    public override DetectionTag GetDetectionTag() => DetectionTag.Door;
    
    public override void PlayerInteraction(Player player)
    {
        if (!IsLocked()) player.EnterDoor();
    }
    
    public override void PerformTurnAction() { }

    public bool IsLocked()
    {
        return player.HeldKeys < keysToUnlock;
    }
}