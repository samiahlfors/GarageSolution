using Garage.Application;
using Garage.Domain.Enums;

namespace Garage.UI.Views;

public class FilterView(AppState state, Navigation navigation) : View
{
    public override string Title => "Filter";
    public override void Render()
    {
        var filter = new VehicleFilter();
        
        var running = true;

        while (running)
        {
            RenderHeader();
            
            RenderActiveFilters(filter);
            
            // Options
            Console.WriteLine("Choose filter:");
            Console.WriteLine("1 - Add color filter");
            Console.WriteLine("2 - Add brand filter");
            Console.WriteLine("3 - Add type filter");
            Console.WriteLine("8 - Show matching vehicles");
            Console.WriteLine("9 - Clear filter");
            Console.WriteLine("0 - Go back");
            
            var choice = ConsoleInput.GetInt();

            switch (choice)
            {
                case 1:
                    AddColorFilter(filter);
                    break;
                
                case 2:
                    AddBrandFilter(filter);
                    break;

                case 8:
                    ShowVehicles(filter);
                    break;
                
                case 9:
                    ClearFilter(filter);
                    break;

                case 0:
                    running = false;
                    navigation.GoBack();
                    break;
            }
        }
    }
    
    private void RenderActiveFilters(VehicleFilter filter)
    {
        Console.WriteLine("Current filters:");
        Console.WriteLine(filter.Colors.Count == 0 ? "- No color filters" : $"- Colors: {string.Join(", ", filter.Colors)}");
        Console.WriteLine(filter.Brands.Count == 0 ? "- No brand filters" : $"- Brands: {string.Join(", ", filter.Brands)}");

        Console.WriteLine();
    }
    
    private void AddColorFilter(VehicleFilter filter)
    {
        Console.Clear();
        Console.WriteLine("Pick a color:");

        RenderColorPicker();

        var color = (VehicleColor)ConsoleInput.GetInt();
        filter.Colors.Add(color);
    }

    private void AddBrandFilter(VehicleFilter filter)
    {
        Console.Clear();
        Console.WriteLine("Filter by brand:");
        
        var brand = ConsoleInput.GetString(false);
        filter.Brands.Add(brand);
    }
    
    private void ShowVehicles(VehicleFilter filter)
    {
        Console.Clear();
        Console.WriteLine("Vehicles matching filters:");
        
        // List vehicles
        var query = state.GetAllVehicles();

        if (filter.Colors.Any())
        {
            query = query.Where(v => filter.Colors.Contains(v.Color));
        }

        if (filter.Brands.Any())
        {
            query = query.Where(v => filter.Brands.Contains(v.Brand));
        }
        
        var result = query.ToList();
        var index = 1;
        foreach (var vehicle in result)
        {
            Console.WriteLine($"{index++}: {vehicle.Brand} {vehicle.Model}, a {vehicle.Color.ToString().ToLower()} {vehicle.VehicleType.ToString().ToLower()} with licence plate {vehicle.LicencePlate}");
        }
        
        Menu.Pause();
    }

    private void RenderColorPicker()
    {
        var options = Enum.GetValues<VehicleColor>();

        foreach (var color in options)
        {
            Console.WriteLine($"{(int)color} - {color}");
        }
    }
    
    private void ClearFilter(VehicleFilter filter)
    {
        Console.Clear();
        filter.Clear();
        
        Console.WriteLine("Filter cleared!");
        Menu.Pause();
    }
}