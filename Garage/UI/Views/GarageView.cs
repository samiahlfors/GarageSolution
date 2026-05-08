using Garage.Application;

namespace Garage.Views;

public class GarageView(AppState state, Navigation navigation, Domain.Garage garage) : View
{
    public override string Title => "Garage";
    public override void Render()
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

        switch (choice)
        {
            case 0:
                navigation.GoBack();
                break;
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        
        state.CurrentGarage = null;
    }
}