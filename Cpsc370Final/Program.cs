namespace Cpsc370Final;

class Program
{
    private static LevelGrid levelGrid;
    private static List<GameObject> gameObjects = new List<GameObject>();
    private static Random rand = new Random();

    private static Player player;
    
    private static void Main(string[] args)
    {
        GenerateMap();
        
        while (true)
        {
            Render();
            Console.WriteLine("\nPress any key to continue...");
            string command = Console.ReadLine();
            ProcessCommand(command);
            PerformGameObjectTurnActions();
        }
    }

    private static void PerformGameObjectTurnActions()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.PerformTurnAction();
        }
    }
    
    private static void GenerateMap()
    {
        levelGrid = new LevelGrid(20, 10);
        
        //SpawnPlayer();
        //SpawnGoblins();
    }

    // private static void SpawnPlayer()
    // {
    //     int middleX = (levelGrid.GetWidth() - 1) / 2;
    //     int middleY = (levelGrid.GetHeight() - 1) / 2;
    //     player = new Player(levelGrid, middleX, middleY);
    //     gameObjects.Add(player);
    // }
    //
    // private static void SpawnGoblins()
    // {
    //     for (int i = 0; i < 5; i++)
    //     {
    //         int randomX = rand.Next(0, levelGrid.GetWidth() - 1);
    //         int randomY = rand.Next(0, levelGrid.GetHeight() - 1);
    //         GameObject goblin = new Goblin(levelGrid, randomX, randomY);
    //         gameObjects.Add(goblin);
    //     }
    // }

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
        levelGrid.Render();
    }
}
