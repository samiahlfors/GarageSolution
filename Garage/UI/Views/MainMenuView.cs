using Garage.Application;

namespace Garage.Views;

public class MainMenuView(AppState state) : View
{
    private readonly AppState _state = state;

    public override string Title => "Garage 1.0";
    public override View? Render()
    {
        Console.Clear();
        
        var menu = new Menu("Choose an option", [
             "1 - List Garages",
             "2 - Add New Garage",
             "0 - Exit"
        ]);
        menu.Show();
         
        var choice = ConsoleInput.GetInt();
        return choice switch
        {
            1 => new GarageListView(_state),
            //2 => new AddGarageView(),
            0 => null,
            _ => this
        };
    }
}