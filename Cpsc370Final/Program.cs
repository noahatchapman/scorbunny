namespace Cpsc370Final;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            ShowArguments(args);
        }

        // Start the Pokemon Battle Game
        Game game = new Game();
        game.startGame();
    }

    private static void ShowArguments(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine("  Argument " + i + ": " + args[i]);
        }
    }
}