namespace Cpsc370Final;

class Program
{
    private static GameObject[,] worldGrid;
    private static Random rand = new Random();

    private static GameObject player;
    
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
        
        int middleX = (worldGrid.GetLength(1) - 1) / 2;
        int middleY = (worldGrid.GetLength(0) - 1) / 2;
        player = new GameObject(worldGrid, middleX, middleY);
    }

    private static void ProcessCommand(string command)
    {
        command = command.ToLower();
        command = command.Trim();

        if (command == "w") player.Move(Direction.North);
        else if (command == "a") player.Move(Direction.West);
        else if (command == "s") player.Move(Direction.South);
        else if (command == "d") player.Move(Direction.East);
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
