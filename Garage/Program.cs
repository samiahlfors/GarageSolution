using Garage.Application;
using Garage.Domain;
using Garage.Domain.Vehicles;
using Garage.Views;

namespace Garage;

class Program
{
    static void Main(string[] args)
    {
        var appState = new AppState();
        
        Initialize(appState);
        
        View? currentView = new MainMenuView(appState);

        while (currentView != null)
        {
            currentView = currentView.Render();
        }
    }

    private static void Initialize(AppState appState)
    {
        var garage = new Domain.Garage("Globengaraget", 5);
        appState.AddGarage(garage);
        
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