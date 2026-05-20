using Garage.Domain.Enums;

namespace Garage.Domain.Entities.Vehicles;

public class Boat : Vehicle
{
    public override VehicleType VehicleType => VehicleType.Boat;
    
    public double LengthInMeters { get; set; }
}