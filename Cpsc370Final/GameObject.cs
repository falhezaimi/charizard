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