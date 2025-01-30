namespace Cpsc370Final;
using Cpsc370Final.Entities;
using Cpsc370Final.Objects;

class Program
{
    private static GameObject[,] worldGrid;
    private static List<GameObject> gameObjects = new List<GameObject>();
    private static Random rand = new Random();

    private static Player player;
    private static Door exitDoor;

    private static void Main(string[] args)
    {
        GenerateMap();

        while (true)
        {
            Render();
            Console.WriteLine("\nEnter a command (W/A/S/D to move):");
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
        worldGrid = new GameObject[10, 20];

        // Initialize empty grid
        for (int i = 0; i < worldGrid.GetLength(0); i++)
        {
            for (int j = 0; j < worldGrid.GetLength(1); j++)
            {
                worldGrid[i, j] = null;
            }
        }

        // Spawn all entities
        SpawnPlayer();
        SpawnGoblins();
        SpawnSkeletons();
        SpawnWraiths();
        SpawnKey();
        SpawnDoor();
    }

    private static void SpawnPlayer()
    {
        int middleX = worldGrid.GetLength(1) / 2;
        int middleY = worldGrid.GetLength(0) / 2;
        player = new Player(worldGrid, middleX, middleY);
        gameObjects.Add(player);
    }

    private static void SpawnGoblins()
    {
        for (int i = 0; i < 3; i++) // Adjust number as needed
        {
            SpawnRandomEntity(new Goblin(worldGrid, 0, 0));
        }
    }

    private static void SpawnSkeletons()
    {
        for (int i = 0; i < 2; i++) // Adjust number as needed
        {
            SpawnRandomEntity(new Skeleton(worldGrid, 0, 0));
        }
    }

    private static void SpawnWraiths()
    {
        for (int i = 0; i < 1; i++) // Adjust number as needed
        {
            SpawnRandomEntity(new Wraith(worldGrid, 0, 0));
        }
    }

    private static void SpawnKey()
    {
        SpawnRandomEntity(new Key(worldGrid, 0, 0));
    }

    private static void SpawnDoor()
    {
        exitDoor = new Door(worldGrid, rand.Next(1, worldGrid.GetLength(1) - 1), rand.Next(1, worldGrid.GetLength(0) - 1));
        gameObjects.Add(exitDoor);
    }

    private static void SpawnRandomEntity(GameObject entity)
    {
        int x, y;
        do
        {
            x = rand.Next(1, worldGrid.GetLength(1) - 1);
            y = rand.Next(1, worldGrid.GetLength(0) - 1);
        } while (worldGrid[y, x] != null); // Ensure it spawns in an empty location

        entity.positionX = x;
        entity.positionY = y;
        worldGrid[y, x] = entity;
        gameObjects.Add(entity);
    }

    private static void ProcessCommand(string command)
    {
        command = command.ToLower().Trim();

        if (command == "w") MovePlayer(Direction.North);
        else if (command == "a") MovePlayer(Direction.West);
        else if (command == "s") MovePlayer(Direction.South);
        else if (command == "d") MovePlayer(Direction.East);
    }

    private static void MovePlayer(Direction direction)
    {
        int newX = player.positionX;
        int newY = player.positionY;

        switch (direction)
        {
            case Direction.North: newY -= 1; break;
            case Direction.South: newY += 1; break;
            case Direction.East: newX += 1; break;
            case Direction.West: newX -= 1; break;
        }

        // Prevent moving out of bounds
        if (newX < 0 || newX >= worldGrid.GetLength(1) || newY < 0 || newY >= worldGrid.GetLength(0))
        {
            return;
        }

        GameObject destinationObject = worldGrid[newY, newX];

        if (destinationObject is Key)
        {
            player.CollectKey();
            gameObjects.Remove(destinationObject);
            worldGrid[newY, newX] = null;
        }
        else if (destinationObject is Door && player.HasKey)
        {
            Console.Clear();
            Console.WriteLine("You escaped the dungeon! You win!");
            Environment.Exit(0);
        }
        else if (destinationObject is Goblin || destinationObject is Skeleton || destinationObject is Wraith)
        {
            Console.Clear();
            Console.WriteLine("You were caught by a monster! Game Over.");
            Environment.Exit(0);
        }

        // Move player
        worldGrid[player.positionY, player.positionX] = null;
        player.positionX = newX;
        player.positionY = newY;
        worldGrid[newY, newX] = player;
    }

    private static void Render()
    {
        Console.Clear();
        Console.WriteLine("Dungeon Escape:\n");

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