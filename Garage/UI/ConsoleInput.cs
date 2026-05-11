namespace Garage;

public static class ConsoleInput
{
    public static int GetInt(bool newLine = true)
    {
        while (true)
        {
            if (newLine) Console.Write("> ");
            var input = Console.ReadLine();

            if (Validator.TryParseInt(input, out var result))
            {
                return result;
            }
            
            Log.Error($"Invalid input: {input}");
        }
    }

    public static string GetString(bool newLine = true)
    {
        while (true)
        {
            if (newLine) Console.Write("> ");
            var input = Console.ReadLine();

            if (Validator.TryParseString(input, out var result))
            {
                return result;
            }
            
            Log.Error($"Invalid input: {input}");
        }
    }
}