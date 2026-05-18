using Garage.Domain;

namespace Garage.Application;

public class GarageHandler<T>(Garage<T> garage) where T : Vehicle
{
    private Garage<T> _garage = garage;
    
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
}