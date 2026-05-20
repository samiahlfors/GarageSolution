using Garage.Domain.Enums;

namespace Garage.Application.Interfaces;

public interface IVehicle
{
    public string LicencePlate { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public VehicleColor Color { get; set; }
    public int NumberOfWheels { get; set; }
    public VehicleType VehicleType { get; set; }
}