namespace Cpsc370Final;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
            Console.WriteLine("Usage: Cpsc370Final <arguments>");
        
        // you can delete this if/when you like
        ShowArguments(args);
    }

    // this is just an example of how to get the command
    // line arguments so you can use them
    private static void ShowArguments(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine("  Argument " + i +": " + args[i]);
        }
    }
}