namespace Garage;

public static class ConsoleInput
{
    public static int GetInt()
    {
        while (true)
        {
            var input = Console.ReadLine();

            if (Validator.TryParseInt(input, out var result))
            {
                return result;
            }
            
            Log.Error($"Invalid input: {input}");
        }
    }

    public static string GetString()
    {
        while (true)
        {
            var input = Console.ReadLine();

            if (Validator.TryParseString(input, out var result))
            {
                return result;
            }
            
            Log.Error($"Invalid input: {input}");
        }
    }
}