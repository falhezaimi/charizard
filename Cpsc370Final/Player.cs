﻿namespace Cpsc370Final;

public class Player : GameObject
{
    public Player(GameObject[,] worldGrid, int spawnPositionX, int spawnPositionY) : base(worldGrid, spawnPositionX,
        spawnPositionY)
    {
    }

    public override char GetAsciiCharacter() => 'P';
    public override ConsoleColor GetAsciiColor() => ConsoleColor.White;

    public override void PerformTurnAction()
    {
        // Player doesn't actually do anything on turn action, their actions are differently as a special case
    }
}