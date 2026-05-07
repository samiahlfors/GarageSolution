namespace Garage.Domain;

public abstract class Vehicle
{
    public string LicensePlate { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public int NumberOfWheels { get; set; }
}