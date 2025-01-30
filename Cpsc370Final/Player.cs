﻿namespace Cpsc370Final;
using Cpsc370Final.Core;

public class Player : GameObject
{
    public event Action OnDied;
    public event Action OnEnteredDoor;
    public event Action OnCollectedKey;
    public Player(LevelGrid levelGrid, GridPosition spawnPosition) : base(levelGrid, spawnPosition)
    {
    }
    public int HeldKeys { get; private set; } = 0; // ✅ Tracks if the player has picked up a key

    public override char GetAsciiCharacter() => 'P';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.White;
    public override DetectionTag GetDetectionTag() => DetectionTag.Player;

    public override void PlayerInteraction(Player player)
    {
        // Player doesn't interact with itself
    }

    public void Move(Direction moveDirection)
    {
        GridPosition desiredPosition = position + GetDirectionOffset(moveDirection);

        if (!DetectInDirection(DetectionTag.Empty, moveDirection))
        {
            GameObject gameObject = GetGameObjectInDirection(moveDirection);
            if (gameObject != null) gameObject.PlayerInteraction(this);
        }

        if (CanMoveInDirection(moveDirection))
        {
            levelGrid.SetGameObjectPosition(this, desiredPosition);
        }
    }

    public void ProcessCommand(string command)
    {
        command = command.ToLower();
        command = command.Trim();

        if (command == "w") Move(Direction.North);
        else if (command == "a") Move(Direction.West);
        else if (command == "s") Move(Direction.South);
        else if (command == "d") Move(Direction.East);
    }

    public override void PerformTurnAction()
    {
        // Players don't act automatically, so no need for an AI action.
    }

    public void AddKey()
    {
        HeldKeys++;
    }

    public void ResetKeys()
    {
        HeldKeys = 0;
    }

    public void EnterDoor()
    {
        OnEnteredDoor?.Invoke();
    }

    public void Kill()
    {
        levelGrid.RemoveGameObjectFromGrid(this);
        OnDied?.Invoke();
    }
}