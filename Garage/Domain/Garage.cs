namespace Garage.Domain;

public class Garage
{
    private ParkingSpot[] _parkingSpots;
    private int _occupiedSpots = 0;
    private int _freeSpots = 0;
    
    public string Name { get; set; }
    public int Capacity { get; set; }
    public int OccupiedSpots => _occupiedSpots;
    public int FreeSpots => _freeSpots;

    public Garage(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
        
        _parkingSpots = new ParkingSpot[capacity];
        for (var i = 0; i < capacity; i++)
        {
            _parkingSpots[i] = new ParkingSpot(i + 1);
        }
    }

    public Vehicle[] GetVehicles()
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
    
    public void ParkVehicle(Vehicle vehicle)
    {
        if (_parkingSpots[_occupiedSpots].Park(vehicle))
        {
            _occupiedSpots++;
        }
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        // Remove a vehicle, if found
    }
    
    public void FindVehicle(string licencePlate)
    {
        // Finds a specific vehicle based on licence plate
    }

    public void FilterVehicles()
    {
        // Returns a list of vehicles based on a filter
    }
}