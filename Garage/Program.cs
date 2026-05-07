namespace Garage;

class Program
{
    static void Main(string[] args)
    {
        var running = true;

        while (running)
        {
            running = ShowMenu();
        }
    }
    
    private static bool ShowMenu()
    {
        Console.Clear();
        Console.WriteLine($"-- MAIN MENU --");

        var menu = new Menu("Choose an option", [
            
            "0 - Exit"
        ]);
        menu.Show();
        
        var choice = ConsoleInput.GetInt();
        
        switch (choice)
        {
            case 0: return false;
            default: return true;
        }
    }
}