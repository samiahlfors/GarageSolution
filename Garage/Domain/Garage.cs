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
}