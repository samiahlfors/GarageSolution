using Garage.Application;

namespace Garage.Views;

public class GarageView(AppState state) : View
{
    public override string Title => "Garage";
    public override View? Render()
    {
        // Return a view of a specific garage
        return null;
    }
}