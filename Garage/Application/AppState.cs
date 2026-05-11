namespace Garage.Application;

public class AppState
{
    public List<Domain.Garage> Garages { get; set; }
    public Domain.Garage? CurrentGarage { get; private set; }

    public AppState()
    {
        Garages = [];
    }

    public void SetCurrentGarage(Domain.Garage garage)
    {
        CurrentGarage = garage;
    }

    public void AddGarage(Domain.Garage garage)
    {
        Garages.Add(garage);
    }

    public void RemoveGarage(Domain.Garage garage)
    {
        CurrentGarage = null;
        Garages.Remove(garage);
    }

    public void Quit(Navigation navigation)
    {
        navigation.Quit();
    }
}