using System.Collections;
using Garage.Application.Interfaces;
using Garage.Domain.Entities;

namespace Garage.Domain;

public class Garage<T> : IEnumerable<T>, IGarage where T : Vehicle
{
    private ParkingSpot<T>[] _parkingSpots;
    private int _occupiedSpots = 0;

    public string Name { get; set; }
    public int Capacity { get; set; }
    public int OccupiedSpots => _occupiedSpots;
    public int FreeSpots => Capacity - OccupiedSpots;
    public bool AtCapacity => OccupiedSpots >= Capacity;

    public Garage(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
        
        _parkingSpots = new ParkingSpot<T>[capacity];
        for (var i = 0; i < capacity; i++)
        {
            _parkingSpots[i] = new ParkingSpot<T>(i + 1);
        }
    }
    
    public void ParkVehicle(T vehicle)
    {
        foreach (var parkingSpot in _parkingSpots)
        {
            if (parkingSpot.IsOccupied) continue;
            
            parkingSpot.Park(vehicle);
            _occupiedSpots++;

            break;
        }
    }

    public bool RemoveVehicle(ParkingSpot<T> parkingSpot)
    {
        if (!parkingSpot.RemoveVehicle())
        {
            return false;
        }
        
        _occupiedSpots--;
        return true;
    }

    public ParkingSpot<T>? GetParkingSpot(Vehicle vehicle)
    {
        foreach (var parkingSpot in _parkingSpots)
        {
            if (parkingSpot.ParkedVehicle == vehicle)
            {
                return parkingSpot;
            }
        }
        
        return null;
    }

    public IEnumerable<Vehicle> GetVehicles()
    {
        Vehicle[] results = new Vehicle[_occupiedSpots];
         
        for (var i = 0; i < _occupiedSpots; i++)
        { 
            var vehicle = _parkingSpots[i].ParkedVehicle;
            if (vehicle != null)
            { 
                results[i] = vehicle;   
            }
        }
        
        return results;
    }

    public Vehicle? FindVehicle(string licencePlate)
    {
        // Finds a specific vehicle based on licence plate
        var vehicles = GetVehicles();

        foreach (var vehicle in vehicles)
        {
            if (vehicle.LicencePlate.ToLower() == licencePlate.ToLower())
            {
                return vehicle;
            }
        }
        
        return null;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var spot in _parkingSpots)
        {
            if (spot is { IsOccupied: true, ParkedVehicle: not null })
            {
                yield return spot.ParkedVehicle;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}