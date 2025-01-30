using System.Numerics;

namespace Cpsc370Final.Core;

/// <summary>
/// This class is what you inherit from when making any object that exists on the grid.
/// </summary>
public abstract class GameObject
{
    public LevelGrid levelGrid;
    public GridPosition position;
    public bool isMarkedForDeletion = false;

    public GameObject(LevelGrid levelGrid, GridPosition spawnPosition)
    {
        this.levelGrid = levelGrid;
        position = spawnPosition;
        levelGrid.AddGameObjectToGrid(this);
    }

    public abstract char GetAsciiCharacter();
    public abstract ConsoleColor GetAsciiColor();
    /// <summary>
    ///  This is used in order to filter objects when using detection methods.
    ///  Ex: If I want to know if a player is north, I filter with DetectionTag.Player.
    /// </summary>
    /// <returns></returns>
    public abstract DetectionTag GetDetectionTag();
    /// <summary>
    /// This function runs for all GameObjects after the user inputs a player command.
    /// This is where you should put your AI for enemies doing stuff.
    /// </summary>
    public abstract void PerformTurnAction();

    public abstract void PlayerInteraction(Player player);

    public void Move(Direction moveDirection)
    {
        GridPosition desiredPosition = position + GetDirectionOffset(moveDirection);
        
        if (DetectInDirection(DetectionTag.Player, moveDirection))
        {
            Player player = GetGameObjectInDirection(moveDirection) as Player;
            PlayerInteraction(player);
        }

        if (CanMoveInDirection(moveDirection))
        {
            levelGrid.SetGameObjectPosition(this, desiredPosition);
        }
    }

    public bool CanMoveInDirection(Direction moveDirection)
    {
        GridPosition desiredPosition = position + GetDirectionOffset(moveDirection);

        return levelGrid.IsPositionInBounds(desiredPosition) &&
               !levelGrid.IsPositionOccupied(desiredPosition);
    }

    public bool DetectInDirection(DetectionTag tag, Direction direction)
    {
        GridPosition detectPosition = position + GetDirectionOffset(direction);

        if (!levelGrid.IsPositionInBounds(detectPosition))
        {
            return tag == DetectionTag.Wall;
        }
        
        if (levelGrid.IsPositionEmpty(detectPosition))
        {
            return tag == DetectionTag.Empty;
        }
        
        GameObject detectedGameObject = levelGrid.GetGameObjectAtPosition(detectPosition);
        return detectedGameObject.GetDetectionTag() == tag;
    }
    
    public bool DetectInDirectionRaycast(DetectionTag tag, Direction direction)
    {
        GridPosition detectPosition = position + GetDirectionOffset(direction);
        while (levelGrid.IsPositionInBounds(detectPosition))
        {
            if (levelGrid.IsPositionOccupied(detectPosition))
            {
                GameObject detectedGameObject = levelGrid.GetGameObjectAtPosition(detectPosition);
                return detectedGameObject.GetDetectionTag() == tag;
            }
            detectPosition += GetDirectionOffset(direction);
        }

        return false;
    }

    public GameObject GetGameObjectInDirection(Direction direction)
    {
        GridPosition detectPosition = position + GetDirectionOffset(direction);
        if (!levelGrid.IsPositionInBounds(detectPosition)) return null;
        return levelGrid.GetGameObjectAtPosition(detectPosition);
    }
    
    public Direction PathfindToPosition(GridPosition targetPosition)
    {
        int dx = targetPosition.x - position.x;
        int dy = targetPosition.y - position.y;
        return Math.Abs(dx) > Math.Abs(dy) ? (dx > 0 ? Direction.East : Direction.West) : (dy > 0 ? Direction.South : Direction.North);
    }

    public GridPosition GetDirectionOffset(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                return new GridPosition(0, -1);
            case Direction.East:
                return new GridPosition(1, 0);
            case Direction.South:
                return new GridPosition(0, 1);
            case Direction.West:
                return new GridPosition(-1, 0);
            default:
                return new GridPosition(0, 0);
        }
    }
}