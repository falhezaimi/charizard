namespace Cpsc370Final.InputReader;

using InputMap = Dictionary<ConsoleKey, InputAction>;

public enum InputAction
{
    Up,
    Down,
    Left,
    Right,
        
    Interact,
    Ability,
    Back,
        
    Unknown,
}

public enum InputMode
{
    Computer,
    Arcade
}

public static class InputReader
{
    private static InputMode currentInputMode = InputMode.Computer;
    
    public static void SetInputMode(InputMode inputMode) => currentInputMode = inputMode;

    public static InputAction ReadNextInput()
    {
        ConsoleKey consoleKey = Console.ReadKey(true).Key;
        return GetInputActionForKey(consoleKey);
    }

    public static InputAction WaitForButtonPress()
    {
        while (true)
        {
            InputAction action = ReadNextInput();
            if (IsButtonInput(action)) return action;
        }
    }

    private static InputMap computerInputMap = new InputMap()
    {
        {ConsoleKey.UpArrow, InputAction.Up},
        {ConsoleKey.DownArrow, InputAction.Down},
        {ConsoleKey.LeftArrow, InputAction.Left},
        {ConsoleKey.RightArrow, InputAction.Right},
        {ConsoleKey.Enter, InputAction.Interact},
        {ConsoleKey.Spacebar, InputAction.Ability},
        {ConsoleKey.Escape, InputAction.Back}
    };
    
    // Note, for the arcade machine, only the Space, X, Z, V, and C buttons can be read
    private static InputMap arcadeInputMap = new InputMap()
    {
        { ConsoleKey.UpArrow, InputAction.Up },
        { ConsoleKey.DownArrow, InputAction.Down },
        { ConsoleKey.LeftArrow, InputAction.Left },
        { ConsoleKey.RightArrow, InputAction.Right },
        { ConsoleKey.Spacebar, InputAction.Interact },
        { ConsoleKey.X, InputAction.Ability },
        { ConsoleKey.Z, InputAction.Back }
    };
    
    private static InputAction GetInputActionForKey(ConsoleKey consoleKey)
    {
        InputMap inputMap;
        switch (currentInputMode)
        {
            case InputMode.Computer: inputMap = computerInputMap; break;
            case InputMode.Arcade: inputMap = arcadeInputMap; break;
            default: inputMap = computerInputMap; break;
        }

        return inputMap.GetValueOrDefault(consoleKey, InputAction.Unknown);
    }

    private static bool IsButtonInput(InputAction action)
    {
        return action != InputAction.Up
               && action != InputAction.Down
               && action != InputAction.Left
               && action != InputAction.Right;
    }
}