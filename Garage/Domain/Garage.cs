namespace Garage.Domain;

public class Garage
{
    private Array _vehicles;

    public int Capacity { get; set; }

    public Garage(int capacity)
    {
        Capacity = capacity;
        
        _vehicles = new Array[Capacity];
    }
}