using Garage.Domain.Enums;

namespace Garage.Domain.Vehicles;

public class Boat : Vehicle
{
    public override VehicleType VehicleType => VehicleType.Boat;
}