namespace Garage.Application.Services;

public static class StorageService
{
    private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "data.json");
    
    public static string Load()
    {
        var json = File.ReadAllText(FilePath);

        return json;
    }
}