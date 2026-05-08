using Garage.Application;

namespace Garage.Views;

public class GarageView(AppState state, View previousView) : View
{
    public override string Title => "Garage";
    public override View? Render()
    {
        // Return a view of a specific garage
        
        RenderHeader();
        
        Console.WriteLine($"Welcome to: {state.CurrentGarage.Name}");
        Console.WriteLine($"We have {state.CurrentGarage.Capacity} spots");
        
        var menu = new Menu("Menu", [
            "0 - Back"
        ]);
        menu.Show();

        var choice = ConsoleInput.GetInt();
        
        return choice switch
        {
            0 => previousView,
            _ => this
        };
    }
}