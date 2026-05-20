using Garage.Domain.Enums;

namespace Garage.Domain.Entities.Vehicles;

public class Bus : Vehicle
{
    public override VehicleType VehicleType => VehicleType.Bus;
    
    public int PassengerCapacity { get; set; }
}