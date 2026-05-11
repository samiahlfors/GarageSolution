using Garage.Application;
using Garage.Domain;

namespace Garage.Views;

public class SearchView(AppState state, Navigation navigation) : View
{
    public override string Title => "Search";
    public override void Render()
    {
        RenderHeader();
        
        Console.WriteLine($"0 to exit");
        Console.Write($"Enter Licence Plate number: ");
        var input = ConsoleInput.GetString(false);

        if (input == "0")
        {
            navigation.GoBack();
            return;
        }
        
        var result = FindVehicle(input);
        if (result == null)
        {
            Console.Clear();
            Console.WriteLine($"Could not find vehicle");
            
            Menu.Pause();
            return;
        }

        var (vehicle, garage) = result.Value;
        
        state.SetCurrentGarage(garage);
        navigation.NavigateTo(new VehicleView(state, navigation, vehicle));
        
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

    private (Vehicle vehicle, Domain.Garage garage)? FindVehicle(string licencePlate)
    {
        foreach (var garage in state.Garages)
        {
            var vehicle = garage.FindVehicle(licencePlate);
            if (vehicle != null)
            {
                return (vehicle, garage);
            }
        }

        return null;
    }
}