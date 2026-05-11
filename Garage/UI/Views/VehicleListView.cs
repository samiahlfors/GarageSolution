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
            Console.WriteLine($"{i + 1} - {vehicle.LicensePlate}");
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
                /*
                var garage = state.Garages[choice - 1];
                state.SetCurrentGarage(garage);
                
                navigation.NavigateTo(new GarageView(state, navigation));
                */
                break;
        }
    }
}