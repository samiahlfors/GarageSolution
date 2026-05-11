using Garage.Domain.Enums;

namespace Garage.Domain.Vehicles;

public class Motorcycle : Vehicle
{
    public override VehicleType VehicleType => VehicleType.Motorcycle;
}