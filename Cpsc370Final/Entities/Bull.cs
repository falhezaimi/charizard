using Cpsc370Final.Core;

namespace Cpsc370Final.Entities;

public class Bull : GameObject
{
    private static Random rand = new Random();
    private Player player;

    private Direction chargeDirection;
    private int chargeActivationRange = 4;
    private int chargeRangeMax = 6;
    
    private int cooldownTurnDuration = 3;
    private int cooldownCounter = 0;

    private enum State
    {
        Tracking,
        AboutToCharge,
        Cooldown,
    }
    private State currentState = State.Tracking;

    public Bull(LevelGrid levelGrid, GridPosition position, Player player) : base(levelGrid, position)
    {
        this.player = player;
    }

    public override char GetAsciiCharacter() => 'B';

    public override ConsoleColor GetAsciiColor()
    {
        switch (currentState)
        {
            case State.Tracking:
                return ConsoleColor.DarkYellow;
            case State.AboutToCharge:
                return ConsoleColor.DarkRed;
            case State.Cooldown:
                return ConsoleColor.Gray;
        }

        return ConsoleColor.DarkYellow;
    }
    public override DetectionTag GetDetectionTag() => DetectionTag.Bull;
    
    public override void PlayerInteraction(Player player)
    {
        player.Kill();
    }
    
    public override void PerformTurnAction()
    {
        switch (currentState)
        {
            case State.Tracking:
                Direction moveDirection = calculateMoveDirection();
                Move(moveDirection);
                CheckIfShouldCharge();
                break;
            case State.AboutToCharge:
                Charge();
                break;
            case State.Cooldown:
                cooldownCounter++;
                if (cooldownCounter >= cooldownTurnDuration) currentState = State.Tracking;
                break;
        }
    }

    private Direction calculateMoveDirection()
    {
        if (!IsPlayerInChargingRange())
        {
            return PathfindToPosition(player.position);
        }
        else
        {
            return PathfindAlignWithPosition(player.position);
        }
    }

    private void CheckIfShouldCharge()
    {
        bool shouldCharge = false;
        
        List<Direction> directions = new List<Direction>() { Direction.North, Direction.East, Direction.South, Direction.West };
        foreach (Direction direction in directions)
        {
            if (DetectInDirectionRaycast(DetectionTag.Player, direction))
            {
                shouldCharge = true;
                chargeDirection = direction;
            }
        }

        shouldCharge = shouldCharge && IsPlayerInChargingRange();
        if (shouldCharge) currentState = State.AboutToCharge;
    }

    private void Charge()
    {
        int spacesMoved = 0;
        while (DetectInDirection(DetectionTag.Empty, chargeDirection) || DetectInDirection(DetectionTag.Player, chargeDirection))
        {
            Move(chargeDirection);
            spacesMoved++;
            if (spacesMoved >= chargeRangeMax) break;
        }

        cooldownCounter = 0;
        currentState = State.Cooldown;
    }
    
    private bool IsGoingToCharge() => currentState == State.AboutToCharge;
    private bool IsPlayerInChargingRange() => GridPosition.Distance(player.position, position) <= chargeActivationRange;
}