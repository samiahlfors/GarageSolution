namespace Garage;

public static class Validator
{
    public static bool TryParseInt(string input, out int result)
    {
        return int.TryParse(input, out result);
    }

    public static bool TryParseString(string input, out string? result)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            result = null;
            return false;
        }

        result = input;
        
        return true;
    }
}