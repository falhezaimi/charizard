namespace Cpsc370Final;
using Cpsc370Final.Core;

public static class GameUI
{
    public static int FloorNumber { get; private set; } = 1; // Tracks the current floor

    public static void IncreaseFloor()
    {
        FloorNumber++;
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
}