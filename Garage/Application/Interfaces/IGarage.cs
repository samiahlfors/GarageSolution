using Garage.Domain;
using Garage.Domain.Entities;

namespace Garage.Application.Interfaces;

public interface IGarage
{
    string Name { get; }
    int Capacity { get; }
    int OccupiedSpots { get; }

    IEnumerable<Vehicle> GetVehicles();
    Vehicle? FindVehicle(string licencePlate);
}