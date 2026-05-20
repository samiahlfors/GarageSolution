namespace Garage.Application.Helpers;

public static class StringExtensions
{
    public static string ToLicencePlateFormat(this string? input)
    {
        return string.IsNullOrWhiteSpace(input) ? string.Empty : $"{input.Substring(0, 3)}-{input.Substring(3)}";
    }
}