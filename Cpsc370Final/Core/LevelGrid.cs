namespace Cpsc370Final.Core;

public class LevelGrid
{
    private GameObject[,] levelGrid;
    private List<GameObject> gameObjects = new List<GameObject>();
    Random random = new Random();

    public LevelGrid(int width, int height)
    {
        levelGrid = new GameObject[height, width];
        for (int x = 0; x < GetWidth(); x++)
        {
            for (int y = 0; y < GetHeight(); y++)
            {
                GridPosition position = new GridPosition(x, y);
                SetGameObjectAtPosition(position, null);
            }
        }
    }

    public void AddGameObjectToGrid(GameObject gameObject)
    {
        SetGameObjectPosition(gameObject, gameObject.position);
        gameObjects.Add(gameObject);
    }

    public void RemoveGameObjectFromGrid(GameObject gameObject)
    {
        SetGameObjectAtPosition(gameObject.position, null);
        gameObjects.Remove(gameObject);
    }

    public void SetGameObjectPosition(GameObject gameObject, GridPosition newPosition)
    {
        int oldX = gameObject.position.x;
        int oldY = gameObject.position.y;
        
        levelGrid[oldY, oldX] = null;
        levelGrid[newPosition.y, newPosition.x] = gameObject;
        
        gameObject.position.x = newPosition.x;
        gameObject.position.y = newPosition.y;
    }

    public GameObject GetGameObjectAtPosition(GridPosition position)
    {
        return levelGrid[position.y, position.x];
    }

    private void SetGameObjectAtPosition(GridPosition position, GameObject gameObject)
    {
        levelGrid[position.y, position.x] = gameObject;
    }
    
    public bool IsPositionInBounds(GridPosition position)
    {
        bool positionXInBounds = position.x >= 0 && position.x < GetWidth();
        bool positionYInBounds = position.y >= 0 && position.y < GetHeight();
        return positionXInBounds && positionYInBounds;
    }
    public bool IsPositionEmpty(GridPosition position)
    {
        return GetGameObjectAtPosition(position) == null;
    }
    public bool IsPositionOccupied(GridPosition position)
    {
        return GetGameObjectAtPosition(position) != null;
    }

    public GridPosition GetRandomEmptyPosition()
    {
        GridPosition randomPosition = new GridPosition();
        do
        {
            randomPosition.x = random.Next(0, GetWidth());
            randomPosition.y = random.Next(0, GetHeight());
        } while (IsPositionOccupied(randomPosition));
        return randomPosition;
    }

    public void Render()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("/  ");
        for (int i = 0; i < GetWidth(); i++)
        {
            Console.Write("-  ");
        }
        Console.WriteLine("\\");
        
        for (int y = 0; y < GetHeight(); y++)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|  ");
            for (int x = 0; x < GetWidth(); x++)
            {
                GameObject gameObject = levelGrid[y, x];
                if (gameObject != null)
                {
                    Console.ForegroundColor = gameObject.GetAsciiColor();
                    Console.Write(gameObject.GetAsciiCharacter());
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write('.');
                }
                Console.Write("  ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");
            Console.WriteLine();
        }
        
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("\\  ");
        for (int i = 0; i < GetWidth(); i++)
        {
            Console.Write("-  ");
        }
        Console.Write("/");
    }
    
    public int GetWidth() => levelGrid.GetLength(1);
    public int GetHeight() => levelGrid.GetLength(0);
    public List<GameObject> GetGameObjects() => gameObjects;
}