namespace Garage.Application;

public class AppState
{
    public List<Domain.Garage> Garages { get; set; }
    public Domain.Garage? CurrentGarage { get; set; }

    public AppState()
    {
        Garages = [];
    }

    public void AddGarage(Domain.Garage garage)
    {
        Garages.Add(garage);
    }
}