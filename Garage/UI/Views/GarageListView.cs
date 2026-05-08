using Garage.Application;

namespace Garage.Views;

public class GarageListView(AppState state, View previousView) : View
{
    public override string Title => "List of Garages";
    public override View? Render()
    {
        RenderHeader();

        for (var i = 0; i < state.Garages.Count; i++)
        {
            var garage = state.Garages[i];
            Console.WriteLine($"{i + 1} - {garage.Name}");
        }
        
        Console.WriteLine();
        
        var menu = new Menu("Menu", [
            "0 - Back to Main Menu"
        ]);
        menu.Show();

        var choice = ConsoleInput.GetInt();

        if (choice > 0)
        {
            var garage =  state.Garages[choice - 1];
            state.CurrentGarage = garage;
        }

        return choice switch
        {
            0 => previousView,
            _ => new GarageView(state, this)
        };
    }
}