namespace Garage.Domain;

public class ParkingSpot<T> where T : Vehicle
{
    public int SpotIndex { get; set; }

    public ParkingSpot(int index)
    {
        SpotIndex = index;
    }
    
    public T? ParkedVehicle { get; private set; }

    public bool Park(T vehicle)
    {
        if (IsOccupied) return false;
        
        ParkedVehicle = vehicle;

        return true;
    }

    public bool RemoveVehicle()
    {
        ParkedVehicle = null;
        return true;
    }

    public bool IsOccupied => ParkedVehicle is not null;
}