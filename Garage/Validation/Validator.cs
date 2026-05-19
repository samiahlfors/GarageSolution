using System.Text.RegularExpressions;

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

    public static bool TryParseLicencePlate(string input, out string? result)
    {
        /*
         * The validation is not true to a real-world scenario.
         * It's expecting the licence plate to be in a XXX### format.
         * There's both XXX##X and custom ones, as well as a whole world of international plates.
         */
        if (input.Length != 6 || !Regex.IsMatch(input.ToLower(), @"^[a-z]{3}[0-9]{3}$"))
        {
            result = null;
            return false;
        }

        result = input;
        return true;
    }
}