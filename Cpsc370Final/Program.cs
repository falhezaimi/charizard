namespace Cpsc370Final;
using Cpsc370Final.Core;
using Cpsc370Final.Objects;
using Cpsc370Final.Entities;

class Program
{
    private static LevelGrid levelGrid;
    private static Random rand = new Random();

    private static Player player;
    private static Door exitDoor;

    private static bool gameOver = false;

    private static void Main(string[] args)
    {
        GenerateMap();
        player.OnDied += EndGame;
        player.OnEnteredDoor += NextFloor;

        while (!gameOver)
        {
            Render();
            Console.WriteLine("\nEnter a command (W/A/S/D to move):");
            string command = Console.ReadLine();
            player.ProcessCommand(command);
            PerformGameObjectTurnActions();
        }
    }

    private static void NextFloor()
    {
        Console.Clear();
        Console.WriteLine("\nYou entered the door! Somebody code the NextFloor function in Program to make this generate a new level.");
        gameOver = true;
    }

    private static void EndGame()
    {
        Console.Clear();
        Console.WriteLine("\nGame Over! Press any key to return to Main Menu...");
        gameOver = true;
    }

    private static void PerformGameObjectTurnActions()
    {
        foreach (GameObject gameObject in levelGrid.GetGameObjects())
        {
            gameObject.PerformTurnAction();
        }
    }
    
    private static void GenerateMap()
    {
        levelGrid = new LevelGrid(20, 10);
        
        SpawnPlayer();
        SpawnGoblins();
        SpawnSkeletons();
        SpawnWraiths();
        SpawnKey();
        SpawnDoor();
    }

    private static void SpawnPlayer()
    {
        int middleX = (levelGrid.GetWidth() - 1) / 2;
        int middleY = (levelGrid.GetHeight() - 1) / 2;
        GridPosition spawnPosition = new GridPosition(middleX, middleY);
        player = new Player(levelGrid, spawnPosition);
    }
    
    private static void SpawnGoblins()
    {
        for (int i = 0; i < 5; i++)
        {
            GridPosition spawnPosition;
            spawnPosition.x = rand.Next(1, levelGrid.GetWidth() - 1);
            spawnPosition.y = rand.Next(1, levelGrid.GetHeight() - 1);   
            GameObject goblin = new Goblin(levelGrid, spawnPosition);
        }
    }

    private static void SpawnSkeletons()
    {
        for (int i = 0; i < 2; i++) // Adjust number as needed
        {
            GridPosition spawnPosition;
            spawnPosition.x = rand.Next(1, levelGrid.GetWidth() - 1);
            spawnPosition.y = rand.Next(1, levelGrid.GetHeight() - 1);   
            GameObject skeleton = new Skeleton(levelGrid, spawnPosition);
        }
    }

    private static void SpawnWraiths()
    {
        for (int i = 0; i < 1; i++) // Adjust number as needed
        {
            GridPosition spawnPosition;
            spawnPosition.x = rand.Next(1, levelGrid.GetWidth() - 1);
            spawnPosition.y = rand.Next(1, levelGrid.GetHeight() - 1);   
            GameObject wraith = new Wraith(levelGrid, spawnPosition, player);
        }
    }

    private static void SpawnKey()
    {
        GridPosition spawnPosition = new GridPosition(0, 0);
        Key key = new Key(levelGrid, spawnPosition);
    }

    private static void SpawnDoor()
    {
        GridPosition spawnPosition = new GridPosition(levelGrid.GetWidth()-1, levelGrid.GetHeight()-1);
        exitDoor = new Door(levelGrid, spawnPosition);
    }

    // private static void SpawnRandomEntity(GameObject entity)
    // {
    //     int x, y;
    //     do
    //     {
    //         x = rand.Next(1, worldGrid.GetLength(1) - 1);
    //         y = rand.Next(1, worldGrid.GetLength(0) - 1);
    //     } while (worldGrid[y, x] != null); // Ensure it spawns in an empty location
    //
    //     entity.positionX = x;
    //     entity.positionY = y;
    //     worldGrid[y, x] = entity;
    //     gameObjects.Add(entity);
    // }
    
    private static void Render() {
        Console.Clear();
        Console.WriteLine("Game Title:\n");
        levelGrid.Render();
    }
}
