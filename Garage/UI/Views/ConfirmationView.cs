namespace Garage.Views;

public class ConfirmationView
{
    public bool Confirm(string title, string message)
    {
        Console.Clear();
        
        Console.WriteLine(title);
        Console.WriteLine(message);
        
        Console.WriteLine("Y/N");
        
        var input = ConsoleInput.GetString();
        
        return input?.ToLower() == "y";
    }
}