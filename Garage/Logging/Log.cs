namespace Garage;

public static class Log
{
    private static void Print(string prefix, string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write($"{prefix}: ");
        Console.ResetColor();
        
        Console.WriteLine(message);
    }

    public static void Error(string message)
    {
        Print("Error", message, ConsoleColor.Red);
    }
}