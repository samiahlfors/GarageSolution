using Garage.Domain.Enums;

namespace Garage.Domain.Vehicles;

public class Bus : Vehicle
{
    public override VehicleType VehicleType => VehicleType.Bus;
}