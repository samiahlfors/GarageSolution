namespace Garage.Domain;

public class Garage
{
    private Vehicle[] _vehicles;
    private int _vehicleCount = 0;
    private int _freeSpots = 0;
    
    public string Name { get; set; }
    public int Capacity { get; set; }

    public Garage(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
        
        _vehicles = new Vehicle[capacity];
    }

    public void GetVehicles()
    {
        if (_vehicles.Length == 0)
        {
            Console.WriteLine($"There are no vehicles in the garage");
            return;
        }
        
        Console.WriteLine($"There are {_vehicleCount} vehicles in the garage");

        for (var i = 0; i < _vehicleCount; i++)
        {
            Console.WriteLine(_vehicles[i]);
        }
    }
    
    public void AddVehicle(Vehicle vehicle)
    {
        _vehicles[_vehicleCount] = vehicle;
        _vehicleCount++;
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