namespace Garage.Domain;

public class Garage
{
    private ParkingSpot[] _parkingSpots;
    private int _occupiedSpots = 0;
    private int _freeSpots = 0;
    
    public string Name { get; set; }
    public int Capacity { get; set; }

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

    public void GetVehicles()
    {
        if (_occupiedSpots == 0)
        {
            Console.WriteLine($"There are no vehicles in the garage");
            return;
        }
        
        Console.WriteLine($"There are {_occupiedSpots} occupied spots");

        for (var i = 0; i < _occupiedSpots; i++)
        {
            var vehicle = _parkingSpots[i].ParkedVehicle;
            var message = $"There's a {vehicle.Color} {vehicle.Brand} {vehicle.Model} with the licence plate: {vehicle.LicensePlate}, and they are parked on spot {_parkingSpots[i].SpotIndex}";
            Console.WriteLine(message);
        }
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