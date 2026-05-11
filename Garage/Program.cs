using Garage.Application;
using Garage.Domain.Enums;
using Garage.Domain.Vehicles;
using Garage.Views;

namespace Garage;

class Program
{
    static void Main(string[] args)
    {
        var appState = new AppState();
        var navigation = new Navigation();
        
        Initialize(appState);
        
        navigation.NavigateTo(new MainMenuView(appState, navigation));

        while (navigation.CurrentView != null)
        {
            navigation.CurrentView.Render();
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
            Color = VehicleColor.Black,
            NumberOfWheels = 4,
            LicensePlate = "ABC123"
        };
        
        garage.ParkVehicle(car);
    }
}