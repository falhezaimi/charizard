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
}