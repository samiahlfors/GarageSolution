namespace Garage.Domain;

public class Garage
{
    private Array _vehicles;
    
    public string Name { get; set; }
    public int Capacity { get; set; }

    public Garage(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
        
        _vehicles = new Array[capacity];
    }

    public void GetVehicles()
    {
        // Return a list of vehicles
    }
    
    public void AddVehicle(Vehicle vehicle)
    {
        // Add a new vehicle, if unique
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