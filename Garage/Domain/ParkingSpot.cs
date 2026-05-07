namespace Garage.Domain;

public class ParkingSpot
{
    private Vehicle? _vehicle;
    
    public int SpotIndex { get; set; }

    public ParkingSpot(int index)
    {
        SpotIndex = index;
    }
    
    public Vehicle? ParkedVehicle => _vehicle;
    
    public bool Park(Vehicle vehicle)
    {
        if (IsOccupied) return false;
        
        _vehicle = vehicle;

        return true;
    }

    public bool IsOccupied => _vehicle is not null;
}