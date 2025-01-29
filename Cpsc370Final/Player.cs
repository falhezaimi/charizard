namespace Cpsc370Final;

public class Player : GameObject
{
    public Player(GameObject[,] worldGrid, int spawnPositionX, int spawnPositionY) : base(worldGrid, spawnPositionX, spawnPositionY)
    {
    }

    public override char GetAsciiCharacter() => 'P';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.White;
}