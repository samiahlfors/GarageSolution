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
            "0 - Go back"
        ]);
        menu.Show();

        var choice = ConsoleInput.GetInt();
        
        switch (choice)
        {
            case 0:
                navigation.GoBack();
                break;
            default: break;
        }
    }
}