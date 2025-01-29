using System.Numerics;

namespace Cpsc370Final;

/// <summary>
/// This class is what you inherit from when making an entity for the game that exists on the grid.
/// </summary>
public class GameObject
{
    public int positionX;
    public int positionY;
    public char GetAsciiCharacter()
    {
        return 'P';
    }

    public ConsoleColor GetAsciiColor()
    {
        return ConsoleColor.White;
    }
}