using Cpsc370Final.Core;

namespace Cpsc370Final.Objects;

public class MimicDoor : GameObject
{
    private Player player;
    private int keysToUnlock;

    public MimicDoor(LevelGrid levelGrid, GridPosition position, Player player, int keysToUnlock) : base(levelGrid, position)
    {
        this.player = player;
        this.keysToUnlock = keysToUnlock;
    }

    public override char GetAsciiCharacter() => 'D';
    
    // MimicDoor turns dark magenta instead of normal magenta
    public override ConsoleColor GetAsciiColor() => (IsLocked()) ? ConsoleColor.Gray : ConsoleColor.DarkMagenta;

    public override DetectionTag GetDetectionTag() => DetectionTag.Door;

    public override void PlayerInteraction(Player player)
    {
        if (!IsLocked())
        {
            player.Kill();
        }
    }

    public override void PerformTurnAction() { }

    public bool IsLocked()
    {
        return player.HeldKeys < keysToUnlock;
    }
}