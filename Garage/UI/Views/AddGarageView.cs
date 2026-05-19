using Garage.Application;
using Garage.Domain;

namespace Garage.UI.Views;

public class AddGarageView(AppState state, Navigation navigation) : View
{
    public override string Title => "Add Garage";
    public override void Render()
    {
        Console.Write("Enter the name of the garage: ");
        var title = ConsoleInput.GetString(false);
        
        Console.Write($"How many parking spots does {title} have?");
        var amount = ConsoleInput.GetInt(false);

        var garage = new Garage<Vehicle>(title, amount);
        state.AddGarage(garage);
        
        Console.Clear();
        
        Console.WriteLine($"{title} successfully added");
        
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
}