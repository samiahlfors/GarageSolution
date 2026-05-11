using Garage.Application;
using Garage.Domain;

namespace Garage.Views;

public class VehicleView(AppState state, Navigation navigation, Vehicle vehicle) : View
{
    public override string Title => "Vehicle";
    public override void Render()
    {
        RenderHeader();
        
        Console.WriteLine($"So, {vehicle.LicensePlate}");
        
        Console.WriteLine();
        
        var menu = new Menu("Menu", [
            "1 - Remove Vehicle from Parking Spot",
            "0 - Go back"
        ]);
        menu.Show();

        var choice = ConsoleInput.GetInt();
        
        switch (choice)
        {
            case 1:
                if (new ConfirmationView().Confirm("Remove vehicle?", "Are you sure you want to remove this vehicle from the parking spot?"))
                {
                    var parkingSpot = state.CurrentGarage.GetParkingSpot(vehicle);
                    state.CurrentGarage.RemoveVehicle(parkingSpot);
                    navigation.GoBackToMainMenu(state);
                }
                break;
            case 0:
                navigation.GoBack();
                break;
            default: break;
        }
    }
}