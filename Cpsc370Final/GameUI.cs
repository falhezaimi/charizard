namespace Cpsc370Final;
using Cpsc370Final.Core;

public static class GameUI
{
    public static int FloorNumber { get; private set; } = 1;
    private static int MaxFloors = 14; // Define the max floor count

    public static void IncreaseFloor()
    {
        if (FloorNumber < MaxFloors)
        {
            FloorNumber++;
        }
    }

    public static void SetFloor(int newFloorNumber)
    {
        FloorNumber = newFloorNumber;
    }

    public static bool IsFinalFloor()
    {
        return FloorNumber == MaxFloors;
    }

    public static void DisplayUI(LevelGrid levelGrid, Player player, int keysToCollect)
    {
        Console.Clear();
        Console.Write($"Floor: {FloorNumber}\t");

        Console.ForegroundColor = (player.HeldKeys >= keysToCollect) ? ConsoleColor.Magenta : ConsoleColor.Gray;
        Console.Write($"Keys: {player.HeldKeys}/{keysToCollect}\n");

        // Renders the level grid
        levelGrid.Render();
    }

    public static void DisplayMessage(string message)
    {
        Console.WriteLine($"\n{message}");
    }

    public static void DisplayCompletionMessage()
    {
        Console.Clear();
        Console.WriteLine("\n🎉 You completed ROG! 🎉\n");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
    public static void DisplayStartScreen()
    {
        Console.Clear();
        Console.WriteLine("\n  ____   ___   ____ \n|  _ \\ / _ \\ / ___|\n| |_) | | | | |  _ \n|  _ <| |_| | |_| |\n|_| \\_\\\\___/ \\____|");
        Console.WriteLine("\nWelcome to ROG, a text-based, ASCII-styled dungeon crawler!\n\nYour goal is to delve through randomly generated floors,\ncollect keys, and dash for the door while surviving encounters\nwith the dangerous monsters.");
        Console.WriteLine("\nType 'start' to play...\n");

        string input = string.Empty;
        while (input.ToLower() != "start")
        {
            Console.Write("");
            input = Console.ReadLine();
            if (input.ToLower() != "start")
            {
                Console.WriteLine("Invalid input. Please type 'start' to begin the game.");
            }
        }

        Console.Clear();
    }
}