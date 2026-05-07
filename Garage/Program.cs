using Garage.Domain;
using Garage.Domain.Vehicles;
using Garage.Views;

namespace Garage;

class Program
{
    private static List<Domain.Garage> _garages = [];
    
    static void Main(string[] args)
    {
        Initialize();
        
        View? currentView = new MainMenuView();

        while (currentView != null)
        {
            currentView = currentView.Render();
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
}