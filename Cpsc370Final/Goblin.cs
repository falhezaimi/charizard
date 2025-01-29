namespace Cpsc370Final;

public class Goblin : GameObject
{
    public Goblin(GameObject[,] worldGrid, int spawnPositionX, int spawnPositionY) : base(worldGrid, spawnPositionX, spawnPositionY)
    {
    }

    public override char GetAsciiCharacter() => 'G';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.Green;
    
    public override void PerformTurnAction()
    {
        Move(Direction.North);
    }
}