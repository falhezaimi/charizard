namespace Cpsc370Final;

class Program
{
    private enum GameObject {
        player,
        goblin,
        rock,
        empty,
    }

    private static GameObject[,] worldGrid;
    private static Random rand = new Random();

    private static int playerX;
    private static int playerY;
    
    private static void Main(string[] args)
    {
        GenerateMap();
        
        while (true)
        {
            Render();
            Console.WriteLine("\nPress any key to continue...");
            string command = Console.ReadLine();
            ProcessCommand(command);
        }
    }

    private static void ProcessCommand(string command)
    {
        command = command.ToLower();
        command = command.Trim();

        if (command == "w") MovePlayer(Direction.North);
        else if (command == "d") MovePlayer(Direction.East);
        else if (command == "a") MovePlayer(Direction.West);
        else if (command == "s") MovePlayer(Direction.South);
    }

    private enum Direction
    {
        North,
        East,
        South,
        West,
    }

    private static void MovePlayer(Direction moveDirection)
    {
        worldGrid[playerY, playerX] = GameObject.empty;
        
        switch (moveDirection)
        {
            case Direction.North:
                playerY -= 1;
                break;
            case Direction.East:
                playerX += 1;
                break;
            case Direction.South:
                playerY += 1;
                break;
            case Direction.West:
                playerX -= 1;
                break;
        }
        
        worldGrid[playerY, playerX] = GameObject.player;
    }

    private static void GenerateMap()
    {
        worldGrid = new GameObject[10, 20];
        for (int i = 0; i < worldGrid.GetLength(0); i++)
        {
            for (int j = 0; j < worldGrid.GetLength(1); j++)
            {
                worldGrid[i, j] = GameObject.empty;
            }
        }
        
        playerX = (worldGrid.GetLength(0) - 1) / 2;
        playerY = (worldGrid.GetLength(1) - 1) / 2;
        worldGrid[playerY, playerX] = GameObject.player;
    }
    
    private static void Render() {
        Console.Clear();
        
        Console.WriteLine("Game Title:\n");
        
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("/  ");
        for (int i = 0; i < worldGrid.GetLength(1); i++)
        {
            Console.Write("-  ");
        }
        Console.WriteLine("\\");
        
        for (int i = 0; i < worldGrid.GetLength(0); i++)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|  ");
            for (int j = 0; j < worldGrid.GetLength(1); j++)
            {
                GameObject gameObject = worldGrid[i, j];
                Console.ForegroundColor = GetColorForGameObject(gameObject);
                Console.Write(GetAsciiForGameObject(gameObject));
                Console.Write("  ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");
            Console.WriteLine();
        }
        
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("\\  ");
        for (int i = 0; i < worldGrid.GetLength(1); i++)
        {
            Console.Write("-  ");
        }
        Console.Write("/");
    }

    private static char GetAsciiForGameObject(GameObject gameObject)
    {
        switch (gameObject)
        {
            case GameObject.player:
                return 'P';
            case GameObject.goblin:
                return 'G';
            case GameObject.rock:
                return 'O';
            case GameObject.empty:
                return '.';
            default:
                return '.';
        }
    }

    private static ConsoleColor GetColorForGameObject(GameObject gameObject)
    {
        switch (gameObject)
        {
            case GameObject.player:
                return ConsoleColor.White;
            case GameObject.goblin:
                return ConsoleColor.Green;
            case GameObject.rock:
                return ConsoleColor.Gray;
            case GameObject.empty:
                return ConsoleColor.DarkGray;
            default:
                return ConsoleColor.DarkGray;
        }
    }
}
