namespace Cpsc370Final;

public class LevelGrid
{
    private static GameObject[,] levelGrid;
    private static List<GameObject> gameObjects = new List<GameObject>();

    public LevelGrid(int width, int height)
    {
        levelGrid = new GameObject[height, width];
        for (int x = 0; x < GetWidth(); x++)
        {
            for (int y = 0; y < GetHeight(); y++)
            {
                SetGameObjectAtPosition(x, y, null);
            }
        }
    }

    public void AddGameObjectToGrid(GameObject gameObject)
    {
        levelGrid[gameObject.positionY, gameObject.positionX] = gameObject;
        gameObjects.Add(gameObject);
    }

    public void MoveGameObject(GameObject gameObject, int newX, int newY)
    {
        int oldX = gameObject.positionX;
        int oldY = gameObject.positionY;
        
        levelGrid[oldY, oldX] = null;
        levelGrid[newY, newX] = gameObject;
        
        gameObject.positionX = newX;
        gameObject.positionY = newY;
    }

    public GameObject GetGameObjectAtPosition(int x, int y)
    {
        return levelGrid[y, x];
    }

    private void SetGameObjectAtPosition(int x, int y, GameObject gameObject)
    {
        levelGrid[y, x] = gameObject;
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