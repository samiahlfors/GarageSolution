using Garage.Application;

namespace Garage.Views;

public class GarageListView(AppState state) : View
{
    public override string Title => "List of Garages";
    public override View? Render()
    {
        // Return a list of all available garages

        foreach (var garage in state.Garages)
        {
            Console.WriteLine(garage.Name);
        }
        
        Menu.Pause();
        
        return null;
    }
}