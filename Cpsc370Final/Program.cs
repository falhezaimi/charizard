namespace Cpsc370Final;
using Cpsc370Final.Core;
using Cpsc370Final.Objects;
using Cpsc370Final.Entities;

// All comments indicate bug fixes/new implementations
class Program
{
    private static LevelGrid levelGrid;
    private static Random rand = new Random();
    private static Player player;
    private static Door exitDoor;
    private static bool gameOver = false;

    // Store enemy counts to prevent overpopulation
    private static int goblinCount = 5;
    private static int skeletonCount = 2;
    private static int wraithCount = 1;

    private static void Main(string[] args)
    {
        GenerateMap();
        player.OnDied += EndGame;
        player.OnEnteredDoor += NextFloor;

        while (!gameOver)
        {
            // Display the UI with Floor Number
            GameUI.DisplayUI(levelGrid);
            
            Console.WriteLine("\nEnter a command (W/A/S/D to move):");
            string command = Console.ReadLine();
            player.ProcessCommand(command);
            PerformGameObjectTurnActions();
        }
    }

    private static void NextFloor()
    {
        Console.Clear();
        GameUI.IncreaseFloor();
        GameUI.DisplayMessage($"You completed Floor {GameUI.FloorNumber - 1}! Onto Floor {GameUI.FloorNumber}.");

        // Remove all existing enemies before generating the next dungeon
        RemoveExistingEnemies();

        // Move player to a new empty spot instead of creating a new one
        GridPosition newPlayerPosition = levelGrid.GetRandomEmptyPosition();
        levelGrid.SetGameObjectPosition(player, newPlayerPosition);

        // Regenerate map while keeping the same player and enemy count
        GenerateMap();
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

        // Ensure the same player persists across floors
        if (player == null)
        {
            SpawnPlayer(); // First dungeon run: create the player
        }
        else
        {
            GridPosition newPlayerPosition = levelGrid.GetRandomEmptyPosition();
            levelGrid.SetGameObjectPosition(player, newPlayerPosition);
        }

        // Preserve enemy count across levels
        SpawnGoblins(goblinCount);
        SpawnSkeletons(skeletonCount);
        SpawnWraiths(wraithCount);
        SpawnKey();
        SpawnDoor();
    }

    private static void RemoveExistingEnemies()
    {
        List<GameObject> enemiesToRemove = new List<GameObject>();

        foreach (GameObject gameObject in levelGrid.GetGameObjects())
        {
            if (gameObject is Goblin || gameObject is Skeleton || gameObject is Wraith)
            {
                enemiesToRemove.Add(gameObject);
            }
        }

        foreach (GameObject enemy in enemiesToRemove)
        {
            levelGrid.RemoveGameObjectFromGrid(enemy);
        }
    }

    private static void SpawnPlayer()
    {
        int middleX = (levelGrid.GetWidth() - 1) / 2;
        int middleY = (levelGrid.GetHeight() - 1) / 2;
        GridPosition spawnPosition = new GridPosition(middleX, middleY);
        player = new Player(levelGrid, spawnPosition);
    }
    
    private static void SpawnGoblins(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
            new Goblin(levelGrid, spawnPosition);
        }
    }

    private static void SpawnSkeletons(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
            new Skeleton(levelGrid, spawnPosition);
        }
    }

    private static void SpawnWraiths(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
            new Wraith(levelGrid, spawnPosition, player);
        }
    }

    private static void SpawnKey()
    {
        GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
        new Key(levelGrid, spawnPosition);
    }

    private static void SpawnDoor()
    {
        GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
        exitDoor = new Door(levelGrid, spawnPosition);
    }
}