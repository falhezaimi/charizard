namespace Cpsc370Final.Entities;
using Cpsc370Final.Core;
public class Wraith : GameObject
{
    private static Random rand = new Random();
    private LevelGrid levelGrid;
    private Player player;

    public Wraith(LevelGrid levelGrid, GridPosition position, Player player) : base(levelGrid, position)
    {
        this.levelGrid = levelGrid;
        this.player = player;
    }

    public override char GetAsciiCharacter() => 'W';
    public override ConsoleColor GetAsciiColor() => (IsActive()) ? ConsoleColor.Cyan : ConsoleColor.Gray;
    public override DetectionTag GetDetectionTag() => DetectionTag.Wraith;
    
    private int teleportCooldown = 0;
    public override void PlayerInteraction(Player player)
    {
        TeleportPlayer(player);
    }
    
    private void TeleportPlayer(Player player)
    {
        GridPosition randomPosition = levelGrid.GetRandomEmptyPosition();
        levelGrid.SetGameObjectPosition(player, randomPosition);
        teleportCooldown = 7;
    }
    public override void PerformTurnAction()
    {
        if (teleportCooldown > 0) { teleportCooldown--; return; }
        
        if (player == null) return;

        Direction moveDirection = PathfindToPosition(player.position);
        Move(moveDirection);
    }

    public bool IsActive() => teleportCooldown == 0;
}