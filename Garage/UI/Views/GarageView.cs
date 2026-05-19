using Garage.Application;

namespace Garage.UI.Views;

public class GarageView(AppState state, Navigation navigation) : View
{
    public override string Title => "Garage";
    public override void Render()
    {
        RenderHeader();
        
        Console.WriteLine($"Welcome to: {state.CurrentGarage.Name}");
        Console.WriteLine($"Occupied: {state.CurrentGarage.OccupiedSpots}/{state.CurrentGarage.Capacity}");
        if (state.CurrentGarage.AtCapacity)
        {
            Console.WriteLine($"Garage is at capacity");
        }
        
        var menu = new Menu("Menu", [
            "1 - List all vehicles",
            $"2 - Park vehicle {(state.CurrentGarage.AtCapacity ? "(at capacity)" : "")}",
            "3 - Remove garage",
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
                if (state.CurrentGarage.AtCapacity) break;
                
                navigation.NavigateTo(new AddVehicleView(state, navigation));
                break;
            case 3:
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
}