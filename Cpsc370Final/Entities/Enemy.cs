namespace Cpsc370Final.Entities;

public abstract class Enemy : GameObject
{
    public Enemy(GameObject[,] worldGrid, int x, int y) : base(worldGrid, x, y) { }

    public abstract void Move(Player player);

    // Utility method to move enemies in a given direction
    protected void MoveInDirection(Direction direction)
    {
        if (CanMoveInDirection(direction))
        {
            Move(direction);
        }
    }

    // Default behavior: move automatically every turn
    public override void PerformTurnAction()
    {
        Move(null);
    }
}