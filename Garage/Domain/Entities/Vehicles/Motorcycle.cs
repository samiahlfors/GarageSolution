using Garage.Domain.Enums;

namespace Garage.Domain.Entities.Vehicles;

public class Motorcycle : Vehicle
{
    public override VehicleType VehicleType => VehicleType.Motorcycle;

    public int CylinderVolume { get; set; }
}