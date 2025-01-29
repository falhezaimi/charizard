using System.Numerics;

namespace Cpsc370Final;

/// <summary>
/// This class is what you inherit from when making any object that exists on the grid.
/// </summary>
public abstract class GameObject
{
    private LevelGrid levelGrid;
    public int positionX;
    public int positionY;

    public GameObject(LevelGrid levelGrid, int spawnPositionX, int spawnPositionY)
    {
        this.levelGrid = levelGrid;
        this.positionX = spawnPositionX;
        this.positionY = spawnPositionY;
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
        int desiredPositionX = positionX;
        int desiredPositionY = positionY;
        
        switch (moveDirection)
        {
            case Direction.North:
                desiredPositionY -= 1;
                break;
            case Direction.East:
                desiredPositionX += 1;
                break;
            case Direction.South:
                desiredPositionY += 1;
                break;
            case Direction.West:
                desiredPositionX -= 1;
                break;
        }

        if (CanMoveInDirection(moveDirection))
        {
            levelGrid.SetGameObjectPosition(this, desiredPositionX, desiredPositionY);
        }
    }

    public bool CanMoveInDirection(Direction moveDirection)
    {
        int desiredPositionX = positionX;
        int desiredPositionY = positionY;
        
        switch (moveDirection)
        {
            case Direction.North:
                desiredPositionY -= 1;
                break;
            case Direction.East:
                desiredPositionX += 1;
                break;
            case Direction.South:
                desiredPositionY += 1;
                break;
            case Direction.West:
                desiredPositionX -= 1;
                break;
        }

        return levelGrid.IsPositionInBounds(desiredPositionX, desiredPositionY) &&
               !levelGrid.IsPositionOccupied(desiredPositionX, desiredPositionY);
    }

    public bool DetectInDirection(DetectionTag tag, Direction direction)
    {
        int detectPositionX = positionX;
        int detectPositionY = positionY;
        
        switch (direction)
        {
            case Direction.North:
                detectPositionY -= 1;
                break;
            case Direction.East:
                detectPositionX += 1;
                break;
            case Direction.South:
                detectPositionY += 1;
                break;
            case Direction.West:
                detectPositionX -= 1;
                break;
        }

        if (!levelGrid.IsPositionInBounds(detectPositionX, detectPositionY))
        {
            return tag == DetectionTag.Wall;
        }
        
        if (levelGrid.IsPositionEmpty(detectPositionX, detectPositionY))
        {
            return tag == DetectionTag.Empty;
        }
        
        GameObject detectedGameObject = levelGrid.GetGameObjectAtPosition(detectPositionX, detectPositionY);
        return detectedGameObject.GetDetectionTag() == tag;
    }
}