﻿namespace Cpsc370Final;
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
            // Display the UI with Floor Number
            GameUI.DisplayUI(levelGrid);
            
            Console.WriteLine("\nEnter a command (W/A/S/D to move):");
            string command = Console.ReadLine();
            player.ProcessCommand(command);
            levelGrid.PerformGameObjectTurnActions();
        }
    }

    private static void NextFloor()
    {
        GameUI.IncreaseFloor(); // Increase the floor number
        GameUI.DisplayMessage($"You completed Floor {GameUI.FloorNumber - 1}! Onto Floor {GameUI.FloorNumber}.");

        GenerateMap(); // Generate a new dungeon floor
    }

    private static void EndGame()
    {
        Console.Clear();
        Console.WriteLine("\nGame Over! Press any key to return to Main Menu...");
        gameOver = true;
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
        GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
        if (player == null)
        {
            // Create the player for the first time
            player = new Player(levelGrid, spawnPosition);
        }
        else
        {
            // If player already exists, just reposition him
            // the player needs to be preserved between levels
            player.position = spawnPosition;
            player.levelGrid = levelGrid;
            levelGrid.AddGameObjectToGrid(player);
        }
    }
    
    private static void SpawnGoblins()
    {
        for (int i = 0; i < 5; i++)
        {
            GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
            GameObject goblin = new Goblin(levelGrid, spawnPosition);
        }
    }

    private static void SpawnSkeletons()
    {
        for (int i = 0; i < 2; i++)
        {
            GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
            GameObject skeleton = new Skeleton(levelGrid, spawnPosition);
        }
    }

    private static void SpawnWraiths()
    {
        for (int i = 0; i < 1; i++)
        {
            GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
            GameObject wraith = new Wraith(levelGrid, spawnPosition, player);
        }
    }

    private static void SpawnKey()
    {
        GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
        Key key = new Key(levelGrid, spawnPosition);
    }

    private static void SpawnDoor()
    {
        GridPosition spawnPosition = levelGrid.GetRandomEmptyPosition();
        exitDoor = new Door(levelGrid, spawnPosition);
    }
}