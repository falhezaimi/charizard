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

    public void Move(Direction moveDirection)
    {
        worldGrid[positionY, positionX] = null;
        
        switch (moveDirection)
        {
            case Direction.North:
                positionY -= 1;
                break;
            case Direction.East:
                positionX += 1;
                break;
            case Direction.South:
                positionY += 1;
                break;
            case Direction.West:
                positionX -= 1;
                break;
        }
        
        worldGrid[positionY, positionX] = this;
    }
}