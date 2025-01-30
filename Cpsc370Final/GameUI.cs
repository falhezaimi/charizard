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
        Console.WriteLine($"Floor: {FloorNumber}\tKeys: {player.HeldKeys}/{keysToCollect}");

        // Renders the level grid
        levelGrid.Render();
    }

    public static void DisplayMessage(string message)
    {
        Console.WriteLine($"\n{message}");
    }
}