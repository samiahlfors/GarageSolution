using Garage.Domain.Entities.Vehicles;
using Garage.Domain.Enums;

namespace Garage.Domain.Entities;

public abstract class Vehicle
{
    public string? LicencePlate { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public VehicleColor Color { get; set; }
    public int NumberOfWheels { get; set; }
    public virtual VehicleType VehicleType { get; set; }

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