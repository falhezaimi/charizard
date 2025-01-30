using System.Numerics;

namespace Cpsc370Final.Core;

/// <summary>
/// This class is what you inherit from when making any object that exists on the grid.
/// </summary>
public abstract class GameObject
{
    private LevelGrid levelGrid;
    public GridPosition position;

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

    public void Move(Direction moveDirection)
    {
        GridPosition desiredPosition = position + GetDirectionOffset(moveDirection);

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