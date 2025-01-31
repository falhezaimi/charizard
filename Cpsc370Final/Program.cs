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
    private static int keysToCollect;
    private static bool gameOver = false;

    private static void Main(string[] args)
    {
        GenerateMap();
        player.OnDied += EndGame;
        player.OnEnteredDoor += NextFloor;

        while (!gameOver)
        {
            // Display the UI with Floor Number
            GameUI.DisplayUI(levelGrid, player, keysToCollect);
            
            Console.WriteLine("\nEnter a command (W/A/S/D to move):");
            string command = Console.ReadLine();
            player.ProcessCommand(command);
            levelGrid.PerformGameObjectTurnActions();
        }
    }

    /// <summary>
    /// Advances the player to the next floor or ends the game if they finish Floor 5.
    /// </summary>
    private static void NextFloor()
    {
        if (GameUI.IsFinalFloor())
        {
            GameUI.DisplayCompletionMessage();
            gameOver = true;
            return;
        }

        GameUI.IncreaseFloor();
        GameUI.DisplayMessage($"You completed Floor {GameUI.FloorNumber - 1}! Onto Floor {GameUI.FloorNumber}.");
        GenerateMap(); // Generate a new dungeon floor
    }

    /// <summary>
    /// Ends the game when the player dies.
    /// </summary>
    private static void EndGame()
    {
        Console.Clear();
        Console.WriteLine("\nGame Over! Press any key to return to Main Menu...");
        gameOver = true;
    }

    /// <summary>
    /// Generates the level grid, player, and predefined enemies per floor.
    /// </summary>
    private static void GenerateMap()
    {
        levelGrid = new LevelGrid(20, 10);
        
        SpawnPlayer();
        SpawnGameObjectsBasedOnFloor(); // Custom enemy spawns for each level
        SpawnDoor();
    }

    /// <summary>
    /// Controls the number of enemies spawned per floor.
    /// </summary>
    private static void SpawnGameObjectsBasedOnFloor()
    {
        int floor = GameUI.FloorNumber;

        if (floor == 1)
        {
            SpawnKeys(1);
        }
        else if (floor == 2)
        {
            SpawnKeys(1);
            SpawnGoblins(1);
        }
        else if (floor == 3)
        {
            SpawnKeys(1);
            SpawnGoblins(3);
        }
        else if (floor == 4)
        {
            SpawnKeys(2);
            SpawnSkeletons(3);
        }
        else if (floor == 5)
        {
            SpawnKeys(3);
            SpawnGoblins(4);
            SpawnSkeletons(4);
        } else if (floor == 6)
        {
            SpawnGoblins(3);
            SpawnBats(3);
            SpawnSkeletons(2);
            SpawnKeys(1);
        } else if (floor == 7)
        {
            SpawnWraiths(1);
            SpawnSkeletons(3);
            SpawnKeys(2);
        } else if (floor == 8)
        { 
            SpawnWraiths(5);
            SpawnKeys(1);
        } else if (floor == 9)
        {
            SpawnBulls(1);
            SpawnKeys(2);
        } else if (floor == 10)
        {
            SpawnBulls(1);
            SpawnSkeletons(3);
            SpawnBats(3);
            SpawnKeys(2);
        } else if (floor == 11)
        {
            SpawnGoblins(3);
            SpawnBats(3);
            SpawnBulls(1);
            SpawnWraiths(1);
            SpawnKeys(2);
        } else if (floor == 12)
        {
            SpawnWraiths(1);
            SpawnBulls(3);
            SpawnKeys(4);
        }
    }

    /// <summary>
    /// Spawns the player at a random empty position.
    /// </summary>
    private static void SpawnPlayer()
    {
        GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
        if (player == null)
        {
            // Create the player for the first time
            player = new Player(levelGrid, spawnPosition);
        }
        else
        {
            // If player already exists, reuse them in the next level
            player.position = spawnPosition;
            player.levelGrid = levelGrid;
            player.ResetKeys();
            levelGrid.AddGameObjectToGrid(player);
        }
    }

    /// <summary>
    /// Spawns goblins based on the level's requirements.
    /// </summary>
    private static void SpawnGoblins(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
            new Goblin(levelGrid, spawnPosition);
        }
    }

    /// <summary>
    /// Spawns skeletons based on the level's requirements.
    /// </summary>
    private static void SpawnSkeletons(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
            new Skeleton(levelGrid, spawnPosition, player);
        }
    }

    /// <summary>
    /// Spawns bats based on the level's requirements.
    /// </summary>
    private static void SpawnBats(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
            new Bat(levelGrid, spawnPosition);
        }
    }

    /// <summary>
    /// Spawns bulls based on the level's requirements.
    /// </summary>
    private static void SpawnBulls(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
            new Bull(levelGrid, spawnPosition, player);
        }
    }

    /// <summary>
    /// Spawns wraiths based on the level's requirements.
    /// </summary>
    private static void SpawnWraiths(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
            new Wraith(levelGrid, spawnPosition, player);
        }
    }

    /// <summary>
    /// Spawns a key at a random position.
    /// </summary>
    private static void SpawnKeys(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
            new Key(levelGrid, spawnPosition);
        }
        keysToCollect = count;
    }

    /// <summary>
    /// Spawns the exit door at a random position.
    /// </summary>
    private static void SpawnDoor()
    {
        GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
        exitDoor = new Door(levelGrid, spawnPosition, player, keysToCollect);
    }
    
    private static void SpawnMimicDoor()
    {
        GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
        new MimicDoor(levelGrid, spawnPosition, player, keysToCollect);
    }
}