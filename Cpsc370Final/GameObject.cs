using System.Numerics;

namespace Cpsc370Final;

/// <summary>
/// This class is what you inherit from when making any object that exists on the grid.
/// </summary>
public abstract class GameObject
{
    public GameObject[,] worldGrid;
    public int positionX;
    public int positionY;

    public GameObject(GameObject[,] worldGrid, int spawnPositionX, int spawnPositionY)
    {
        this.worldGrid = worldGrid;
        this.positionX = spawnPositionX;
        this.positionY = spawnPositionY;
        worldGrid[spawnPositionY, spawnPositionX] = this;
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
            worldGrid[positionY, positionX] = null;
            positionX = desiredPositionX;
            positionY = desiredPositionY;
            worldGrid[positionY, positionX] = this;
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

        return IsPositionInBounds(desiredPositionX, desiredPositionY) &&
               !IsPositionOccupied(desiredPositionX, desiredPositionY);
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

        if (!IsPositionInBounds(detectPositionX, detectPositionY))
        {
            return tag == DetectionTag.Wall;
        }
        
        GameObject detectedGameObject = worldGrid[detectPositionY, detectPositionX];
        if (detectedGameObject == null)
        {
            return tag == DetectionTag.Empty;
        }
        
        return worldGrid[detectPositionY, detectPositionX].GetDetectionTag() == tag;
    }

    private bool IsPositionInBounds(int positionX, int positionY)
    {
        bool positionXInBounds = positionX >= 0 && positionX < worldGrid.GetLength(1);
        bool positionYInBounds = positionY >= 0 && positionY < worldGrid.GetLength(0);
        return positionXInBounds && positionYInBounds;
    }
    
    private bool IsPositionOccupied(int positionX, int positionY)
    {
        return worldGrid[positionY, positionX] != null;
    }
}