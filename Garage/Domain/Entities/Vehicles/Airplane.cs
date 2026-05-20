using Garage.Domain.Enums;

namespace Garage.Domain.Entities.Vehicles;

public class Airplane : Vehicle
{
    public override VehicleType VehicleType => VehicleType.Airplane;
    
    public int NumberOfEngines { get; set; }
}