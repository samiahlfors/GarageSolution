using Garage.Application;

namespace Garage.Views;

public class GarageView(AppState state, Navigation navigation) : View
{
    public override string Title => "Garage";
    public override void Render()
    {
        // Return a view of a specific garage
        
        RenderHeader();
        
        Console.WriteLine($"Welcome to: {state.CurrentGarage.Name}");
        Console.WriteLine($"Occupied: {state.CurrentGarage.OccupiedSpots}/{state.CurrentGarage.Capacity}");
        
        var menu = new Menu("Menu", [
            "1 - List all cars",
            "2 - Remove garage",
            "0 - Back"
        ]);
        menu.Show();

        var choice = ConsoleInput.GetInt();

        switch (choice)
        {
            case 1:
                navigation.NavigateTo(new VehicleListView(state, navigation));
                break;
            case 2:
                if (new ConfirmationView().Confirm("Remove?", "Are you sure you want to delete this garage?"))
                {
                    state.RemoveGarage(state.CurrentGarage);
                    
                    navigation.GoBackToMainMenu(state);
                }
                break;
            case 0:
                navigation.GoBack();
                break;
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}