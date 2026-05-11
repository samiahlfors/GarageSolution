using Garage.Domain.Vehicles;

namespace Garage.Domain;

public abstract class Vehicle
{
    public string LicensePlate { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public int NumberOfWheels { get; set; }

    public static Vehicle CreateVehicle(int type)
    {
        switch (type)
        {
            case 1: return new Car();
            case 2: return new Bus();
            case 3: return new Motorcycle();
            case 4: return new Boat();
            case 5: return new Airplane();
            default: return new Car();
        }
    }
}