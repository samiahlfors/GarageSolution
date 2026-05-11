using Garage.Application;

namespace Garage.Views;

public class VehicleListView(AppState state, Navigation navigation) : View
{
    public override string Title => "List of Vehicles";
    public override void Render()
    {
        RenderHeader();
        
        var garage = state.CurrentGarage;
        var vehicles = garage.GetVehicles();

        for (var i = 0; i < vehicles.Length; i++)
        {
            var vehicle = vehicles[i];
            Console.WriteLine($"{i + 1} - {vehicle.LicencePlate}");
        }
        
        Console.WriteLine();
        
        var menu = new Menu("Menu", [
            "0 - Go back"
        ]);
        menu.Show();

        var choice = ConsoleInput.GetInt();
        
        switch (choice)
        {
            case 0:
                navigation.GoBack();
                break;
            default:
                var vehicle = state.CurrentGarage.FindVehicle(vehicles[choice - 1].LicencePlate);
                navigation.NavigateTo(new VehicleView(state, navigation, vehicle));
                break;
        }
    }
}