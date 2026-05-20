using Garage.Application.Interfaces;
using Garage.Domain;
using Garage.Domain.Entities;

namespace Garage.Application;

public class AppState
{
    public Garage<Vehicle>? CurrentGarage { get; private set; }
    public List<Garage<Vehicle>> Garages { get; set; }

    public AppState()
    {
        Garages = [];
    }

    public void SetCurrentGarage(Garage<Vehicle> garage)
    {
        CurrentGarage = garage;
    }

    public void AddGarage(Garage<Vehicle> garage)
    {
        Garages.Add(garage);
    }

    public void RemoveGarage(Garage<Vehicle> garage)
    {
        CurrentGarage = null;
        Garages.Remove(garage);
    }

    public IEnumerable<Vehicle> GetAllVehicles()
    {
        var vehicles = new List<Vehicle>();

        foreach (var garage in Garages)
        {
            vehicles.AddRange(garage);
        }
        
        return vehicles;
    }

    public void Quit(Navigation navigation)
    {
        navigation.Quit();
    }
}