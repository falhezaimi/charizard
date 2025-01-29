namespace Cpsc370Final;

class Program
{
    private static GameObject[,] worldGrid;
    private static Random rand = new Random();

    private static GameObject player = new GameObject();
    
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
    
    private static void GenerateMap()
    {
        worldGrid = new GameObject[10, 20];
        for (int i = 0; i < worldGrid.GetLength(0); i++)
        {
            for (int j = 0; j < worldGrid.GetLength(1); j++)
            {
                worldGrid[i, j] = null;
            }
        }
        
        player.positionX = (worldGrid.GetLength(1) - 1) / 2;
        player.positionY = (worldGrid.GetLength(0) - 1) / 2;
        worldGrid[player.positionY, player.positionX] = player;
        Console.WriteLine($"{player.positionX}, {player.positionY}");
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

    private static void MovePlayer(Direction moveDirection)
    {
        worldGrid[player.positionY, player.positionX] = null;
        
        switch (moveDirection)
        {
            case Direction.North:
                player.positionY -= 1;
                break;
            case Direction.East:
                player.positionX += 1;
                break;
            case Direction.South:
                player.positionY += 1;
                break;
            case Direction.West:
                player.positionX -= 1;
                break;
        }
        
        worldGrid[player.positionY, player.positionX] = player;
    }
    
    private static void Render() {
        //Console.Clear();
        
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
                if (gameObject != null)
                {
                    Console.ForegroundColor = gameObject.GetAsciiColor();
                    Console.Write(gameObject.GetAsciiCharacter());
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write('.');
                }
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
}
