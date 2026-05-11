using Garage.Domain.Enums;

namespace Garage.Domain.Vehicles;

public class Airplane : Vehicle
{
    public override VehicleType VehicleType => VehicleType.Airplane;
}