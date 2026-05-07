using Garage.Domain;
using Garage.Domain.Vehicles;

namespace Garage;

class Program
{
    private static List<Domain.Garage> _garages = [];
    
    static void Main(string[] args)
    {
        Initialize();
        
        var running = true;

        while (running)
        {
            running = ShowMenu();
        }
    }

    private static void Initialize()
    {
        var garage = new Domain.Garage("Globengaraget", 5);
        _garages.Add(garage);

        var car = new Car
        {
            Brand = "Audi",
            Model = "A4",
            Color = "Red",
            NumberOfWheels = 4,
            LicensePlate = "ABC123"
        };
        
        garage.ParkVehicle(car);
    }
    
    private static bool ShowMenu()
    {
        Console.Clear();
        Console.WriteLine($"-- MAIN MENU --");

        var menu = new Menu("Choose an option", [
            "1 - List Garages",
            "0 - Exit"
        ]);
        menu.Show();
        
        var choice = ConsoleInput.GetInt();
        
        switch (choice)
        {
            case 1:
                _garages[0].GetVehicles();
                
                Menu.Pause();
                
                return true;
            case 0: return false;
            default: return true;
        }
    }
}