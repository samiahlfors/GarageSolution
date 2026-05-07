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
        
        Console.WriteLine($"There {(_vehicleCount == 1 ? "is" : "are")} {_vehicleCount} vehicle{(_vehicleCount > 1 ? "s" : "")} in the garage");

        for (var i = 0; i < _vehicleCount; i++)
        {
            var vehicle = _vehicles[i];
            var message = $"There's a {vehicle.Color} {vehicle.Brand} {vehicle.Model} with the licence plate: {vehicle.LicensePlate}";
            Console.WriteLine(message);
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