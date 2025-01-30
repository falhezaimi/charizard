namespace Cpsc370Final.Core;

public struct GridPosition : IEquatable<GridPosition>
{
    public int x;
    public int y;

    public GridPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static float Distance(GridPosition a, GridPosition b)
    {
        int distanceX = Math.Abs(a.x - b.x);
        int distanceZ = Math.Abs(a.y - b.y);
        int distance = distanceX + distanceZ;
        return distance;
    }

    public override string ToString()
    {
        return $"({x}, {y})";
    }

    public override bool Equals(object obj)
    {
        return obj is GridPosition gridPosition && gridPosition == this;
    }

    public bool Equals(GridPosition other)
    {
        return this == other;
    }

    public override readonly int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }

    public static GridPosition operator +(GridPosition a, GridPosition b)
    {
        return new GridPosition(a.x + b.x, a.y + b.y);
    }

    public static GridPosition operator -(GridPosition a, GridPosition b)
    {
        return new GridPosition(a.x - b.x, a.y - b.y);
    }

    public static GridPosition operator *(int a, GridPosition b)
    {
        return new GridPosition(a * b.x, a * b.y);
    }
    
    public static GridPosition operator /(GridPosition b, int a)
    {
        return new GridPosition(b.x / a, b.y / a);
    }

    public static bool operator ==(GridPosition a, GridPosition b)
    {
        return a.x == b.x && a.y == b.y;
    }

    public static bool operator !=(GridPosition a, GridPosition b)
    {
        return a.x != b.x || a.y != b.y;
    }
}