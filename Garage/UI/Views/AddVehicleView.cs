using Garage.Application;
using Garage.Domain;
using Garage.Domain.Enums;

namespace Garage.Views;

public class AddVehicleView(AppState state, Navigation navigation) : View
{
    public override string Title => "Add Vehicle";
    public override void Render()
    {
        RenderHeader();
        
        // Get type
        RenderSubMenu(1);
        var type = ConsoleInput.GetInt();
        
        Console.Clear();
        
        // Get Licence Plate
        Console.Write($"Enter Licence Plate: ");
        var licencePlate = ConsoleInput.GetString(false);
        
        // Get Brand
        Console.Write($"Enter Brand: ");
        var brand =  ConsoleInput.GetString(false);
        
        // Get Model
        Console.Write($"Enter Model: ");
        var model =  ConsoleInput.GetString(false);
        
        // Get Colour
        Console.Clear();
        RenderSubMenu(2);
        var color = (VehicleColor)ConsoleInput.GetInt();
        
        // Instantiate new vehicle
        var vehicle = Vehicle.CreateVehicle(type);
        vehicle.LicencePlate = licencePlate;
        vehicle.Model = model;
        vehicle.Brand = brand;
        vehicle.Color = color;
        
        // Park vehicle in garage
        state.CurrentGarage.ParkVehicle(vehicle);
        
        Console.WriteLine($"Vehicle: {licencePlate} parked in {state.CurrentGarage.Name}");
        Menu.Pause();
        
        navigation.GoBack();
    }
    
    private static void RenderSubMenu(int step)
    {
        var title = "";
        var options = new List<string>();
        
        switch (step)
        {
            case 1:
                title = "Choose type";
                options.Add("1 - Car");
                options.Add("2 - Bus");
                options.Add("3 - Motorcycle");
                options.Add("4 - Boat");
                options.Add("5 - Airplane");
                break;
            case 2:
                title = "Choose colour";
                foreach (var color in Enum.GetValues<VehicleColor>())
                {
                    options.Add($"{(int)color} - {color}");
                }
                break;
            default: break;
        }
        
        var menu = new Menu(title, options);
        menu.Show();
    }
}