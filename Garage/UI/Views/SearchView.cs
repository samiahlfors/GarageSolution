using Garage.Application;
using Garage.Domain;

namespace Garage.UI.Views;

public class SearchView(AppState state, Navigation navigation) : View
{
    public override string Title => "Search";
    public override void Render()
    {
        while (true)
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

            if (!Validator.TryParseLicencePlate(input, out var licencePlate))
            {
                Console.WriteLine($"Invalid format of licence plate {input}");
                Menu.Pause();
                continue;
            }
            
            var result = FindVehicle(licencePlate);
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
        }
    }

    private (Vehicle vehicle, Garage<Vehicle> garage)? FindVehicle(string licencePlate)
    {
        foreach (var garage in state.Garages)
        {
            var handler = new GarageHandler<Vehicle>(garage);
            var vehicle = handler.FindVehicle(licencePlate);
            if (vehicle != null)
            {
                return (vehicle, garage);
            }
        }

        return null;
    }
}