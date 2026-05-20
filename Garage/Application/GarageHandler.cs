using Garage.Application.Interfaces;
using Garage.Domain;
using Garage.Domain.Entities;

namespace Garage.Application;

public class GarageHandler<T>(Garage<T> garage) : IGarageHandler<T> where T : Vehicle
{
    private readonly Garage<T>? _garage = garage;

    public IEnumerable<Vehicle> GetVehicles() => _garage.GetVehicles();
    public Vehicle? FindVehicle(string licencePlate) => _garage.FindVehicle(licencePlate);
    
    public bool ParkVehicle(T vehicle)
    {
        if (_garage.AtCapacity)
        {
            Log.Error($"Garage is at capacity, can't park car");
            return false;
        }
        
        _garage.ParkVehicle(vehicle);
        return true;
    }
    
    public bool RemoveVehicle(ParkingSpot<T> parkingSpot)
    {
        if (!_garage.RemoveVehicle(parkingSpot))
        {
            Log.Error($"Couldn't remove car");
            return false;
        }
        
        return true;
    }

    public ParkingSpot<T>? GetParkingSpot(Vehicle vehicle)
    {
        return _garage.GetParkingSpot(vehicle);
    }
}