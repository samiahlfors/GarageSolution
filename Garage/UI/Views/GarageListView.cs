using Garage.Application;
using Garage.Domain;

namespace Garage.UI.Views;

public class GarageListView(AppState state, Navigation navigation) : View
{
    public override string Title => "List of Garages";
    public override void Render()
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
        
        switch (choice)
        {
            case 0:
                navigation.GoBack();
                break;
            default:
                var garage = state.Garages[choice - 1];
                state.SetCurrentGarage(garage);
                
                navigation.NavigateTo(new GarageView(state, navigation));
                break;
        }
    }
}