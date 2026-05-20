using Garage.Domain.Enums;

namespace Garage.Domain.Entities.Vehicles;

public class Car : Vehicle
{
    public override VehicleType VehicleType => VehicleType.Car;

    public string FuelType { get; set; } = "";
}