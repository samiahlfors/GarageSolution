using Garage.Domain.Enums;

namespace Garage.Domain.Vehicles;

public class Car : Vehicle
{
    public override VehicleType VehicleType => VehicleType.Car;
}