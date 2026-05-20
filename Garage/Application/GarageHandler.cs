using Garage.Domain;

namespace Garage.Application;

public class GarageHandler<T>(Garage<T>? garage) where T : Vehicle
{
    public IEnumerable<Vehicle> GetVehicles() => garage.GetVehicles();
    public Vehicle? FindVehicle(string licencePlate) => garage.FindVehicle(licencePlate);
    
    public bool ParkVehicle(T vehicle)
    {
        if (garage.AtCapacity)
        {
            Log.Error($"Garage is at capacity, can't park car");
            return false;
        }
        
        garage.ParkVehicle(vehicle);
        return true;
    }
    
    public bool RemoveVehicle(ParkingSpot<T> parkingSpot)
    {
        if (!garage.RemoveVehicle(parkingSpot))
        {
            Log.Error($"Couldn't remove car");
            return false;
        }
        
        return true;
    }
}