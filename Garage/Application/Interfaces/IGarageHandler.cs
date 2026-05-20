using Garage.Domain;
using Garage.Domain.Entities;

namespace Garage.Application.Interfaces;

public interface IGarageHandler<T> where T : Vehicle
{
    IEnumerable<Vehicle> GetVehicles();
    Vehicle? FindVehicle(string licencePlate);
    bool ParkVehicle(T vehicle);
    bool RemoveVehicle(ParkingSpot<T> parkingSpot);
    ParkingSpot<T>? GetParkingSpot(Vehicle vehicle);
}