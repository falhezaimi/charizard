using System.Runtime.InteropServices;

namespace Cpsc370Final.Core;

public class ConsoleHelper
{
    // A lot of this code was taken from https://learn.microsoft.com/en-us/answers/questions/1275773/how-to-resize-a-console-app-in-c-windows-terminal
    
    // Structure used by GetWindowRect
    private struct Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
    
    // Get the handle of the console window
    private static IntPtr consoleWindowHandle = GetForegroundWindow();
    
    // Import the necessary functions from user32.dll
    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();
    
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    // Constants for the ShowWindow function
    private static readonly int SW_NORMAL = 1;
    private static readonly int SW_MAXIMIZE = 3;

    [DllImport("user32.dll")]
    private static extern bool IsZoomed(IntPtr hWnd);
    
    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);
    
    [DllImport("user32.dll")]
    private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);
    
    public static void ToggleFullScreen()
    {
        if (IsInFullScreen())
        {
            ShowWindow(consoleWindowHandle, SW_NORMAL);
        }
        else
        {
            ShowWindow(consoleWindowHandle, SW_MAXIMIZE);
        }
        Console.WriteLine($"LargestWidth: {Console.LargestWindowWidth} + LargestHeight: {Console.LargestWindowHeight}");
    }

    public static bool IsInFullScreen()
    {
        return IsZoomed(consoleWindowHandle);
    }    
}
