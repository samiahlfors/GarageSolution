using Garage.Application;

namespace Garage.Views;

public class MainMenuView(AppState state, Navigation navigation) : View
{
    public override string Title => "Garage 1.0";
    public override void Render()
    {
        RenderHeader();
        
        var menu = new Menu("Choose an option", [
             $"1 - List Garages ({state.Garages.Count})",
             "2 - Add New Garage",
             "0 - Exit"
        ]);
        menu.Show();
        
        var choice = ConsoleInput.GetInt();
        switch (choice)
        {
            case 1:
                navigation.NavigateTo(new GarageListView(state, navigation));
                break;
            case 2:
                navigation.NavigateTo(new AddGarageView(state, navigation));
                break;
            case 0:
                navigation.Quit();
                break;
            default: break;
        }
    }
}